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
    /// Interaction logic for FrmReklamacija.xaml
    /// </summary>
    public partial class FrmReklamacija : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmReklamacija()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
        }
        //public FrmReklamacija(bool azuriraj, DataRowView pomocniRed)
        //{
        //    InitializeComponent();
        //    konekcija = kon.KreirajKonekciju();
        //    txtReklamacijaID.Focus();
        //    this.azuriraj = azuriraj;
        //    this.pomocniRed = pomocniRed;
        //}

        public FrmReklamacija(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
           txtReklamacijaID.Focus();  // Iskomentariši ili ukloni ovu liniju
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
            

                konekcija.Open();
                string vratiZaposlene = @"select ZaposleniID, Ime, Prezime, JMBG, AdresaZaposlenog, GradZaposlenog, KontaktZaposlenog, PozicijaZaposlenog, KorIme, Lozinka from tblZaposleni";

                DataTable dtZaposleni = new DataTable();
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlene, konekcija);
                daZaposleni.Fill(dtZaposleni);
                cbIDZaposlenog.ItemsSource = dtZaposleni.DefaultView;
                cbIDZaposlenog.DisplayMemberPath = "ZaposleniID";
                daZaposleni.Dispose();
                dtZaposleni.Dispose();

                
                string vratiKlijenta = @"select KlijentID, Ime, Prezime, GradKlijenta, KontaktKlijenta, AdresaKlijenta from tblklijent";

                DataTable dtKlijent = new DataTable();
                SqlDataAdapter daKlijent = new SqlDataAdapter(vratiKlijenta, konekcija);
                daKlijent.Fill(dtKlijent);
                cbIDKlijenta.ItemsSource = dtKlijent.DefaultView;
                cbIDKlijenta.DisplayMemberPath = "KlijentID";
                daKlijent.Dispose();
                dtKlijent.Dispose();

                konekcija.Close();

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
        //private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        konekcija.Open();
        //        SqlCommand cmd = new SqlCommand
        //        {
        //            Connection = konekcija
        //        };
        //        cmd.Parameters.Add("@ReklamacijaID", System.Data.SqlDbType.Int).Value = txtReklamacijaID.Text;
        //        cmd.Parameters.Add("@OpisReklamacije", System.Data.SqlDbType.Int).Value = txtOpisReklamacije.Text;
        //        cmd.Parameters.Add("@ZaposleniID", System.Data.SqlDbType.Int).Value = cbIDZaposlenog.SelectedValue;
        //        cmd.Parameters.Add("@KlijentID", System.Data.SqlDbType.Int).Value = cbIDKlijenta.SelectedValue;               
        //        if (this.azuriraj)
        //        {
        //            DataRowView red = this.pomocniRed;
        //            cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
        //            cmd.CommandText = @"Update Reklamacija
        //                                Set ReklamacijaID = @IDReklamacije, OpisReklamacije= @OpisReklamacije, ZaposleniID = @IDZaposlenog, KlijentID = @IDKlijenta
        //                                where ReklamacijaID = @id";
        //            this.pomocniRed = null;
        //        }
        //        else
        //        {
        //            cmd.CommandText = @"insert into tblReklamacija (ReklamacijaID, OpisReklamacije, ZaposleniID, KlijentID)
        //                            values(@ReklamacijaID, @OpisReklamacije, @ZaposleniID, @KlijentID)";
        //        }
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //        this.Close();
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show($"SQL greška: {ex.Message}", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    catch (FormatException ex)
        //    {
        //        MessageBox.Show($"Greška prilikom konverzije podataka: {ex.Message}", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    finally
        //    {
        //        if (konekcija != null)
        //        {
        //            konekcija.Close();
        //        }
        //        azuriraj = false;
        //    }
        //}

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@ReklamacijaID", SqlDbType.Int).Value = txtReklamacijaID.Text;
                cmd.Parameters.Add("@OpisReklamacije", SqlDbType.NVarChar).Value = txtOpisReklamacije.Text;
                cmd.Parameters.Add("@ZaposleniID", SqlDbType.Int).Value = cbIDZaposlenog.SelectedValue;
                cmd.Parameters.Add("@KlijentID", SqlDbType.Int).Value = cbIDKlijenta.SelectedValue;

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblReklamacija
                                Set ReklamacijaID = @ReklamacijaID, OpisReklamacije = @OpisReklamacije, ZaposleniID = @ZaposleniID, KlijentID = @KlijentID
                                where ReklamacijaID = @id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblReklamacija (ReklamacijaID, OpisReklamacije, ZaposleniID, KlijentID)
                                values(@ReklamacijaID, @OpisReklamacije, @ZaposleniID, @KlijentID)";
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
  
    

