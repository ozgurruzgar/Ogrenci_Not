using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FacadeLayerr
{
   public class SQLBAGLANTISI
    {
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=ASUS-PC\SQLEXPRESS;Initial Catalog=DBTestKatman;Integrated Security=True");
    }
}
