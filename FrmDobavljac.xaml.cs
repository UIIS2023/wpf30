using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WPFTERETANA
{
    /// <summary>
    /// Interaction logic for FrmDobavljac.xaml
    /// </summary>
    public partial class FrmDobavljac : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmDobavljac()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
        }
        //public FrmDobavljac(bool azuriraj, DataRowView pomocniRed)
        //{
        //    InitializeComponent();
        //    konekcija = kon.KreirajKonekciju();
        //    txtDobavljacID.Focus();
        //    this.azuriraj = azuriraj;
        //    this.pomocniRed = pomocniRed;
        //}

        public FrmDobavljac(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();

            // Dodajte sledeću liniju kako biste proverili informacije o bazi podataka
            Console.WriteLine($"Konekcija ka bazi podataka: {konekcija.Database}");
            txtDobavljacID.Focus();
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
                cmd.Parameters.Add("@DobavljacID", SqlDbType.Int).Value = int.Parse(txtDobavljacID.Text);
                cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@ImeFirme", SqlDbType.NVarChar).Value = txtImeFirme.Text;



                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@IDDobavljaca", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblDobavljac
                    Set Ime = @Ime, Prezime = @Prezime, ImeFirme = @ImeFirme
                    where DobavljacID = @IDDobavljaca";


                }
                else
                {
                    cmd.CommandText = @"insert into tblDobavljac (DobavljacID, Ime, Prezime, ImeFirme )
                                    values(@DobavljacID, @Ime, @Prezime, @ImeFirme)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL greška: {ex.ToString()}", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
