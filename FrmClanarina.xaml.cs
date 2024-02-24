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
    /// Interaction logic for FrmClanarina.xaml
    /// </summary>
    public partial class FrmClanarina : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmClanarina()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
        }
        public FrmClanarina(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIDClanarine.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vratiVrste = @"select VrstaID, ImeVrste from tbl_Vrsta";
                DataTable dtVrsta = new DataTable();
                SqlDataAdapter daVrsta = new SqlDataAdapter(vratiVrste, konekcija);
                daVrsta.Fill(dtVrsta);
                cbVrstaClanarineID.ItemsSource = dtVrsta.DefaultView;
                cbVrstaClanarineID.DisplayMemberPath = "ClanarinaID";
                daVrsta.Dispose();
                dtVrsta.Dispose();


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
                cmd.Parameters.Add("@IDClanarine", System.Data.SqlDbType.Int).Value = txtIDClanarine.Text;
                cmd.Parameters.Add("@Opis", System.Data.SqlDbType.Int).Value = txtOpisClanarine.Text;
                cmd.Parameters.Add("@Cena", System.Data.SqlDbType.Int).Value = txtCenaClanarine.Text;
                cmd.Parameters.Add("@VrstaTreninga", System.Data.SqlDbType.Int).Value = txtVrstaTrng.Text;
                cmd.Parameters.Add("@Trajanje", System.Data.SqlDbType.Int).Value = txtTrajanjeClanarine.Text;
                cmd.Parameters.Add("@Vrsta", System.Data.SqlDbType.Int).Value = cbVrstaClanarineID.SelectedValue;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblClanarina
                                        Set ClanarinaID = @IDClanarine, Opis = @Opis, Cena = @Cena, VrstaTrng = @VrstaTreninga, Trajanje = @Trajanje, VrstaID = @VrstaID
                                        where ClanarinaID = @id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblClanarina(ClanarinaID, Opis, Cena, VrstaTrng, Trajanje, VrstaID)
                                    values(@IDClanarine, @Opis, @Cena, @VrstaTreninga, @Trajanje, @Vrsta)";
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





