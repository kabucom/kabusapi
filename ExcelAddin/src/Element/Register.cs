using System.Collections.Generic;
using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{

    [DataContract]
    public class RegisterElement
    {
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "Exchange")]
        public string Exchange { get; set; }

    }

    public class RegisterResult
    {
        private static object RegisterMultipleDimToArray(dynamic objectJson)
        {
            var jsonArray = (dynamic[])objectJson.RegistList;

            if (jsonArray.Length == 0)
                return null;

            object[,] array = new object[jsonArray.Length, 2];
            int row = 0;

            foreach (RegisterElement item in jsonArray)
            {
                array[row, 0] = item.Symbol;
                array[row, 1] = item.Exchange;
                row++;
            }

            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object RegisterCheck(string value)
        {
            var objectJson = DynamicJson.Parse(value);
            object ret;
            if (objectJson.IsDefined("Code"))
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }
            else if (!CustomRibbon._env)
            {
                return null;
            }

            ret = RegisterMultipleDimToArray(objectJson);
            return ret;
        }
    }
}
