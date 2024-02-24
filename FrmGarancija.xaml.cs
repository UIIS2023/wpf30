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
    /// Interaction logic for FrmGarancija.xaml
    /// </summary>
    public partial class FrmGarancija : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmGarancija()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }
        public FrmGarancija(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtGarancijaID.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }
        //private void PopuniPadajuceListe()
        //{
        //    try
        //    {
        //        konekcija.Open();
        //        string vratiZaposlene = @"select ZaposleniID, ImeZaposlenog, PrezimeZaposlenog, JMBG, AdresaZaposlenog, GradZaposlenog, KontaktZaposlenog, PozicijaZaposlenog, KorIme, Lozinka from tblZaposleni";
        //        DataTable dtZaposleni = new DataTable();
        //        SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlene, konekcija);
        //        daZaposleni.Fill(dtZaposleni);
        //        cbIDZaposlenog.ItemsSource = dtZaposleni.DefaultView;
        //        cbIDZaposlenog.DisplayMemberPath = "ZaposleniID";
        //        daZaposleni.Dispose();
        //        dtZaposleni.Dispose();

        //        konekcija.Open();
        //        string vratiRobu = @"select RobaID, NazivRobe from tblRoba";
        //        DataTable dtRoba = new DataTable();
        //        SqlDataAdapter daRoba = new SqlDataAdapter(vratiRobu, konekcija);
        //        daRoba.Fill(dtRoba);
        //        cbIDRobe.ItemsSource = dtRoba.DefaultView;
        //        cbIDRobe.DisplayMemberPath = "RobaID";
        //        daRoba.Dispose();
        //        dtRoba.Dispose();


        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    finally
        //    {
        //        if (konekcija != null)
        //        {
        //            konekcija.Close();
        //        }
        //    }
        //}

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vratiZaposlene = @"select ZaposleniID, ImeZaposlenog, PrezimeZaposlenog, JMBG, AdresaZaposlenog, GradZaposlenog, KontaktZaposlenog, PozicijaZaposlenog, KorIme, Lozinka from tblZaposleni";
                DataTable dtZaposleni = new DataTable();
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlene, konekcija);
                daZaposleni.Fill(dtZaposleni);
                cbIDZaposlenog.ItemsSource = dtZaposleni.DefaultView;
                cbIDZaposlenog.DisplayMemberPath = "ZaposleniID";
                daZaposleni.Dispose();
                dtZaposleni.Dispose();

               
                string vratiRobu = @"select RobaID, NazivRobe from tblRoba";
                DataTable dtRoba = new DataTable();
                SqlDataAdapter daRoba = new SqlDataAdapter(vratiRobu, konekcija);
                daRoba.Fill(dtRoba);
                cbIDRobe.ItemsSource = dtRoba.DefaultView;
                cbIDRobe.DisplayMemberPath = "RobaID";
                daRoba.Dispose();
                dtRoba.Dispose();
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
                cmd.Parameters.Add("@IDGarancija", System.Data.SqlDbType.Int).Value = txtGarancijaID.Text;
                cmd.Parameters.Add("@IDZaposlenog", System.Data.SqlDbType.Int).Value = cbIDZaposlenog.SelectedValue;
                cmd.Parameters.Add("@IDRobe", System.Data.SqlDbType.Int).Value = cbIDRobe.SelectedValue;
                cmd.Parameters.Add("@Datum", System.Data.SqlDbType.DateTime).Value = dtDatum.SelectedDate;
                cmd.Parameters.Add("@Trajanje", System.Data.SqlDbType.Int).Value = txtTrajanje.Text;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblGarancija
                                        Set GarancijaID = @IDGarancije, ZaposleniID = @IDZaposlenog, RobaID = @Roba, Datum = @Datum, Trajanje = @Trajanje
                                        where GarancijaID = @id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblGarancija (GarancijaID, ZaposleniID, RobaID, Datum, Trajanje)
                                    values (@IDGarancija, @IDZaposlenog, @IDRobe, @Datum, @Trajanje)";

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
  
    


