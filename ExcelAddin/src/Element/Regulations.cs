using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;
using System.Diagnostics;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class RegulationsElement
    {
        [DataMember(Name ="Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name ="RegulationsInfo")]
        public List<RegulationInfo> RegulationsInfo { get; set; }
    }
    [DataContract]
    public class RegulationInfo
    {
        [DataMember(Name ="Exchange")]
        public int Exchange { get; set; }
        [DataMember(Name = "Product")]
        public int Product { get; set; }
        [DataMember(Name = "Side")]
        public string Side { get; set; }
        [DataMember(Name = "Reason")]
        public string Reason { get; set; }
        [DataMember(Name = "LimitStartDay")]
        public string LimitStartDay { get; set; }
        [DataMember(Name = "LimitEndDay")]
        public string LimitEndDay { get; set; }
        [DataMember(Name = "Level")]
        public int Level { get; set; }
    }

    public class RegulationsInfoResult
    {
        public const int ResRow = 1;
        public const int ResCol = 8;
        private static object RegulationsInfoToArray(dynamic JsonObj)
        {
            RegulationsElement RegulationsInfoData = (RegulationsElement)JsonObj;
            int objRow = RegulationsInfoData.RegulationsInfo.Count;
            
            object[,] array = objRow==0 ? new object[ResRow,ResCol] : new object[RegulationsInfoData.RegulationsInfo.Count, ResCol];
            Debug.WriteLine(RegulationsInfoData.RegulationsInfo.Count);
            int row = 0;
            array[row, 0] = RegulationsInfoData.Symbol;
            if (objRow != 0)
            {
                for (int i = 0; i < RegulationsInfoData.RegulationsInfo.Count; i++)
                {
                    array[row, 1] = RegulationsInfoData.RegulationsInfo[i].Exchange;
                    array[row, 2] = RegulationsInfoData.RegulationsInfo[i].Product;
                    array[row, 3] = RegulationsInfoData.RegulationsInfo[i].Side;
                    array[row, 4] = RegulationsInfoData.RegulationsInfo[i].Reason;
                    array[row, 5] = RegulationsInfoData.RegulationsInfo[i].LimitStartDay;
                    array[row, 6] = RegulationsInfoData.RegulationsInfo[i].LimitEndDay;
                    array[row, 7] = RegulationsInfoData.RegulationsInfo[i].Level;
                    row++;
                }
            }
            
            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object RegulationCheck(string value)
        {
            var JsonObj = DynamicJson.Parse(value);
            object ret;
            if (JsonObj.IsDefined("Code"))
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }else if (!CustomRibbon._env)
            {
                return 0;
            }
            ret = RegulationsInfoToArray(JsonObj);
            return ret;
        }
    }
}
