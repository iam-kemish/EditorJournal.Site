using EditorJournal.data.Repo.IRepo;
using EditorJournal.Modals;
using EditorJournal.Modals.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EditorJournal.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        public IUnitOfWork _UnitOfWork { get; set; }
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public CartController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartLists = _UnitOfWork.ShoppingCartRepo.GetAll(u => u.AppUserId == userId, includeProperties: "Item"),
                OrderHeader = new()
            };
            foreach (var item in ShoppingCartVM.ShoppingCartLists)
            {
                ShoppingCartVM.OrderHeader.OrderTotal += item.Count * item.Item.Price;
            }
            return View(ShoppingCartVM);
        }
        [HttpGet]
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ShoppingCartVM = new()
            {
                ShoppingCartLists = _UnitOfWork.ShoppingCartRepo.GetAll(u => u.AppUserId == userId, includeProperties: "Item"),
                OrderHeader = new()
            };
            ShoppingCartVM.OrderHeader.AppUser = _UnitOfWork.AppUserRepo.Get(u => u.Id == userId);
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.AppUser.PhoneNumber;
            ShoppingCartVM.OrderHeader.Address = ShoppingCartVM.OrderHeader.AppUser.Address;
            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.AppUser.Name;

            foreach (var item in ShoppingCartVM.ShoppingCartLists)
            {
                ShoppingCartVM.OrderHeader.OrderTotal += item.Count * item.Item.Price;
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartLists = _UnitOfWork.ShoppingCartRepo.GetAll(u => u.AppUserId == userId, includeProperties: "Item"),
                OrderHeader = new OrderHeader()
            };
                         
            

            ShoppingCartVM.OrderHeader.AppUserId = userId;
            AppUser appUser = _UnitOfWork.AppUserRepo.Get(u => u.Id == userId);

            foreach (var item in ShoppingCartVM.ShoppingCartLists)
            {
                ShoppingCartVM.OrderHeader.OrderTotal += item.Count * item.Item.Price;
            }

            if (appUser.CompanyID.GetValueOrDefault() == 0)
            {
                ShoppingCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusPending;
                ShoppingCartVM.OrderHeader.OrderStatus = StaticDetails.StatusPending;
            }
            else
            {
                ShoppingCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusDelayedForFarPayment;
                ShoppingCartVM.OrderHeader.OrderStatus = StaticDetails.PaymentStatusApproved;
            }
            _UnitOfWork.OrderHeaderRepo.Add(ShoppingCartVM.OrderHeader);
            _UnitOfWork.Save();
            foreach (var item in ShoppingCartVM.ShoppingCartLists)
            {
                OrderDetail orderDetail = new()
                {
                    ItemId = item.ItemId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                    Price = item.Item.Price,
                    Count = item.Count
                };
                _UnitOfWork.OrderDetailRepo.Add(orderDetail);
                _UnitOfWork.Save();
            }

            return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });
        }

        public IActionResult OrderConfirmation(int id)
        {
            return View(id);
        }

        public IActionResult Decrement(int cartId)
        {
            var cartFromDb = _UnitOfWork.ShoppingCartRepo.Get(u => u.Id == cartId);
            cartFromDb.Count -= 1;
            if (cartFromDb.Count > 0)
            {
                _UnitOfWork.ShoppingCartRepo.Update(cartFromDb);
            }
            _UnitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Increment(int cartId)
        {
            var cartFromDb = _UnitOfWork.ShoppingCartRepo.Get(u => u.Id == cartId);
            cartFromDb.Count += 1;
            if (cartFromDb.Count > 0)
            {
                _UnitOfWork.ShoppingCartRepo.Update(cartFromDb);
            }
            _UnitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int cartId)
        {
            var cartFromDb = _UnitOfWork.ShoppingCartRepo.Get(u => u.Id == cartId);
            _UnitOfWork.ShoppingCartRepo.Remove(cartFromDb);
            _UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
