using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityKulup
    {
        int _ID;
        string _KULUPAD;

        public int ID { get => _ID; set => _ID = value; }
        public string KULUPAD { get => _KULUPAD; set => _KULUPAD = value; }
    }
}
