﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkirKendaraan.UserService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/WebService.Model")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NamaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nama {
            get {
                return this.NamaField;
            }
            set {
                if ((object.ReferenceEquals(this.NamaField, value) != true)) {
                    this.NamaField = value;
                    this.RaisePropertyChanged("Nama");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsUserExist", ReplyAction="http://tempuri.org/IUserService/IsUserExistResponse")]
        bool IsUserExist(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsUserExist", ReplyAction="http://tempuri.org/IUserService/IsUserExistResponse")]
        System.Threading.Tasks.Task<bool> IsUserExistAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/FetchUsers", ReplyAction="http://tempuri.org/IUserService/FetchUsersResponse")]
        ParkirKendaraan.UserService.User[] FetchUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/FetchUsers", ReplyAction="http://tempuri.org/IUserService/FetchUsersResponse")]
        System.Threading.Tasks.Task<ParkirKendaraan.UserService.User[]> FetchUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        bool DeleteUser(long id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        System.Threading.Tasks.Task<bool> DeleteUserAsync(long id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        bool UpdateUser(long id, string nama, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserAsync(long id, string nama, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/InsertUser", ReplyAction="http://tempuri.org/IUserService/InsertUserResponse")]
        bool InsertUser(string nama, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/InsertUser", ReplyAction="http://tempuri.org/IUserService/InsertUserResponse")]
        System.Threading.Tasks.Task<bool> InsertUserAsync(string nama, string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : ParkirKendaraan.UserService.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<ParkirKendaraan.UserService.IUserService>, ParkirKendaraan.UserService.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsUserExist(string username, string password) {
            return base.Channel.IsUserExist(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> IsUserExistAsync(string username, string password) {
            return base.Channel.IsUserExistAsync(username, password);
        }
        
        public ParkirKendaraan.UserService.User[] FetchUsers() {
            return base.Channel.FetchUsers();
        }
        
        public System.Threading.Tasks.Task<ParkirKendaraan.UserService.User[]> FetchUsersAsync() {
            return base.Channel.FetchUsersAsync();
        }
        
        public bool DeleteUser(long id) {
            return base.Channel.DeleteUser(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteUserAsync(long id) {
            return base.Channel.DeleteUserAsync(id);
        }
        
        public bool UpdateUser(long id, string nama, string username, string password) {
            return base.Channel.UpdateUser(id, nama, username, password);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserAsync(long id, string nama, string username, string password) {
            return base.Channel.UpdateUserAsync(id, nama, username, password);
        }
        
        public bool InsertUser(string nama, string username, string password) {
            return base.Channel.InsertUser(nama, username, password);
        }
        
        public System.Threading.Tasks.Task<bool> InsertUserAsync(string nama, string username, string password) {
            return base.Channel.InsertUserAsync(nama, username, password);
        }
    }
}
