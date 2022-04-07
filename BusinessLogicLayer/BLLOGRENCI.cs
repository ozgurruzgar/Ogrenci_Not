using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayerr;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class BLLOGRENCI
    {
       public static int EKLE(EntityOgrencı deger)
        {
            if(deger.AD!= null && deger.SOYAD != null && deger.KULUPID!=0 && deger.FOTOGRAF!=null &&deger.KULUPID>0 && deger.FOTOGRAF.Length > 1)
            {
                return FacadeOgrencı.EKLE(deger);
            }
            return -1;
        }
        public static bool GUNCELLE(EntityOgrencı deger)
        {
            if (deger.AD != null && deger.SOYAD != null && deger.KULUPID != 0 && deger.FOTOGRAF != null && deger.KULUPID > 0 && deger.ID!=0)
            {
                return FacadeOgrencı.GUNCELLE(deger);
            }
            return false;
        }
        public static bool SIL(int deger)
        {
            if(deger != 0 && deger > 1)
            {
                return FacadeOgrencı.SİL(deger);
            }
            return false;
        }
        public static List<EntityOgrencı> LISTELE()
        {
            return FacadeOgrencı.OgrencıListesi();
        }
    }
}
