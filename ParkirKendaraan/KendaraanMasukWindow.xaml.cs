using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ParkirKendaraan
{
    /// <summary>
    /// Interaction logic for KendaraanMasukWindow.xaml
    /// </summary>
    public partial class KendaraanMasukWindow : Window
    {

        private Timer timer;
        private MainWindow window;
        private List<String> strings;
        private TransaksiService.Kategori[] kategoriList;

        public KendaraanMasukWindow(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void UpdateText(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke((Action)delegate
            {
                txWaktuMasuk.Text = DateTime.Now.ToString();
            });
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += UpdateText;
            timer.Start();
            txWaktuMasuk.Text = DateTime.Now.ToString();

            strings = new List<String>();
            cbKategori.ItemsSource = strings;

            kategoriList = Services.Instance.TransaksiClient.FetchAllKategori();
            foreach (TransaksiService.Kategori kategori in kategoriList)
            {
                strings.Add(kategori.Keterangan);
            }
        }

        private long getIdKategori(String kategoriString)
        {
            long idKategori = -1;
            foreach (TransaksiService.Kategori kategori in kategoriList)
            {
                if (kategori.Keterangan.Equals(kategoriString, StringComparison.CurrentCultureIgnoreCase))
                {
                    idKategori = kategori.Id;
                    break;
                }
            }
            return idKategori;
        }

        private void btMasukkan_Click(object sender, RoutedEventArgs e)
        {
            if(cbKategori.SelectedIndex == -1)
            {
                MessageBox.Show("Silahkan pilih kategori.", "Perhatian", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if(String.IsNullOrEmpty(txNoPolisi.Text))
            {
                MessageBox.Show("Silahkan masukkan nomor polisi.", "Perhatian", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            String noPol = txNoPolisi.Text;
            long idKategori = getIdKategori(cbKategori.SelectedItem as String);
            DateTime dateNow = DateTime.Now;

            if(Services.Instance.TransaksiClient.InsertNewTransaksi(noPol, idKategori, dateNow))
            {
                MessageBox.Show("Insert data berhasil.", "Perhatian", MessageBoxButton.OK, MessageBoxImage.None);
                window.PopulateGridView();
                Close();
            }
            else
            {
                MessageBox.Show("Insert data gagal.", "Perhatian", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btBatal_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            base.OnPreviewKeyDown(e);
        }
    }
}
