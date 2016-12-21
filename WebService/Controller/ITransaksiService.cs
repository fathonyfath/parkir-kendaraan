using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebService.Model;

namespace WebService.Controller
{
    [ServiceContract]
    public interface ITransaksiService
    {
        [OperationContract]
        List<Transaksi> FetchAllTransaksi();

        [OperationContract]
        bool InsertNewTransaksi(String noPolisi, long idKategori, DateTime tanggalMasuk);

        [OperationContract]
        bool UpdateTransaksi(long id, String noPolisi, long idKategori, DateTime tanggalMasuk, DateTime tanggalKeluar);

        [OperationContract]
        bool DeleteTransaksi(long id);

        [OperationContract]
        Kategori FetchKategori(long idKategori);

        [OperationContract]
        List<Kategori> FetchAllKategori();
    }
}
