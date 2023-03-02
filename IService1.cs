using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PO5_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
         bool IsRegUser(string _username, string _name, string _surname, string _dob, string _email, string _password);

        [OperationContract]
        User Login(string email, string password);

        [OperationContract]
        User GetUser(int Id);

        [OperationContract]
        bool EditUser(int Id, string username, string name, string email, string dob);

        [OperationContract]
        Product GetProduct(int Id);

        [OperationContract]
        bool EditProduct(int Id ,string _name, string price, string _description, int _Quantity,
        string _publishedDate, string _authorName, string _img);

        [OperationContract]
        List<Product>GetProductList();

        [OperationContract]

        List<SHOPPING_CART> GetCARTList(int U_ID);

        [OperationContract]
        bool EditCart(int _UserID, int _ProductID, int _Quantinty);


        [OperationContract]
        bool AddToCart(int _UserID, int _ProductID, int _Quantinty);

        [OperationContract]
        bool RemoveItemCart(int _User, int _Product);

        [OperationContract]
         bool Checkout(int _ProductID, int Quantity);

        [OperationContract]
        int NumberItemsIncart(int _UserId);

        [OperationContract]
        bool CheckCart(int _UserID, int _ProductID);


        [OperationContract]
        bool RemoveBook(int _ProductID);

        [OperationContract]
        bool AddBook(string _name, string price, string _description, int _Quantity, string _publishedDate, string _authorName, string _img, string _category, string language);


         [OperationContract]
          bool CreateInvoice(int _UserId, int _OrderId, string _PointsUsed, string _TotalCost, string _InvoiceDate, string _DueDate, string _Address, string _Address2, string _Address3, string _ShippingCost, int _status, string _VAT,string discount);
        
        
         [OperationContract]
         List<Invoice>GetPendingOrdersOrInvoice(int _UserID, int _Quertype);


        [OperationContract]
        List<User> GetUserList();

        [OperationContract]
        bool addOrder(int _UserID, string _ProductCost, string _OrderID, int _quantity ,string _Prname);

        [OperationContract]
        List<PurchaseInfo> GetOderLIst(int _OrderID);


        [OperationContract]
        Invoice GetInv(int _UserId, int _OrderID);

        [OperationContract]
        bool EditUserAdmin(int Id, string username, string name, string lastname, string usertype, string email, string dob, string points, int active);

        [OperationContract]
        bool EditInvoice(int _id);

        [OperationContract]

        int Reports(int _type);



        [OperationContract]
        List<Product> GetBookList(string _m);

    }


}
