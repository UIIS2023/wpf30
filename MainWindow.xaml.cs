using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTERETANA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ucitanaTabela;
        bool azuriraj;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        #region Select Upiti
        //private static string KupovinaSelect = @"select KupovinaID as ID, VrstaKupovine as 'VrstaKupovine', BrojRacuna as 'BrojRacuna', Popust as 'Popust', PopustiIznos as 'Iznospopusta', Datum as 'Datum', RobaID as 'Roba', ZaposleniID as 'Zaposleni', KlijentID as 'IDKlijenta' 
        //                                             from tblKupovina join tblklijent on tblKupovina.KlijentID = tblklijent.KlijentID
        //                                                              join tblZaposleni on tblKupovina.ZaposleniID = tblZaposleni.ZaposleniID
        //                                                              join tblRoba on tblKupovina.RobaID = tblRoba.RobaID ";                                                                                     

        private static string KupovinaSelect = @"select KupovinaID as ID, VrstaKupovine as 'VrstaKupovine', BrojRacuna as 'BrojRacuna', Popust as 'Popust', PopustiIznos as 'Iznospopusta', Datum as 'Datum', tblRoba.RobaID as 'Roba', tblZaposleni.ZaposleniID as 'Zaposleni', tblklijent.KlijentID as 'IDKlijenta' 
                                         from tblKupovina 
                                         join tblklijent on tblKupovina.KlijentID = tblklijent.KlijentID
                                         join tblZaposleni on tblKupovina.ZaposleniID = tblZaposleni.ZaposleniID
                                         join tblRoba on tblKupovina.RobaID = tblRoba.RobaID";


        private static string VrstaSelect = @"select VrstaID as ID, ImeVrste as 'Ime Vrste' from tblVrsta";

        private static string RobaSelect = @"select RobaID as ID, NazivRobe as 'Naziv Robe' from tblRoba";

        private static string DobavljacSelect = @"select DobavljacID as ID, Ime as 'ImeDobavljaca', Prezime as 'PrezimeDobavljaca', ImeFirme as 'ImeFirme' from tblDobavljac";

        private static string GarancijaSelect = @"select GarancijaID as ID, tblZaposleni.ZaposleniID as 'Zaposleni', tblRoba.RobaID as 'Roba', Datum as 'Datum garancije ' , Trajanje as 'Trajanje garancije' from tblGarancija  
                                                    join tblZaposleni on tblGarancija.ZaposleniID = tblZaposleni.ZaposleniID
                                                                     join tblRoba on tblGarancija.RobaID = tblRoba.RobaID";

        private static string klijentSelect = @"select KlijentID as ID, Ime as 'ImeKlijenta', Prezime as 'PrezimeKlijenta', KontaktKlijenta as 'Kontakt', GradKlijenta as 'Grad', AdresaKlijenta as 'Adresa' from tblklijent";

        private static string ReklamacijaSelect = @"select 
                                                ReklamacijaID as ID, 
                                                OpisReklamacije as 'Opis reklamacije', 
                                                tblZaposleni.ZaposleniID as 'Zaposleni', 
                                                tblKlijent.KlijentID as 'Klijent' 
                                              from tblReklamacija
                                              join tblZaposleni on tblReklamacija.ZaposleniID = tblZaposleni.ZaposleniID
                                              join tblGarancija on tblReklamacija.GarancijaID = tblGarancija.GarancijaID
                                              join tblKlijent on tblGarancija.KlijentID = tblKlijent.KlijentID";

        private static string ClanarinaSelect = @"select ClanarinaID as ID, Opis as 'Opis clanarine', Cena as 'Cena', VrstaTrng as 'Vrsta Treninga', Trajanje as 'Trajanje clanarine', tblVrsta.VrstaID as 'Vrsta' from tblClanarina 
                                                   join tblVrsta on tblClanarina.VrstaID = tblVrsta.VrstaID";
        #endregion

        #region Select sa uslovom
        string selectUslovKupovina = @"select * from tblKupovina where KupovinaID=";
        string selectUslovVrsta = @"select * from tblVrsta where VrstaID=";
        string selectUslovRoba = @"select * from tblRoba where RobaID=";
        string selectUslovDobavljac = @"select * from tblDobavljac where DobavljacID=";
        string selectUslovGarancija = @"select * from tblGarancija where GarancijaID=";
        string selectUslovklijent = @"select * from tblklijent where KlijentID=";
        string selectUslovReklamacija = @"select * from tblReklamacija where ReklamacijaID=";
        string selectUslovClanarina = @"select * from tblClanarina where ClanarinaID=";
        #endregion

        #region Delete sa uslovom
        string KupovinaDelete = @"Delete from tblKupovina where KupovinaID=";
        string VrstaDelete = @"Delete from tblVrsta where VrstaID=";
        string RobaDelete = @"Delete from tblRoba where RobaID=";
        string DobavljacDelete = @"Delete from tblDobavljac where DobavljacID=";
        string GarancijaDelete = @"Delete from tblGarancija where GarancijaID=";
        string klijentDelete = @"Delete from tblklijent where KlijentID=";
        string ReklamacijaDelete = @"Delete from tblReklamacija where ReklamacijaID=";
        string ClanarinaDelete = @"Delete from tblClanarina where ClanarinaID=";
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(dataGridCentralni, klijentSelect);
        }

        private void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable();

                dataAdapter.Fill(dt);
                if (grid != null)
                {
                    grid.ItemsSource = dt.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dt.Dispose();
                dataAdapter.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Neuspešno učitani podaci! Greška: " + ex.Message + "\nStackTrace: " + ex.StackTrace,
                                "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }
        void PopuniFormu(DataGrid grid, string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                cmd.Dispose();
                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(klijentSelect))
                    {
                        FrmKlijent prozorKlijent = new FrmKlijent(azuriraj, red);
                        prozorKlijent.txtIme.Text = citac["ImeKlijenta"].ToString();
                        prozorKlijent.txtPrezime.Text = citac["PrezimeKlijenta"].ToString();
                        prozorKlijent.txtGradKlijenta.Text = citac["GradKlijenta"].ToString();
                        prozorKlijent.txtKontakt.Text = citac["KontaktKlijenta"].ToString();
                        prozorKlijent.txtAdresa.Text = citac["AdresaKlijenta"].ToString();
                        prozorKlijent.txtIDKlijenta.Text = citac["IDKlijenta"].ToString();
                        prozorKlijent.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(KupovinaSelect))
                    {
                        FrmKupovina prozorKupovina = new FrmKupovina(azuriraj, red);
                        prozorKupovina.txtIDKupovine.Text = citac["IDKupovine"].ToString();
                        prozorKupovina.txtVrstaKupovine.Text = citac["VrstaKupovine"].ToString();
                        prozorKupovina.txtBrojRacuna.Text = citac["BrojRacuna"].ToString();
                        prozorKupovina.cbxPopust.IsChecked = (bool)citac["Popust"];
                        prozorKupovina.dtDatum.SelectedDate = (DateTime)citac["Datum"];
                        prozorKupovina.cbIDRobe.SelectedValue = citac["RobaID"].ToString();
                        prozorKupovina.cbIDZaposlenog.SelectedValue = citac["ZaposleniID"].ToString();
                        prozorKupovina.cbIDKlijenta.SelectedValue = citac["KlijentID"].ToString();
                        prozorKupovina.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(VrstaSelect))
                    {
                        FrmVrsta prozorVrsta = new FrmVrsta(azuriraj, red);
                        prozorVrsta.txtVrstaID.Text = citac["IDVrste"].ToString();
                        prozorVrsta.txtImeVrste.Text = citac["ImeVrste"].ToString();                          
                        prozorVrsta.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(RobaSelect))
                    {
                        FrmRoba prozorRoba = new FrmRoba(azuriraj, red);
                        prozorRoba.txtIDRobe.Text = citac["IDRobe"].ToString();
                        prozorRoba.txtNazivRobe.Text = citac["NazivRobe"].ToString();                     
                        prozorRoba.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(DobavljacSelect))
                    {
                        FrmDobavljac prozorDobavljac = new FrmDobavljac(azuriraj, red);
                        prozorDobavljac.txtDobavljacID.Text = citac["ID Dobavljaca"].ToString();
                        prozorDobavljac.txtIme.Text = citac["Ime"].ToString();
                        prozorDobavljac.txtPrezime.Text = citac["Prezime"].ToString();
                        prozorDobavljac.txtImeFirme.Text = citac["ImeFirme"].ToString();
                        prozorDobavljac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(GarancijaSelect))
                    {
                        FrmGarancija prozorGarancija = new FrmGarancija (azuriraj, red);
                        prozorGarancija.txtGarancijaID.Text = citac["IDGarancije"].ToString();
                        prozorGarancija.cbIDZaposlenog.SelectedValue = citac["IDZaposlenog"].ToString();
                        prozorGarancija.cbIDRobe.SelectedValue = citac["IDRobe"].ToString();
                        prozorGarancija.txtTrajanje.Text = citac["TrajanjeGarancije"].ToString();
                        prozorGarancija.dtDatum.SelectedDate = (DateTime)citac["Datum"];
                    
                        prozorGarancija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(ReklamacijaSelect))
                    {
                        FrmReklamacija prozorReklamacija = new FrmReklamacija(azuriraj, red);
                        prozorReklamacija.txtReklamacijaID.Text = citac["IDReklamacije"].ToString();
                        prozorReklamacija.txtOpisReklamacije.Text = citac["OpisReklamacije"].ToString();
                        prozorReklamacija.cbIDZaposlenog.SelectedValue = citac["IDZaposlenog"].ToString();
                        prozorReklamacija.cbIDKlijenta.SelectedValue = citac["IDKlijenta"].ToString();
                        prozorReklamacija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(ClanarinaSelect))
                    {
                        FrmClanarina prozorClanarina = new FrmClanarina(azuriraj, red);
                        prozorClanarina.txtIDClanarine.Text = citac["IDClanarine"].ToString();
                        prozorClanarina.txtOpisClanarine.Text = citac["OpisClanarine"].ToString();
                        prozorClanarina.txtCenaClanarine.Text = citac["CenaClanarine"].ToString();
                        prozorClanarina.txtTrajanjeClanarine.Text = citac["TrajanjeClanarine"].ToString();
                        prozorClanarina.cbVrstaClanarineID.SelectedValue = citac["VrstaClanarineID"].ToString();
                        prozorClanarina.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }
        void ObrisiZapis(DataGrid grid, string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand()
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u nekim drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }



        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(klijentSelect))
            {
                prozor = new FrmKlijent();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, klijentSelect);
            }
            else if (ucitanaTabela.Equals(KupovinaSelect))
            {
                prozor = new FrmKupovina();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, KupovinaSelect);
            }
            else if (ucitanaTabela.Equals(VrstaSelect))
            {
                prozor = new FrmVrsta();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, VrstaSelect);
            }
            else if (ucitanaTabela.Equals(RobaSelect))
            {
                prozor = new FrmRoba();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, RobaSelect);
            }
            else if (ucitanaTabela.Equals(DobavljacSelect))
            {
                prozor = new FrmDobavljac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, DobavljacSelect);
            }
            else if (ucitanaTabela.Equals(GarancijaSelect))
            {
                prozor = new FrmGarancija();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, GarancijaSelect);
            }
            else if (ucitanaTabela.Equals(ReklamacijaSelect))
            {
                prozor = new FrmReklamacija();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, ReklamacijaSelect);
            }
            else if (ucitanaTabela.Equals(ClanarinaSelect))
            {
                prozor = new FrmClanarina();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, ClanarinaSelect);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(klijentSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovklijent);
                UcitajPodatke(dataGridCentralni, klijentSelect);
            }
            else if (ucitanaTabela.Equals(KupovinaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovKupovina);
                UcitajPodatke(dataGridCentralni, KupovinaSelect);
            }
            else if (ucitanaTabela.Equals(VrstaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovVrsta);
                UcitajPodatke(dataGridCentralni, VrstaSelect);
            }
            else if (ucitanaTabela.Equals(RobaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovRoba);
                UcitajPodatke(dataGridCentralni, RobaSelect);
            }
            else if (ucitanaTabela.Equals(DobavljacSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovDobavljac);
                UcitajPodatke(dataGridCentralni, DobavljacSelect);
            }
            else if (ucitanaTabela.Equals(GarancijaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovGarancija);
                UcitajPodatke(dataGridCentralni, GarancijaSelect);
            }
            else if (ucitanaTabela.Equals(ReklamacijaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovReklamacija);
                UcitajPodatke(dataGridCentralni, ReklamacijaSelect);
            }
            else if (ucitanaTabela.Equals(ClanarinaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovClanarina);
                UcitajPodatke(dataGridCentralni, ClanarinaSelect);
            }
        }

        private void btnObrisi_Click_1(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(klijentSelect))
            {
                ObrisiZapis(dataGridCentralni, klijentDelete);
                UcitajPodatke(dataGridCentralni, klijentSelect);
            }
            else if (ucitanaTabela.Equals(KupovinaSelect))
            {
                ObrisiZapis(dataGridCentralni, KupovinaDelete);
                UcitajPodatke(dataGridCentralni, KupovinaSelect);
            }
            else if (ucitanaTabela.Equals(VrstaSelect))
            {
                ObrisiZapis(dataGridCentralni, VrstaDelete);
                UcitajPodatke(dataGridCentralni, VrstaSelect);
            }
            else if (ucitanaTabela.Equals(RobaSelect))
            {
                ObrisiZapis(dataGridCentralni, RobaDelete);
                UcitajPodatke(dataGridCentralni, RobaSelect);
            }
            else if (ucitanaTabela.Equals(DobavljacSelect))
            {
                ObrisiZapis(dataGridCentralni, DobavljacDelete);
                UcitajPodatke(dataGridCentralni, DobavljacSelect);
            }
            else if (ucitanaTabela.Equals(GarancijaSelect))
            {
                ObrisiZapis(dataGridCentralni, GarancijaDelete);
                UcitajPodatke(dataGridCentralni, GarancijaSelect);
            }
            else if (ucitanaTabela.Equals(ReklamacijaSelect))
            {
                ObrisiZapis(dataGridCentralni, ReklamacijaDelete);
                UcitajPodatke(dataGridCentralni, ReklamacijaSelect);
            }
            else if (ucitanaTabela.Equals(ClanarinaSelect))
            {
                ObrisiZapis(dataGridCentralni, ClanarinaDelete);
                UcitajPodatke(dataGridCentralni, ClanarinaSelect);
            }
        }

        private void btnKlijent_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, klijentSelect);
        }

        private void btnKupovina_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, KupovinaSelect);
        }

        private void btnVrsta_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, VrstaSelect);
        }

        private void btnRoba_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, RobaSelect);
        }

        private void btnDobavljac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, DobavljacSelect);
        }

        private void btnGarancija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, GarancijaSelect);
        }

        private void btnReklamacija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, ReklamacijaSelect);
        }

        private void btnClanarina_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, ClanarinaSelect);
        }
    }
}

       
  