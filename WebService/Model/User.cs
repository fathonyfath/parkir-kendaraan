using System;
using System.Runtime.Serialization;

namespace WebService.Model
{
    [DataContract]
    public class User
    {
        private long id;
        private String nama;
        private String username;
        private String password;

        [DataMember]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public String Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        [DataMember]
        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
