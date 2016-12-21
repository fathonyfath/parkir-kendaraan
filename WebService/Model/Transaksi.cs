using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model
{

    [DataContract]
    public class Transaksi
    {
        private long id;
        private String noPolisi;
        private long idKategori;
        private DateTime tanggalMasuk;
        private DateTime? tanggalKeluar;

        [DataMember]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public String NoPolisi
        {
            get { return noPolisi; }
            set { noPolisi = value; }
        }

        [DataMember]
        public long IdKategori
        {
            get { return idKategori; }
            set { idKategori = value; }
        }

        [DataMember]
        public DateTime TanggalMasuk
        {
            get { return tanggalMasuk; }
            set { tanggalMasuk = value; }
        }

        [DataMember]
        public DateTime? TanggalKeluar
        {
            get { return tanggalKeluar; }
            set { tanggalKeluar = value; }
        }
    }
}
