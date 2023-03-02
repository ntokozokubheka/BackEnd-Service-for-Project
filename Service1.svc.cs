using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PO5_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public bool IsRegUser(string _username, string _name, string _surname, string _dob, string _email, string _password)
        {
            // Created a null value for this 

            string a = "0";
            int b = 1;
            string type = "CU";
            if (_dob == " ")
            {
                var NewUser = new User

                {

                    Username = _username,
                    U_name = _name,
                    U_surname = _surname,
                    U_email = _email,
                    U_password = _password,
                    U_dob = Convert.ToDateTime(_dob),
                    U_PointsValue = a,
                    U_active = b,
                    U_type = type,

                };


                db.Users.InsertOnSubmit(NewUser);

                try
                {
                    db.SubmitChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }

            }
            else
            {
                var NewUser = new User
                {
                    Username = _username,
                    U_name = _name,
                    U_surname = _surname,
                    U_email = _email,
                    U_password = _password,
                    U_dob = Convert.ToDateTime(_dob),
                    U_PointsValue = a,
                    U_active = b,
                    U_type = type,


                };

                db.Users.InsertOnSubmit(NewUser);

                try
                {
                    db.SubmitChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return false;

                }

            }

        }

        public User Login(string email, string password)
        {
            dynamic user = (from u in db.Users
                            where u.U_email.Equals(email) &&
                            u.U_password.Equals(password)

                            select u).FirstOrDefault();

            return user;
        }
        public User GetUser(int Id)
        {

            var _user = (from u in db.Users
                         where u.Id.Equals(Id)

                         select u).FirstOrDefault();





            return _user;

        }

        public bool EditUser(int Id, string username, string name, string email, string dob)
        {

            var eduser = (from u in db.Users
                          where u.Id.Equals(Id)


                          select u).FirstOrDefault();


            eduser.Username = username;
            eduser.U_name = name;
            eduser.U_email = email;

            if (dob != "")
            {

                eduser.U_dob = Convert.ToDateTime(dob);

            }

            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }




        }

        public Product GetProduct(int Id)
        {

            var Prodct = (from u in db.Products
                          where u.Id.Equals(Id)

                          select u).FirstOrDefault();

            return Prodct;

        }

        public bool EditProduct(int Id, string _name, string price, string _description, int _Quantity,
         string _publishedDate, string _authorName, string _img)
        {
            var edProd = (from u in db.Products
                          where u.Id.Equals(Id)


                          select u).FirstOrDefault();


            edProd.P_price = price;
            edProd.P_name = _name;
            edProd.P_description_ = _description;
            edProd.P_AuthorName = _authorName;
            edProd.P_Img = _img;
            edProd.P_Quantity = _Quantity;
            edProd.P_PublishedDate = Convert.ToDateTime(_publishedDate);

            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }

        }

        public List<Product> GetProductList()
        {
            var TempL = new List<Product>();

            dynamic dataQuery = (

                from p in db.Products
                select p).DefaultIfEmpty();

            foreach (Product m in dataQuery)
            {

                TempL.Add(m);
            }

            return TempL;
        }

        public List<SHOPPING_CART> GetCARTList(int U_ID)
        {

            var TempL = new List<SHOPPING_CART>();

            var dataQuery = (
                from p in db.SHOPPING_CARTs
                where p.User_ID.Equals(U_ID)
                select p).DefaultIfEmpty();

            foreach (SHOPPING_CART m in dataQuery)
            {
                TempL.Add(m);
            }

            return TempL;

        }

        public bool EditCart(int _UserID, int _ProductID, int _Quantinty)
        {


            var edProd = (from u in db.SHOPPING_CARTs
                          where u.User_ID.Equals(_UserID) && u.Product_ID.Equals(_ProductID)


                          select u).FirstOrDefault();


            edProd.Order_Quantity = _Quantinty;


            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }


        }

        public bool RemoveItemCart(int _User, int _Product)
        {

            var edProd = (from u in db.SHOPPING_CARTs
                          where u.User_ID.Equals(_User) && u.Product_ID.Equals(_Product)

                          select u).FirstOrDefault();

            db.SHOPPING_CARTs.DeleteOnSubmit(edProd);


            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public bool Checkout(int _ProductID, int Quantity)
        {

            var edProd = (from u in db.Products
                          where u.Id.Equals(_ProductID)

                          select u).FirstOrDefault();

            edProd.P_Quantity = edProd.P_Quantity - Quantity;

            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }



        }

        public bool AddToCart(int _UserID, int _ProductID, int _Quantinty)
        {

            var NewCart = new SHOPPING_CART
            {

                User_ID = _UserID,
                Product_ID = _ProductID,
                Order_Quantity = _Quantinty,


            };

            db.SHOPPING_CARTs.InsertOnSubmit(NewCart);

            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;

            }

        }

        public int NumberItemsIncart(int _UserId)
        {

            int a = 0;
            var TempL = new List<SHOPPING_CART>();

            var dataQuery = (
                from p in db.SHOPPING_CARTs
                where p.User_ID.Equals(_UserId)
                select p).DefaultIfEmpty();

            foreach (SHOPPING_CART m in dataQuery)
            {

                a += 1;
            }

            if (dataQuery != null)
            {
                return a;
            }
            else
            {

                return 0;
            }
        }

        public bool CheckCart(int _UserID, int _ProductID)
        {

            var edProd = (from u in db.SHOPPING_CARTs
                          where u.User_ID.Equals(_UserID) && u.Product_ID.Equals(_ProductID)


                          select u).FirstOrDefault();

            if (edProd == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool RemoveBook(int _ProductID)
        {

            var edProd = (from u in db.Products
                          where u.Id.Equals(_ProductID)

                          select u).FirstOrDefault();

            db.Products.DeleteOnSubmit(edProd);


            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public bool AddBook(string _name, string price, string _description, int _Quantity,
        string _publishedDate, string _authorName, string _img, string _category, string language)

        {
            // Created a null value for this 



            var NewBook = new Product
            {

                P_name = _name,
                P_price = price,
                P_description_ = _description,
                P_publisher = _publishedDate,
                P_Img = _img,
                P_Quantity = _Quantity,
                P_AuthorName = _authorName,
                P_category = _category,
                P_Language = language,

            };


            db.Products.InsertOnSubmit(NewBook);

            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }


        }

        public bool CreateInvoice(int _UserId, int _OrderId, string _PointsUsed, string _TotalCost, string _InvoiceDate, string _DueDate, string _Address, string _Address2, string _Address3, string _ShippingCost, int _status, string _VAT, string discount)
        {




            var NewInvoice = new Invoice
            {

                User_Id = _UserId,
                Order_ID = _OrderId,
                PointsUsed = _PointsUsed,
                Total = _TotalCost,
                InvoiceDate = Convert.ToDateTime(_InvoiceDate),
                DueDate = Convert.ToDateTime(_DueDate),
                Adressline_1 = _Address,
                Adressline_2 = _Address2,
                Adressline_3 = _Address3,
                VAT = _VAT,
                Status = _status,
                DiscountRecieved = discount,

            };

            db.Invoices.InsertOnSubmit(NewInvoice);

            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }




        }

        public List<Invoice> GetPendingOrdersOrInvoice(int _UserID, int _Quertype)
        {
            int z = 0;

            var TempL = new List<Invoice>();
            if (_Quertype == 1)
            {


                dynamic dataQuery = (

                    from p in db.Invoices

                    where p.User_Id.Equals(_UserID)
                    select p).DefaultIfEmpty();

                foreach (Invoice i in dataQuery)
                {
                    TempL.Add(i);
                }

                return TempL;
            }

            if (_Quertype == 2)
            {



                dynamic dataQuery = (

                    from p in db.Invoices

                    where p.Status.Equals(z)

                    select p).DefaultIfEmpty();

                foreach (Invoice i in dataQuery)
                {

                    TempL.Add(i);
                }

                return TempL;

            } /* return all invoices */
            else
            {


                dynamic dataQuery = (

                from p in db.Invoices

                select p).DefaultIfEmpty();

                foreach (Invoice i in dataQuery)
                {
                    TempL.Add(i);
                }



                return TempL;

            }




        }

        public List<User> GetUserList()


        {

            var TempL = new List<User>();
            dynamic dataQuery = (

                from p in db.Users


                select p).DefaultIfEmpty();

            foreach (User i in dataQuery)
            {
                TempL.Add(i);
            }



            return TempL;



        }

        public bool addOrder(int _UserID, string _ProductCost, string _OrderID, int _quantity, string _Prname)
        {

            var NewOrder = new PurchaseInfo
            {

                Invoice_Id = _quantity,
                Order_ID = _OrderID,
                ProductCost = _ProductCost,
                ProductName = _Prname,
                User_Id = _UserID,

            };

            db.PurchaseInfos.InsertOnSubmit(NewOrder);
            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }


        }

        public List<PurchaseInfo> GetOderLIst(int _OrderID)
        {


            var TempL = new List<PurchaseInfo>();
            dynamic dataQuery = (

                from p in db.PurchaseInfos
                where p.Order_ID.Equals(_OrderID)

                select p).DefaultIfEmpty();

            foreach (PurchaseInfo i in dataQuery)
            {
                TempL.Add(i);
            }

            return TempL;

        }

        public Invoice GetInv(int _UserId, int _OrderID)
        {
            var edProd = (from u in db.Invoices
                          where u.User_Id.Equals(_UserId) && u.Order_ID.Equals(_OrderID)


                          select u).FirstOrDefault();


            return edProd;
        }



        public bool EditUserAdmin(int Id, string username, string name, string lastname, string usertype, string email, string dob, string points, int active)
        {
            var eduser = (from u in db.Users
                          where u.Id.Equals(Id)


                          select u).FirstOrDefault();


            eduser.Username = username;
            eduser.U_name = name;
            eduser.U_surname = lastname;
            eduser.U_email = email;
            eduser.U_active = active;
            eduser.U_dob = Convert.ToDateTime(dob);
            eduser.U_type = usertype;
            eduser.U_PointsValue = points;


            if (dob != "")
            {

                eduser.U_dob = Convert.ToDateTime(dob);

            }

            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }

        }

        public bool EditInvoice(int _id)
        {


            int a = 1;
            var eduser = (from u in db.Invoices
                          where u.Id.Equals(_id)


                          select u).FirstOrDefault();

            eduser.Status = a;


            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }

        }

        public int Reports(int _type)
        {

            int a = 1;


            if (_type == 1)
            {
                var TempL = new List<Invoice>();

                dynamic dataQuery = (

                    from p in db.Invoices


                    select p).DefaultIfEmpty();

                foreach (Invoice i in dataQuery)
                {


                    a += 1;

                }

                return a;

            }if (_type == 2)
            {

                var TempL = new List<Product>();

                dynamic dataQuery = (

                    from p in db.Products
                    select p).DefaultIfEmpty();

                foreach (Product m in dataQuery)
                {

                    a += 1;
                }

                return a;


            }if (_type == 3)
            {

                var TempL = new List<User>();
                dynamic dataQuery = (

                    from p in db.Users
                    where p.U_active.Equals(0)

                    select p).DefaultIfEmpty();

                foreach (User i in dataQuery)
                {
                    a += 1;
                }



                return a;


            } if (_type == 3)
            {


                var TempL = new List<Product>();

                dynamic dataQuery = (

                    from p in db.Products

                    where p.P_Quantity < 50
                    select p).DefaultIfEmpty();

                foreach (Product m in dataQuery)
                {

                    a += 1;
                }

                return a;

            } if (_type == 4)
            {


                var TempL = new List<Invoice>();

                dynamic dataQuery = (

                    from p in db.Invoices
                    where p.Status.Equals(1)

                    select p).DefaultIfEmpty();

                foreach (Invoice i in dataQuery)
                {


                    a += 1;

                }

                return a;


            }
            else
            {
                return a;
            }


        }

        public List<Product> GetBookList( string _m)
        {

            var TempL = new List<Product>();

            dynamic dataQuery = (

                from p in db.Products
                where p.P_category.Equals(_m) || p.P_Language.Equals(_m)
                select p).DefaultIfEmpty();

            foreach (Product m in dataQuery)
            {

                TempL.Add(m);
            }

            return TempL;

        }
    }
}
    

        
   





