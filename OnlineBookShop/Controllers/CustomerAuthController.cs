using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class CustomerAuthController : Controller
    {
        private readonly OnlineBookShopContext _context;

        public CustomerAuthController(OnlineBookShopContext context)
        {
            _context = context;
        }

        // ---- Register

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(customer);
        }

        //---------- Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var customer = _context.Customers
                .FirstOrDefault(c => c.Username == username && c.Password == password);
            if (customer != null)
            {
                return RedirectToAction("Index", "Books");
            }
            ViewBag.Error = "Invalid login. Try again";
            return View();
        }
    }
}
