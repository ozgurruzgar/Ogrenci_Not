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
    public class BLLKULUP
    {
        public static int EKLE(EntityKulup deger)
        {
            if(deger.KULUPAD != null )
            {
                return FacadeKulup.Ekle(deger);
            }
            else
            {
                return -1;
            }
        }
        public static bool GUNCELLE(EntityKulup deger)
        {
            if(deger.KULUPAD!=null && deger.ID!=0)
            {
                return FacadeKulup.Guncelle(deger);
            }
            return false;
        }
        public static bool SIL(int deger)
        {
            if(deger != 0)
            {
                return FacadeKulup.Sil(deger);
            }
            return false;
        }
        public static List<EntityKulup> LISTELE()
        {
            return FacadeKulup.KulupListesi();
        }
    }
}
