using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebStore.Models;
namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        ModelWebStore db = new ModelWebStore();
        public const string CartSession = "CartSession";

        // GET: Cart
        public ActionResult Index()
        {
            var Cart = Session[CartSession];
            var listCart = new List<CART>();

            if (Cart != null)
            {
                listCart = (List<CART>)Cart;
            }

            return View(listCart);
        }

        public ActionResult AddtoCart(int IDPro)
        {
            if (Session[CartSession] == null)
            {
                Session[CartSession] = new List<CART>();
            }
            List<CART> listCart = Session[CartSession] as List<CART>;
            if (listCart.Exists(m => m.ID_Product == IDPro)) //Trong giỏ hàng chưa có sản phẩm
            {
                //Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CART card = listCart.FirstOrDefault(m => m.ID_Product == IDPro);
                card.Quantity++;
            }
            else
            {
                PRODUCT pro = db.PRODUCTs.Find(IDPro);  // Tìm sản phẩm theo id
                CART newItem = new CART()
                {
                    ID_Product = IDPro,
                    Image = pro.Image,
                    ProductName = pro.ProductName,
                    Quantity = 1,
                    Price = (float)(pro.Price),
                };  //Tạo ra 1 CartItem mới

                listCart.Add(newItem);  //Thêm CartItem vào giỏ
            }

            /*  
                Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. 
                Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); 
                nếu muốn.
            */
            return RedirectToAction("Index", "Cart", new { proid = IDPro });
        }

        public ActionResult Deleted(int IDPro)
        {
            List<CART> Cart = Session[CartSession] as List<CART>;
            CART delete_item = Cart.FirstOrDefault(m => m.ID_Product == IDPro);
            if (delete_item != null)
            {
                Cart.Remove(delete_item);
            }
            return RedirectToAction("Index", "Cart");
        }


        public ActionResult Updated(int IDPro, int newQuantity)
        {
            List<CART> Cart = Session[CartSession] as List<CART>;
            CART update_item = Cart.FirstOrDefault(m => m.ID_Product == IDPro);
            if (update_item != null)
            {
                update_item.Quantity = newQuantity;
            }
            return RedirectToAction("Index", "Cart");
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var Cart = Session[CartSession];
            var listCart = new List<CART>();
            if (Cart != null)
            {
                listCart = (List<CART>)Cart;
            }
            return PartialView(listCart);
        }

        public ActionResult CheckOut()
        {
            if (Session["Logged"] != null)
            {
                var cart = Session[CartSession];
                var list = new List<CART>();
                if (cart != null)
                {
                    list = (List<CART>)cart;
                }
                return View(list);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public ActionResult ProcessOrder(FormCollection form)
        {
            if (Session["Logged"] != null)
            {
                List<CART> listCart = (List<CART>)Session["CartSession"];
                BILL bill = new BILL()
                {
                    CustomerName = form["cusName"],
                    DeliveryAddress = form["cusAddress"],
                    DateCreated = DateTime.Now,
                    Status = "Processing...",
                    City = form["cusCity"],
                    Country = form["cusCountry"],
                    Email = form["cusEmail"],
                    PhoneNumber = form["cusPhone"],

                };
                db.BILLs.Add(bill);
                db.SaveChanges();

                foreach (CART cart in listCart)
                {
                    BILLDETAIL billdetail = new BILLDETAIL()
                    {
                        ID_Bill = bill.ID_Bill,
                        ID_Product = cart.ID_Product,
                        Quantity = cart.Quantity,
                        Price = cart.Price,
                        Total = cart.Total,
                        ProductName = cart.ProductName,
                    };
                    db.BILLDETAILs.Add(billdetail);

                    db.SaveChanges();
                }
                int IDBill = bill.ID_Bill;
                Session.Remove(CartSession);
                return RedirectToAction("SuccessOrder", "Cart", new { idbill = IDBill });
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public ActionResult SuccessOrder(int IDbill)
        {
            ModelWebStore db = new ModelWebStore();
            BILL bill = db.BILLs.Where(m => m.ID_Bill == IDbill).SingleOrDefault();
            return View(bill);
        }

        [ChildActionOnly]
        public ActionResult BillDetail(int idbill)
        {
            ModelWebStore db = new ModelWebStore();
            List<BILLDETAIL> billdetail = (from p in db.BILLDETAILs where p.ID_Bill == idbill select p).ToList();
            return PartialView(billdetail);
        }
    }
}