using System.Collections.Generic;
using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;
using System.Diagnostics;

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
            //Debug.WriteLine(value);
            var objectJson = DynamicJson.Parse(value);
            Debug.WriteLine(value);
            object ret;

            if (objectJson.IsDefined("Code") || !CustomRibbon._env)
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }
            

            ret = RegisterMultipleDimToArray(objectJson);
            return ret;
        }
    }
}
