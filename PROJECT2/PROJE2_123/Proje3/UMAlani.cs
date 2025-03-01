using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje3
{
    public class UMAlani
    {
        public string AlanAdi { get; set; }
        public List<string> IlAdlari { get; set; }
        public int IlanYili { get; set; }

        public UMAlani(string AlanAdi, List<String> IlAdlari, int IlanYili)
        {
            this.AlanAdi = AlanAdi;
            this.IlAdlari = IlAdlari;
            this.IlanYili = IlanYili;
        }
    }
}
