using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayerr;

namespace BusinessLogicLayer
{
    public class BLLNOTLAR
    {
        public static bool GUNCELLE(EntityNotlar deger)
        {
            if(deger.OGRENCIID!=0 && deger.OGRENCIID > 0 && deger.ORTALAMA>=0 && deger.ORTALAMA<=100 
                && deger.SINAV2 != 0 && deger.SINAV2 >= 0 && deger.SINAV2 <= 100 && deger.SINAV3 != 0 
                && deger.SINAV3 >= 0 && deger.SINAV3 <= 100 &&  deger.PROJE>=0 &&
        deger.PROJE<=100 && deger.DURUM != null)
            {
                return FACADENOTLAR.GUNCELLE(deger);
            }
            return false;
        }
        public static List<EntityNotlar> LISTELE()
        {
            return FACADENOTLAR.NOTLISTESI();
        }
    }
}
