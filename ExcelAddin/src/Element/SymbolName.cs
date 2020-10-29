using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class SymbolNameElement
    {
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }
    }

    public class SymbolName
    {
        private static readonly int SymbolNameCol = 2;

        private static object[] SymbolNameToArray(dynamic objectJson)
        {
            var element = (SymbolNameElement)objectJson;

            var array = new object[SymbolNameCol];
            array[0] = element.Symbol;
            array[1] = element.SymbolName;

            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object[] SymbolNameCheck(string json)
        {
            var objectJson = DynamicJson.Parse(json);

            // レスポンス項目に「Code」がある場合、APIエラーがあったと判断
            if (objectJson.IsDefined("Code") || !CustomRibbon._env)
            {
                return Utils.Util.ObjectJsonToArray(objectJson);
            }

            return SymbolNameToArray(objectJson);
        }
    }
}
