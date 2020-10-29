using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace KabuSuteAddin
{

    [DataContract]
    public class CancelOrderParam
    {
        [DataMember(Name = "OrderId")]
        public string OrderId { get; set; }

        [DataMember(Name = "Password")]
        public string OrderPassword { get; set; }

    }

}
