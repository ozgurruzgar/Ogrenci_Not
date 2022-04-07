using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace FacadeLayerr
{
    public class FacadeKulup
    {
        public static int Ekle(EntityKulup deger)
        {
            SqlCommand komut = new SqlCommand("KULUPEKLE",SQLBAGLANTISI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if(komut.Connection.State!=ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KULUPAD",deger.KULUPAD);
            return komut.ExecuteNonQuery();
        }

        public static bool Sil(int deger)
        {
            SqlCommand komut = new SqlCommand("KULUPSIL",SQLBAGLANTISI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if(komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KULUPID",deger);
            return komut.ExecuteNonQuery() > 0;
        }

        public static bool Guncelle(EntityKulup deger)
        {
            SqlCommand komut = new SqlCommand("KULUPGUNCELLE",SQLBAGLANTISI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if(komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KULUPAD",deger.KULUPAD);
            komut.Parameters.AddWithValue("KULUPID",deger.ID);
            return komut.ExecuteNonQuery() > 0;
        }

        public static List<EntityKulup> KulupListesi()
        {
            List<EntityKulup> degerler = new List<EntityKulup>();
            SqlCommand komut = new SqlCommand("KULUPLISTESI",SQLBAGLANTISI.baglanti);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                EntityKulup ent  = new EntityKulup();
                ent.ID = Convert.ToInt16(dr["KULUPID"]);
                ent.KULUPAD = dr["KULUPAD"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

    }
}
