using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace WPFTERETANA
{
    internal class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {
            //pruza jednostavan nacin za kreiranje i upravljanje sadrzajem konekcionog stringa
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-Q96UN2G\SQLEXPRESS", //naziv lokalnog servera Vašeg računara
                InitialCatalog = "TERETANA", //Baza na lokalnom serveru
                IntegratedSecurity = true //koristice se trenutni windows kredencijali za autentifikaciju, u slucaju da je false potrebno bi bilo u okviru konekcionog stringa navesti User ID i password
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
