using ExcelDna.Integration;
using ExcelDna.Integration.Rtd;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace KabuSuteAddin
{
    [ComVisible(true)]
    [ProgId(WebApiRequestServerProgId)]
    public class RtdBoard : ExcelRtdServer
    {
        public const string WebApiRequestServerProgId = "KabuSuteAddin.ExcelService";
        const int MinInterval = 500;
        const int MaxInterval = 10_000;

        private Timer _timer;
        private List<Topic> _topics;
        private Dictionary<int, string> _topicIdToPort;

        protected override bool ServerStart()
        {
            _topics = new List<Topic>();
            _topicIdToPort = new Dictionary<int, string>();

            Application xlApp = (Application)ExcelDnaUtil.Application;
            var callbackInterval = xlApp.RTD.ThrottleInterval / 2;
            if (callbackInterval < MinInterval)
                callbackInterval = MinInterval;

            if (callbackInterval > MaxInterval)
                callbackInterval = MaxInterval;

            _timer = new Timer(Callback, null, 0, callbackInterval);
            return true;
        }

        protected override void ServerTerminate()
        {
            _timer.Dispose();
        }

        protected override object ConnectData(Topic topic, IList<string> topicInfo, ref bool newValues)
        {
            var id = topic.TopicId;
            var port = topicInfo[0];
            if (!string.IsNullOrEmpty(port))
            {
                _topicIdToPort.Add(id, port);
                _topics.Add(topic);
                return GetRTD();
            }
            return 2;
        }

        protected override void DisconnectData(Topic topic)
        {
            _topics.Remove(topic);
            _topicIdToPort.Remove(topic.TopicId);
        }

        void Callback(object o)
        {
            foreach (var topic in _topics)
            {
                var port = _topicIdToPort[topic.TopicId];
                string boardData = GetRTD();
                topic.UpdateValue(boardData);
            }
        }

        private string GetRTD()
        {
            return ExcelFunctionController.ReturnWebSocketData();
        }
    }
}