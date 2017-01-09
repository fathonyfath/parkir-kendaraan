using System;

namespace ParkirKendaraan
{
    public class TransaksiRow
    {
        private int idTransaksi;
        private String nomorPolisi;
        private String tanggalMasuk;
        private String tanggalKeluar;
        private String jenisKendaraan;
        private String durasi;
        private String biaya;
        private String status;

        public int IdTransaksi
        {
            get { return idTransaksi; }
            set { idTransaksi = value; }
        }

        public String NomorPolisi
        {
            get { return nomorPolisi; }
            set { nomorPolisi = value; }
        }

        public String TanggalMasuk
        {
            get { return tanggalMasuk; }
            set { tanggalMasuk = value; }
        }

        public String TanggalKeluar
        {
            get { return tanggalKeluar; }
            set { tanggalKeluar = value; }
        }

        public String JenisKendaraan
        {
            get { return jenisKendaraan; }
            set { jenisKendaraan = value; }
        }

        public String Durasi
        {
            get { return durasi; }
            set { durasi = value; }
        }

        public String Biaya
        {
            get { return biaya; }
            set { biaya = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
