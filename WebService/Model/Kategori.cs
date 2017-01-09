using System;
using System.Runtime.Serialization;

namespace WebService.Model
{

    [DataContract]
    public class Kategori
    {
        private long id;
        private String keterangan;
        private long hargaJamPertama;
        private long hargaPerJam;

        [DataMember]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public String Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }

        [DataMember]
        public long HargaJamPertama
        {
            get { return hargaJamPertama; }
            set { hargaJamPertama = value; }
        }

        [DataMember]
        public long HargaPerJam
        {
            get { return hargaPerJam; }
            set { hargaPerJam = value; }
        }
    }
}
