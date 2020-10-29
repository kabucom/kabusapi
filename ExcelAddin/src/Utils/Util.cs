using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using Codeplex.Data;
using ExcelDna.Integration;
using KabuSuteAddin.Elements;

namespace KabuSuteAddin.Utils
{
    public class Util
    {

        [ExcelFunction(IsHidden = true)]
        public static object SingleDimToArray(string str)
        {
            var objectJson = DynamicJson.Parse(str);
            var jsonarr = (dynamic[])objectJson;

            object[] array = new object[jsonarr.Length];
            int col = 0;

            foreach (KeyValuePair<string, object> item in objectJson)
            {
                array[col] = item.Value;
                col++;
            }

            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object[] ObjectJsonToArray(dynamic objectJson)
        {
            var jsonarr = (dynamic[])objectJson;

            object[] array = new object[jsonarr.Length];
            int col = 0;

            foreach (KeyValuePair<string, object> item in objectJson)
            {
                array[col] = item.Value;
                col++;
            }

            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static string ArrayToText(object[,] array)
        {
            string val = null;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    val += array[i, j] + "-";
                }
            }

            return val;
        }

        [ExcelFunction(IsHidden = true)]
        public static string SymbolArrayToString(object[,] symbolData)
        {
            int row = symbolData.GetLength(0);
            int col = symbolData.GetLength(1);

            SymbolParamList param = new SymbolParamList
            {
                Symbols = new List<SymbolList>()
            };

            for (int i = 0; i < row; i++)
            {
                var test = new SymbolList
                {
                    Symbol = symbolData[i, 0].ToString(),
                    Exchange = int.Parse(symbolData[i, 1].ToString()),
                };

                param.Symbols.Add(test);

            }

            var json = "";
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(SymbolParamList));
                serializer.WriteObject(stream, param);
                json = Encoding.UTF8.GetString(stream.ToArray());
            }

            return json;
        }

    }
}
