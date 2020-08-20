using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class TokenParam
    {

        [DataMember(Name = "APIPassword")]
        public string APIPassword { get; set; }

    }
}
