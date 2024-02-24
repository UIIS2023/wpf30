using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFTERETANA
{
    /// <summary>
    /// Interaction logic for FrmRoba.xaml
    /// </summary>
    public partial class FrmRoba : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmRoba()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
        }
        public FrmRoba(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIDRobe.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
         
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@RobaID", System.Data.SqlDbType.Int).Value = txtIDRobe.Text;
                cmd.Parameters.Add("@NazivRobe", System.Data.SqlDbType.NVarChar).Value = txtNazivRobe.Text;            
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update Roba
                                        Set RobaID = @IDRobe, NazivRobe = @NazivRobe
                                        where RobaID = @id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblRoba (RobaID, NazivRobe )
                                    values(@RobaID, @NazivRobe)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Greska prilikom konverzije podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }
        }
        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

        
