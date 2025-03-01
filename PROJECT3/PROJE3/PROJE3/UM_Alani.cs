using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE3
{
    internal class UM_Alani
    {
        public String alanAdi { get; set; }
        public List<String> info { get; set; }

        public UM_Alani(String alanAdi, List<string> info)
        {
            this.alanAdi = alanAdi;
            this.info = info;
        }
    }
}
