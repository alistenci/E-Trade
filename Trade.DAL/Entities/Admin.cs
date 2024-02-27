using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.DAL.Entities
{
    public class Admin
    {
        public int ID { get; set; }
        public string Kullanici_Adi { get; set; }
        public string Sifre { get; set; }
        public string Ad_Soyad { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIP { get; set; }
    }
}
