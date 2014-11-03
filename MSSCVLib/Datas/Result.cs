using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSCVLib.Datas
{
    public class Result
    {
        [DisplayName("Date")]
        public string Date { get; set; }
        [DisplayName("Value")]
        public string Value { get; set; }
    }
}
