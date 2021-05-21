using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class JsonData
    {

        public string label { get; set; }
        public int[] data { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public bool fill { get; set; }

    }
}
