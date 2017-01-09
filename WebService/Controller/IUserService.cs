using System;
using System.Collections.Generic;
using System.ServiceModel;
using WebService.Model;

namespace WebService.Controller
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool IsUserExist(String username, String password);

        [OperationContract]
        List<User> FetchUsers();

        [OperationContract]
        bool DeleteUser(long id);

        [OperationContract]
        bool UpdateUser(long id, String nama, String username, String password);

        [OperationContract]
        bool InsertUser(String nama, String username, String password);
    }

    
}
