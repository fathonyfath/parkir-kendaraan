using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ParkirKendaraan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<TransaksiRow> transaksiRows;

        public MainWindow()
        {
            InitializeComponent();
            transaksiRows = new ObservableCollection<TransaksiRow>();
        }

        private void OnFormLoad(object sender, RoutedEventArgs e)
        {
            PopulateGridView();
            dtParkiran.ItemsSource = transaksiRows;
        }

        public void PopulateGridView()
        {
            LoadingWindow.DoWorkWithModal(progress => 
            {
                this.Dispatcher.Invoke((Action)delegate
                {
                    transaksiRows.Clear();
                });
                TransaksiService.Transaksi[] transaksiList = Services.Instance.TransaksiClient.FetchAllTransaksi();
                foreach (TransaksiService.Transaksi transaksi in transaksiList)
                {
                    TransaksiService.Kategori kategori = Services.Instance.TransaksiClient.FetchKategori(transaksi.IdKategori);
                    TransaksiRow row = new TransaksiRow()
                    {
                        IdTransaksi = (int)transaksi.Id,
                        NomorPolisi = transaksi.NoPolisi,
                        TanggalMasuk = transaksi.TanggalMasuk.ToString(),
                        JenisKendaraan = kategori.Keterangan
                    };
                    bool sudahKeluar = transaksi.TanggalKeluar.HasValue;
                    long hargaJamPertama = kategori.HargaJamPertama;
                    long hargaPerJam = kategori.HargaPerJam;
                    DateTime last;

                    if (sudahKeluar)
                    {
                        row.TanggalKeluar = transaksi.TanggalKeluar.Value.ToString();
                        last = transaksi.TanggalKeluar.Value;
                        row.Status = "Sudah Keluar";
                    }
                    else
                    {
                        row.TanggalKeluar = "-";
                        last = DateTime.Now;
                        row.Status = "Belum Keluar";
                    }

                    TimeSpan difference = last - transaksi.TanggalMasuk;
                    double hours = difference.TotalHours;
                    int hour = difference.Hours;
                    int minute = difference.Minutes;
                    row.Durasi = String.Format("{0} jam {1} menit", hour, minute);

                    hours = Math.Ceiling(hours);
                    if (hours == 0.0) hours = hours + 0.5;
                    double biaya = (hargaJamPertama) + ((hours - 1) * hargaPerJam);
                    row.Biaya = String.Format("Rp. {0},-", biaya);

                    this.Dispatcher.Invoke((Action)delegate
                    {
                        transaksiRows.Add(row);
                    });
                }
            });
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            PopulateGridView();
        }

        private void btnDataBaru_Click(object sender, RoutedEventArgs e)
        {
            KendaraanMasukWindow kendaraanMasuk = new KendaraanMasukWindow(this);
            kendaraanMasuk.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            KendaraanKeluarWindow kendaraanKeluar = new KendaraanKeluarWindow(this);
            kendaraanKeluar.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            Close();
        }
    }
}
