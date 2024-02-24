using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WPFTERETANA
{
    /// <summary>
    /// Interaction logic for FrmKlijent.xaml
    /// </summary>
    public partial class FrmKlijent : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmKlijent()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIDKlijenta.Focus();

        }
        public FrmKlijent(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIDKlijenta.Focus();
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
                cmd.Parameters.Add("@KlijentID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(txtIDKlijenta.Text);

                cmd.Parameters.Add("@Ime", System.Data.SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@Prezime", System.Data.SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@GradKlijenta", System.Data.SqlDbType.NVarChar).Value = txtGradKlijenta.Text;
                cmd.Parameters.Add("@KontaktKlijenta", System.Data.SqlDbType.NVarChar).Value = txtKontakt.Text;
                cmd.Parameters.Add("@AdresaKlijenta", System.Data.SqlDbType.NVarChar).Value = txtAdresa.Text;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblklijent
                                        Set KlijentID = @IDKlijenta, Ime = @Ime, Prezime = @Prezime, GradKlijenta = @GradKlijenta, KontaktKlijenta = @KontaktKlijenta, AdresaKlijenta = @AdresaKlijenta
                                        where KlijentID = @id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblklijent (KlijentID, Ime, Prezime, GradKlijenta, KontaktKlijenta, AdresaKlijenta )
                                    values(@KlijentID, @Ime, @Prezime, @GradKlijenta,  @KontaktKlijenta, @AdresaKlijenta)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL greška: {ex.Message}", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Greška prilikom konverzije podataka: {ex.Message}", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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




