using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityOgrencı
    {
        int _ID;
        string _AD;
        string _SOYAD;
        string _FOTOGRAF;
        int _KULUPID;

        public int ID { get => _ID; set => _ID = value; }
        public string AD { get => _AD; set => _AD = value; }
        public string SOYAD { get => _SOYAD; set => _SOYAD = value; }
        public string FOTOGRAF { get => _FOTOGRAF; set => _FOTOGRAF = value; }
        public int KULUPID { get => _KULUPID; set => _KULUPID = value; }
    }
}
