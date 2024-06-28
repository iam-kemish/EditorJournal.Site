using EditorJournal.data.Models;
using EditorJournal.data.Repo.IRepo;
using EditorJournal.Modal;
using EditorJournal.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EditorJournal.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork; 
        }

        public IActionResult Index()
        {
            IEnumerable<Item> ItemList = _unitOfWork.ItemsRepo.GetAll();
            return View(ItemList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Details(int id)
        {
            var item = _unitOfWork.ItemsRepo.Get(u => u.Id == id);
            if (item == null)
            {
              
                return NotFound();
            }

            ShoppingCart cart = new()
            {
                Item = item,
                Count = 1,
                ItemId = id
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            shoppingCart.Id = 0;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.AppUserId=userId;
        
            ShoppingCart cartFromDatabase = _unitOfWork.ShoppingCartRepo.Get(u => u.AppUserId == userId && u.ItemId == shoppingCart.ItemId);
            if(cartFromDatabase!= null)
            {
                cartFromDatabase.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCartRepo.Update(cartFromDatabase);
            }else
            {

            _unitOfWork.ShoppingCartRepo.Add(shoppingCart);
            }
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
