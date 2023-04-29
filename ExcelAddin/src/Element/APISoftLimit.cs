using Codeplex.Data;
using ExcelDna.Integration;
using System.Runtime.Serialization;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class APISoftLimitElement
    {
        [DataMember(Name = "Stock")]
        public int Stock { get; set; }
        [DataMember(Name = "Nargin")]
        public int Margin { get; set; }
        [DataMember(Name = "Future")]
        public int Future { get; set; }
        [DataMember(Name = "FutureMini")]
        public int FutureMini { get; set; }
        [DataMember(Name ="Option")]
        public int Option { get; set; }
        [DataMember(Name ="kabuSVersion")]
        public string kabuSVersion { get; set; }

    }

    public class APISoftLimitResult
    {
        private const int ResCol = 6;
        private static object APISoftLimitToArray(dynamic objectJson)
        {
            APISoftLimitElement APISoftLimitData = (APISoftLimitElement)objectJson;
            object[] array = new object[ResCol];
            array[0] = APISoftLimitData.Stock;
            array[1] = APISoftLimitData.Margin;
            array[2] = APISoftLimitData.Future;
            array[3] = APISoftLimitData.FutureMini;
            array[4] = APISoftLimitData.Option;
            array[5] = APISoftLimitData.kabuSVersion;
            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object APISoftLimitCheck(string value)
        {
            var JsonObj = DynamicJson.Parse(value);
            object ret;
            if (JsonObj.IsDefined("Code") || !CustomRibbon._env)
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }
            ret = APISoftLimitToArray(JsonObj);
            return ret;
        }
    }
}
