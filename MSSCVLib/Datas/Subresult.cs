using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSCVLib.Datas
{
    public class Subresult
    {
        [DisplayName("Source")]
        public string Sender { get; set; }
        [DisplayName("Message")]
        public string Value { get; set; }
    }
}
