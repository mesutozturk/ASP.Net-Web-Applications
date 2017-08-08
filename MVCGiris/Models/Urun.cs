using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGiris.Models
{
    public class Urun
    {
        public int id { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }

        public static List<Urun> Urunler
        {
            get
            {
                return new List<Urun>(){
                    new Urun()
                    {
                        id = 1,
                        Fiyat = 5,
                        UrunAdi = "Kola"
                    },
                    new Urun()
                    {
                        id = 2,
                        Fiyat = 9,
                        UrunAdi = "Tavuk Döner"
                    },
                    new Urun()
                    {
                        id = 3,
                        Fiyat = 14,
                        UrunAdi = "Dana Döner"
                    }};
            }
        }

    }
}