using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KabuSuteAddin.Elements
{

    [DataContract]
    public class SymbolList
    {
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "Exchange")]
        public int Exchange { get; set; }
    }

    [DataContract]
    public class SymbolParamList
    {
        [DataMember(Name = "Symbols")]
        public List<SymbolList> Symbols { get; set; }
    }

}
