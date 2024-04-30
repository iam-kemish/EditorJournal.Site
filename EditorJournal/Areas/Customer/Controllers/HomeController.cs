using EditorJournal.data.Models;
using EditorJournal.dataSet.Repo.IRepo;
using EditorJournal.Modals;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EditorJournal.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork<Item> _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork<Item> unitOfWork)
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
            Item item = _unitOfWork.ItemsRepo.Get(u => u.Id == id);
            return View(item);
        }

    }
}
