using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebService.Model;
using WebService.Util;

namespace WebService.Controller
{
    class TransaksiService : ITransaksiService
    {
        public bool DeleteTransaksi(long id)
        {
            String query = String.Format(@"DELETE FROM transaksi WHERE id={0};", id);
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            int executeDelete = command.ExecuteNonQuery();
            return executeDelete == 1;
        }

        public List<Kategori> FetchAllKategori()
        {
            List<Kategori> kategoriList = new List<Kategori>();

            String query = String.Format(@"SELECT id, keterangan, hargajampertama, hargaperjam FROM kategori;");
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Kategori kategori = new Kategori()
                    {
                        Id = reader.GetInt32(0),
                        Keterangan = reader.GetString(1),
                        HargaJamPertama = reader.GetInt32(2),
                        HargaPerJam = reader.GetInt32(3)
                    };
                    kategoriList.Add(kategori);
                }
            }
            reader.Close();

            return kategoriList;
        }

        public List<Transaksi> FetchAllTransaksi()
        {
            List<Transaksi> transaksiList = new List<Transaksi>();

            String query = String.Format(@"SELECT id, nomor_polisi, id_kategori, tanggal_in, tanggal_out FROM transaksi;");
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Transaksi transaksi = new Transaksi()
                    {
                        Id = reader.GetInt32(0),
                        NoPolisi = reader.GetString(1),
                        IdKategori = reader.GetInt32(2),
                        TanggalMasuk = reader.GetDateTime(3)
                    };

                    if(reader.IsDBNull(4))
                    {
                        transaksi.TanggalKeluar = null;
                    }
                    else
                    {
                        transaksi.TanggalKeluar = reader.GetDateTime(4);
                    }

                    transaksiList.Add(transaksi);
                }
            }
            reader.Close();

            return transaksiList;
        }

        public Kategori FetchKategori(long idKategori)
        {
            Kategori kategori = null;

            String query = String.Format(@"SELECT id, keterangan, hargajampertama, hargaperjam FROM kategori WHERE id={0};", idKategori);
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    kategori = new Kategori()
                    {
                        Id = reader.GetInt32(0),
                        Keterangan = reader.GetString(1),
                        HargaJamPertama = reader.GetInt32(2),
                        HargaPerJam = reader.GetInt32(3)
                    };
                }
            }
            reader.Close();

            return kategori;
        }

        public bool InsertNewTransaksi(string noPolisi, long idKategori, DateTime tanggalMasuk)
        {
            String query = String.Format(@"INSERT INTO transaksi (nomor_polisi, id_kategori, tanggal_in) VALUES ('{0}', {1}, '{2}');",
                noPolisi, idKategori, tanggalMasuk.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            int executeInsert = command.ExecuteNonQuery();
            return executeInsert == 1;
        }

        public bool UpdateTransaksi(long id, string noPolisi, long idKategori, DateTime tanggalMasuk, DateTime tanggalKeluar)
        {
            String query = String.Format(@"UPDATE transaksi SET nomor_polisi='{0}', id_kategori={1}, tanggal_in='{2}', 
                                        tanggal_out='{3}' WHERE id={4};", noPolisi, idKategori,
                                        tanggalMasuk.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                        tanggalKeluar.ToString("yyyy-MM-dd HH:mm:ss.fff"), id);
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            int executeUpdate = command.ExecuteNonQuery();
            return executeUpdate == 1;
        }
    }
}
