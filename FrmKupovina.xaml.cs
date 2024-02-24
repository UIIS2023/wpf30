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
    /// Interaction logic for FrmKupovina.xaml
    /// </summary>
    public partial class FrmKupovina : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmKupovina()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIDKupovine.Focus();
        }
        public FrmKupovina(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIDKupovine.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
        }
        private void PopuniPadajuceListe()
        {
            try
            {

                konekcija.Open();
                string vratiRobu = @"select RobaID, NazivRobe from tblRoba";
                DataTable dtRoba = new DataTable();
                SqlDataAdapter daRoba = new SqlDataAdapter(vratiRobu, konekcija);
                daRoba.Fill(dtRoba);
                cbIDRobe.ItemsSource = dtRoba.DefaultView;
                cbIDRobe.DisplayMemberPath = "RobaID";
                daRoba.Dispose();
                dtRoba.Dispose();

                konekcija.Open();
                string vratiZaposlene = @"select ZaposleniID, ImeZaposlenog, PrezimeZaposlenog, JMBG, AdresaZaposlenog, GradZaposlenog, KontaktZaposlenog, PozicijaZaposlenog, KorIme, Lozinka from tblZaposleni";
                DataTable dtZaposleni = new DataTable();
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlene, konekcija);
                daZaposleni.Fill(dtZaposleni);
                cbIDZaposlenog.ItemsSource = dtZaposleni.DefaultView;
                cbIDZaposlenog.DisplayMemberPath = "ZaposleniID";
                daZaposleni.Dispose();
                dtZaposleni.Dispose();

                konekcija.Open();
                string vratiKlijenta = @"select KlijentID, Ime, Prezime, GradKlijenta, KontaktKlijenta, AdresaKlijenta from tblklijent";
                DataTable dtKlijent = new DataTable();
                SqlDataAdapter daKlijent = new SqlDataAdapter(vratiKlijenta, konekcija);
                daKlijent.Fill(dtKlijent);
                cbIDKlijenta.ItemsSource = dtKlijent.DefaultView;
                cbIDKlijenta.DisplayMemberPath = "KlijentID";
                daKlijent.Dispose();
                dtKlijent.Dispose();



            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
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
                cmd.Parameters.Add("@KupovinaID", System.Data.SqlDbType.Int).Value = txtIDKupovine.Text;
                cmd.Parameters.Add("@VrstaKupovine", System.Data.SqlDbType.Int).Value = txtVrstaKupovine.Text;
                cmd.Parameters.Add("@BrojRacuna", System.Data.SqlDbType.Int).Value = txtBrojRacuna.Text;
                cmd.Parameters.Add("@Popust", System.Data.SqlDbType.Int).Value = cbxPopust.IsChecked;
                cmd.Parameters.Add("@PopustiIznos", System.Data.SqlDbType.Int).Value = txtIznosPopusta.Text;
                cmd.Parameters.Add("@Datum", System.Data.SqlDbType.DateTime).Value = dtDatum.SelectedDate;
                cmd.Parameters.Add("@RobaID", System.Data.SqlDbType.Int).Value = cbIDRobe.SelectedValue;
                cmd.Parameters.Add("@ZaposleniID", System.Data.SqlDbType.Int).Value = cbIDZaposlenog.SelectedValue;
                cmd.Parameters.Add("@KlijentID", System.Data.SqlDbType.Int).Value = cbIDKlijenta.SelectedValue;

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update Kupovina
                                        Set KupovinaID = @IDKupovine, VrstaKupovine = @VrstaKupovine, BrojRacuna = @BrojRacuna, PopustiIznos = @IznosPopusta, Datum = @Datum, RobaID = @IDRobe, ZaposleniID = @IDZaposlenog, KlijentID = @IDKlijenta
                                        where KupovinaID = @id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKupovina (KupovinaID, VrstaKupovine, BrojRacuna, Popust, PopustiIznos, Datum, RobaID, ZaposleniID, KlijentID)
                                    values(@KupovinaID, @VrstaKupovine, @BrojRacuna, @Popust, @PopustiIznos, @Datum, @RobaID, @ZaposleniID, @KlijentID)";
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
  
    

