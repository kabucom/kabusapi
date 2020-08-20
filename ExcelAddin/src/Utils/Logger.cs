using System.Configuration;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace KabuSuteAddin.Utils
{
    public class Logger
    {
        /// <summary>
        /// ログレベル
        /// </summary>
        private enum LogLevel
        {
            ERROR,
            WARN,
            INFO,
            DEBUG
        }

        private static Logger singleton = null;
        private readonly string logFilePath = null;
        private readonly object lockObj = new object();
        private StreamWriter stream = null;

        /// <summary>
        /// インスタンスを生成する
        /// </summary>
        public static Logger GetInstance()
        {
            if (singleton == null)
            {
                singleton = new Logger();
            }
            return singleton;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private Logger()
        {
            this.logFilePath = ConfigurationManager.AppSettings["LOGDIR_PATH"] + ConfigurationManager.AppSettings["LOGFILE_NAME"] + ".log";

            // ログファイルを生成する
            CreateLogfile(new FileInfo(logFilePath));
        }

        /// <summary>
        /// ERRORレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Error(string msg)
        {
            if ((int)LogLevel.ERROR <= int.Parse(ConfigurationManager.AppSettings["LOG_LEVEL"].ToString()))
            {
                Out(LogLevel.ERROR, msg);
            }
        }

        /// <summary>
        /// ERRORレベルのスタックトレースログを出力する
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        public void Error(Exception ex)
        {
            if ((int)LogLevel.ERROR <= int.Parse(ConfigurationManager.AppSettings["LOG_LEVEL"]))
            {
                Out(LogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        /// <summary>
        /// WARNレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Warn(string msg)
        {
            if ((int)LogLevel.WARN <= int.Parse(ConfigurationManager.AppSettings["LOG_LEVEL"]))
            {
                Out(LogLevel.WARN, msg);
            }
        }

        /// <summary>
        /// INFOレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Info(string msg)
        {
            if ((int)LogLevel.INFO <= int.Parse(ConfigurationManager.AppSettings["LOG_LEVEL"]))
            {
                Out(LogLevel.INFO, msg);
            }
        }

        /// <summary>
        /// DEBUGレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Debug(string msg)
        {
            if ((int)LogLevel.DEBUG <= int.Parse(ConfigurationManager.AppSettings["LOG_LEVEL"]))
            {
                Out(LogLevel.DEBUG, msg);
            }
        }

        /// <summary>
        /// ログを出力する
        /// </summary>
        /// <param name="level">ログレベル</param>
        /// <param name="msg">メッセージ</param>
        private void Out(LogLevel level, string msg)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["IS_LOGFILE"]))
            {
                int tid = System.Threading.Thread.CurrentThread.ManagedThreadId;
                string fullMsg = string.Format("[{0}][{1}][{2}] {3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), tid, level.ToString(), msg);

                lock (this.lockObj)
                {
                    this.stream.WriteLine(fullMsg);

                    FileInfo logFile = new FileInfo(this.logFilePath);
                    if (int.Parse(ConfigurationManager.AppSettings["LOGFILE_MAXSIZE"]) < logFile.Length)
                    {
                        // ログファイルを圧縮する
                        CompressLogFile();

                        // 古いログファイルを削除する
                        DeleteOldLogFile();
                    }
                }
            }
        }

        /// <summary>
        /// ログファイルを生成する
        /// </summary>
        /// <param name="logFile">ファイル情報</param>
        private void CreateLogfile(FileInfo logFile)
        {
            if (!Directory.Exists(logFile.DirectoryName))
            {
                Directory.CreateDirectory(logFile.DirectoryName);
            }

            this.stream = new StreamWriter(logFile.FullName, true, Encoding.UTF8)
            {
                AutoFlush = true
            };
        }

        /// <summary>
        /// ログファイルを圧縮する
        /// </summary>
        private void CompressLogFile()
        {
            this.stream.Close();
            string oldFilePath = ConfigurationManager.AppSettings["LOGDIR_PATH"] + ConfigurationManager.AppSettings["LOGFILE_NAME"] + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            File.Move(this.logFilePath, oldFilePath + ".log");

            FileStream inStream = new FileStream(oldFilePath + ".log", FileMode.Open, FileAccess.Read);
            FileStream outStream = new FileStream(oldFilePath + ".gz", FileMode.Create, FileAccess.Write);
            GZipStream gzStream = new GZipStream(outStream, CompressionMode.Compress);

            int size = 0;
            byte[] buffer = new byte[int.Parse(ConfigurationManager.AppSettings["LOGFILE_MAXSIZE"]) + 1000];
            while (0 < (size = inStream.Read(buffer, 0, buffer.Length)))
            {
                gzStream.Write(buffer, 0, size);
            }

            inStream.Close();
            gzStream.Close();
            outStream.Close();

            File.Delete(oldFilePath + ".log");
            CreateLogfile(new FileInfo(this.logFilePath));
        }

        /// <summary>
        /// 古いログファイルを削除する
        /// </summary>
        private void DeleteOldLogFile()
        {
            Regex regex = new Regex(ConfigurationManager.AppSettings["LOGFILE_NAME"] + @"_(\d{14}).*\.gz");
            DateTime retentionDate = DateTime.Today.AddDays(-int.Parse(ConfigurationManager.AppSettings["LOGFILE_PERIOD"]));
            string[] filePathList = Directory.GetFiles(ConfigurationManager.AppSettings["LOGDIR_PATH"], ConfigurationManager.AppSettings["LOGFILE_NAME"] + "_ *.gz", SearchOption.TopDirectoryOnly);
            foreach (string filePath in filePathList)
            {
                Match match = regex.Match(filePath);
                if (match.Success)
                {
                    DateTime logCreatedDate = DateTime.ParseExact(match.Groups[1].Value.ToString(), "yyyyMMddHHmmss", null);
                    if (logCreatedDate < retentionDate)
                    {
                        File.Delete(filePath);
                    }
                }
            }
        }
    }
}
