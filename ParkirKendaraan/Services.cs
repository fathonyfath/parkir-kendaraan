namespace ParkirKendaraan
{
    public class Services
    {
        private UserService.UserServiceClient userClient;
        private TransaksiService.TransaksiServiceClient transaksiClient;

        private static Services instance;

        public static Services Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Services();
                }
                return instance;
            }
        }

        private Services()
        {
            userClient = new UserService.UserServiceClient();
            transaksiClient = new TransaksiService.TransaksiServiceClient();
        }

        public UserService.UserServiceClient UserClient
        {
            get { return userClient; }
        }

        public TransaksiService.TransaksiServiceClient TransaksiClient
        {
            get { return transaksiClient; }
        }
    }
}
