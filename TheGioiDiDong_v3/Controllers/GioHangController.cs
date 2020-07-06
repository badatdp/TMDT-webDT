using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiDiDong_v3.Models;
namespace TheGioiDiDong_v3.Controllers
{
    public class GioHangController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        // GET: /GioHang/
        #region Giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì tiến hành khởi tạo list Giỏ hàng(session Giỏ hàng)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //thêm Giỏ hàng
        public ActionResult ThemGioHang(string sMaSP, string strURL)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.maSP == sMaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            //Lấy ra Session Giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sản phẩm đã tồn tại trong session[giohang] chưa
            GioHang sanpham = lstGioHang.Find(n => n.sMaSP == sMaSP);
            if (sanpham == null)
            {
                sanpham = new GioHang(sMaSP);
                //Add sản phẩm mới vào list
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng
        public ActionResult CapNhatGioHang(string sMaSP, FormCollection f)
        {
            //kiểm tra maSP
            SanPham sp = db.SanPham.SingleOrDefault(n => n.maSP == sMaSP);
            //nếu get sai masp thì trả vê trang lỗi
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session[GioHang]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.sMaSP == sMaSP);
            //nếu mà tồn tại thì cho sửa số lượng
            if (sanpham != null)
            {
                if (int.Parse(f["txtSoLuong"].ToString()) > 0 && int.Parse(f["txtSoLuong"].ToString()) <= 9999 )
                { sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString()); }
                else
                {
                    return RedirectToAction("SuaGioHang");
                   
                }
            }
            return RedirectToAction("GioHang");
        }
        //Xoá giỏ hàng
        public ActionResult XoaGioHang(string sMaSP)
        {

            //kiểm tra maSP
            SanPham sp = db.SanPham.SingleOrDefault(n => n.maSP == sMaSP);
            //nếu get sai masp thì trả vê trang lỗi
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session[GioHang]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.sMaSP == sMaSP);
            //nếu mà tồn tại thì cho sửa số lượng
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.sMaSP == sMaSP);
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        //xây dựng trang Giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //tính tổng số lượng và tổng tiền
        //tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien += lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        //tạo partial chứa tổng số lượng và tổng tiền
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.ThanhTien = TongTien();
            return PartialView();
        }
        //xây dựng một view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        #endregion
        #region Đặt hàng
        //public
        //Chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //kiềm tra Đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            //Kiểm tra Giỏ hàng
            if(Session["GioHang"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            KhachHang kh = (KhachHang)Session["KhachHang"];
            List<GioHang> gh = LayGioHang();
            ddh.maKH = kh.maKH;
            
            ddh.ngaydat = DateTime.Now;
            db.DonHang.Add(ddh);
            db.SaveChanges();
            foreach (var item in gh)
            {
                ChiTietDonHang ct = new ChiTietDonHang();
                ct.madonhang = ddh.madonhang;
                ct.maSP = item.sMaSP;
                ct.soluong = item.iSoLuong;
                ct.dongia = (int)item.dGia;
                db.ChiTietDonHang.Add(ct);

            }
            db.SaveChanges();
            return RedirectToAction("DatHangThanhCong", "GioHang");
        }
        public ActionResult DatHangThanhCong()
        {
            return View();
        }
        public ActionResult ThanhToanThanhCong()
        {
            return View();
        }
        #endregion
        #region Thanh toán
        public ActionResult XacNhanThanhToan(int? madonhang)
        {
            DonHang dh = db.DonHang.SingleOrDefault(n => n.madonhang == madonhang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                if (dh.dathanhtoan == "Chưa thanh toán" || dh.dathanhtoan == "")
                {
                    dh.dathanhtoan = "Đã thanh toán";
                    db.DonHang.Add(dh);
                    db.SaveChanges();
                }
            }
            return View();
        }
        #endregion
// tao phương thức thanh toan paypal
        private Payment payment;
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList() { items = new List<Item>() };
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
           foreach(var giohang in lstGioHang)
            {
                listItems.items.Add(new Item()
                {
                    name = giohang.sTenSP,
                    currency = "USD",
                    price = giohang.dGia.ToString(),
                    quantity = giohang.iSoLuong.ToString(),
                    sku = giohang.sMaSP

                });
            }
            var payer = new Payer() { payment_method = "paypal" };
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl

            };


            var details = new Details()
            {
                tax = "1",
                shipping = "2",
                subtotal = lstGioHang.Sum(x => x.iSoLuong * x.dGia).ToString()
            };
            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString(),
                details = details
            };

            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "Testing transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = listItems

            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);

        }

        private Payment ExecutePayment(APIContext apiContext, string payerId,string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new Payment() { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);
        }
        [NoCache]
        public ActionResult PaymentWithPaypal()
        {
            //
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            APIContext apiContext =PaypalConfiguration.GetAPIContext();
            try
            {
                //string payerId = Request.Params["PayerID"];
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/GioHang/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    
                    while(links.MoveNext())
                    {
                        Links link = links.Current;
                        if(link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;

                        } 
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);

                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if(executedPayment.state.ToLower() != "approved" )
                    {
                        return View("Failure");
                    }
                        
                        }
            }
            catch (Exception ex)
            {
                PaypalLogger.Log("Error: " + ex.Message);
                return View("Failure");
            }
           
            //Kiểm tra Giỏ hàng
           
            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            KhachHang kh = (KhachHang)Session["KhachHang"];
            List<GioHang> gh = LayGioHang();
            ddh.maKH = kh.maKH;
            ddh.dathanhtoan = "Đã thanh toán"; 
            ddh.ngaydat = DateTime.Now;
            db.DonHang.Add(ddh);
            db.SaveChanges();
            foreach (var item in gh)
            {
                ChiTietDonHang ct = new ChiTietDonHang();
              
                ct.madonhang = ddh.madonhang;
                ct.maSP = item.sMaSP;
                ct.soluong = item.iSoLuong;
                ct.dongia = (int)item.dGia;
             
                db.ChiTietDonHang.Add(ct);

            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("ThanhToanThanhCong", "GioHang");
           
            
        }
    }
}