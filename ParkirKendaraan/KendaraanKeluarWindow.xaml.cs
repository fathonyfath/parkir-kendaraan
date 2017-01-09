using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace ParkirKendaraan
{
    /// <summary>
    /// Interaction logic for KendaraanKeluarWindow.xaml
    /// </summary>
    public partial class KendaraanKeluarWindow : Window
    {

        private MainWindow window;
        private Timer timer;
        private List<String> strings;
        private TransaksiService.Transaksi[] transaksiList;

        private DateTime? transaksiDate;
        private TransaksiService.Kategori kategori;
        private TransaksiService.Transaksi transaksi;

        public KendaraanKeluarWindow(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += UpdateText;
            timer.Start();
            txWaktuKeluar.Text = DateTime.Now.ToString();

            strings = new List<String>();
            cbIdTransaksi.ItemsSource = strings;

            transaksiList = Services.Instance.TransaksiClient.FetchAllTransaksi();
            foreach (TransaksiService.Transaksi transaksi in transaksiList)
            {
                if (!transaksi.TanggalKeluar.HasValue)
                {
                    strings.Add(String.Format("{0}", transaksi.NoPolisi));
                }
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
        }

        private void UpdateText(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke((Action)delegate
            {
                txWaktuKeluar.Text = DateTime.Now.ToString();

                if (transaksiDate.HasValue)
                {
                    DateTime last = DateTime.Now;
                    TimeSpan difference = last - transaksiDate.Value;
                    double hours = difference.TotalHours;
                    int hour = difference.Hours;
                    int minute = difference.Minutes;
                    String durasiString = String.Format("{0} jam {1} menit", hour, minute);
                    txDurasi.Text = durasiString;

                    hours = Math.Ceiling(hours);
                    if (hours == 0.0) hours = hours + 0.5;
                    double biaya = (kategori.HargaJamPertama) + ((hours - 1) * kategori.HargaPerJam);
                    String biayaString = String.Format("Rp. {0},-", biaya);
                    txBiaya.Text = biayaString;
                }
            });
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransaksiService.Transaksi transaksiData = null;
            foreach (TransaksiService.Transaksi transaksi in transaksiList)
            {
                if (transaksi.NoPolisi.Equals((String)cbIdTransaksi.SelectedItem, StringComparison.CurrentCultureIgnoreCase)) transaksiData = transaksi;
            }
            kategori = Services.Instance.TransaksiClient.FetchKategori(transaksiData.IdKategori);

            txNoPolisi.Text = transaksiData.NoPolisi;
            txKategori.Text = kategori.Keterangan;
            txWaktuMasuk.Text = transaksiData.TanggalMasuk.ToString();
            transaksiDate = transaksiData.TanggalMasuk;
            transaksi = transaksiData;
        }

        private void btBatal_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btUpdateData_Click(object sender, RoutedEventArgs e)
        {
            if(transaksi == null)
            {
                MessageBox.Show("Pilih nomor transaksi.", "Perhatian", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            bool result = Services.Instance.TransaksiClient.UpdateTransaksi(transaksi.Id, transaksi.NoPolisi, transaksi.IdKategori, transaksi.TanggalMasuk, DateTime.Now);
            if(result)
            {
                MessageBox.Show("Update data berhasil.", "Perhatian", MessageBoxButton.OK, MessageBoxImage.None);
                window.PopulateGridView();
                Close();
            }
            else
            {
                MessageBox.Show("Update data gagal.", "Perhatian", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
