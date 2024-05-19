using DwaysWeb.Models;
using DwaysWeb.Models.ViewModels;
using DwaysWeb.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DwaysWeb.Controllers
{
    public class CartController : Controller
    {
        public readonly DataContext _dataContext;
        public CartController(DataContext _context) {
        
            _dataContext=_context;
        }
        public IActionResult Index()
        {
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemViewModel cartVM = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        } 
        public IActionResult Checkout() {
            return View();
        }

        public async Task<IActionResult> Add(int ProductId)
        {
            // Lấy sản phẩm từ cơ sở dữ liệu
            Products product = await _dataContext.Products.FindAsync(ProductId);

            // Lấy danh sách giỏ hàng từ Session, nếu không tồn tại thì tạo mới
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            // Tìm kiếm xem sản phẩm đã có trong giỏ hàng chưa
            CartItemModel cartItem = cart.FirstOrDefault(c => c.ProductId == ProductId);

            if (cartItem == null)
            {
                // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                cartItem = new CartItemModel(product);
                cart.Add(cartItem);
            }
            else
            {
                // Nếu sản phẩm đã có trong giỏ hàng, tăng số lượng lên 1
                cartItem.Quantity += 1;
            }

            // Lưu danh sách giỏ hàng mới vào Session
            HttpContext.Session.SetJson("Cart", cart);

            // Chuyển hướng trở lại trang trước đó
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Increase(int ProductId)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            // Tìm kiếm xem sản phẩm đã có trong giỏ hàng chưa
            CartItemModel cartItem = cart.FirstOrDefault(c => c.ProductId == ProductId);
            if (cartItem.Quantity >= 1)
            {
                ++cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == ProductId);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);

            }
            return RedirectToAction("Index");
        }
        public IActionResult Decrease(int ProductId)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            // Tìm kiếm xem sản phẩm đã có trong giỏ hàng chưa
            CartItemModel cartItem = cart.FirstOrDefault(c => c.ProductId == ProductId);
            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == ProductId);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);

            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int ProductId)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            cart.RemoveAll(p=>p.ProductId == ProductId);
            if(cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart",cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Clear(int ProductId)
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }

        }
}
