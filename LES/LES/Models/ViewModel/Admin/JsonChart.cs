using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class JsonChart
    {
        
        public string[] labels { get; set; }
        public JsonData[] datasets { get; set; }

    }
}
