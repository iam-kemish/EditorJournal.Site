


using EditorJournal.Modals;
using Microsoft.AspNetCore.Mvc;
using EditorJournal.data.Repo.IRepo;
using EditorJournal.Modals.ViewModels;

namespace EditorJournal.Areas.Admin.Controllers
{
    [Area("Admin")]
 
    public class ItemsController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ItemsController(IUnitOfWork Debase, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = Debase;
            _WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index() 
        {
            List<Item> ItemList = _UnitOfWork.ItemsRepo.GetAll().ToList();
           
            return View(ItemList);
        }
        public IActionResult CreateUpdate(int? id)
        {

            ItemVM ItemVM = new()
            {
                Item = new Item()
            };
            if(id==null || id == 0)
            {
                return View(ItemVM);
            }else
            {
                ItemVM.Item = _UnitOfWork.ItemsRepo.Get(u => u.Id == id);
                return View(ItemVM);

            }
          
           
        }
        [HttpPost]
        public IActionResult CreateUpdate(ItemVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string WwwRootPath = _WebHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string pathToImage = Path.Combine(WwwRootPath, "Images", "ResultedImage", fileName);
                    using (var fileStream = new FileStream(pathToImage, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Item.ImageUrl = Path.Combine("Images", "ResultedImage", fileName);
                }

                
                if (obj.Item.Id == 0)
                {
                    
                    _UnitOfWork.ItemsRepo.Add(obj.Item);
                }
                else
                {
                   
                    var currentItem = _UnitOfWork.ItemsRepo.Get(u => u.Id == obj.Item.Id);
                    if (currentItem != null)
                    {
                        currentItem.Description = obj.Item.Description;
                        currentItem.Genre=obj.Item.Genre;
                        currentItem.Price = obj.Item.Price;
                        currentItem.Title = obj.Item.Title;
                        currentItem.AuthorName = obj.Item.AuthorName;
                        if (file != null)
                        {
                            currentItem.ImageUrl = obj.Item.ImageUrl;
                          
                        }
                        _UnitOfWork.ItemsRepo.update(currentItem);
                    }
                    else
                    {
                      
                        return NotFound();
                    }
                }

                _UnitOfWork.Save();
                //TempData["success"] = obj.Id == 0 ? "New Item created Successfully." : "Item updated Successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Item ItemFromDebase = _UnitOfWork.ItemsRepo.Get(u => u.Id == id);
            if (ItemFromDebase == null)
            {
                return NotFound();
            }
            return View(ItemFromDebase);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteObject(int id)
        {
            Item itemObj = _UnitOfWork.ItemsRepo.Get(u => u.Id == id);
            if (itemObj == null)
            {
                return NotFound();
            }
            _UnitOfWork.ItemsRepo.Remove(itemObj);


            _UnitOfWork.Save();
            TempData["success"] = "Item deleted Successfully.";
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Item> ItemList = _UnitOfWork.ItemsRepo.GetAll().ToList();
            return Json(new { data = ItemList });
        }
       

    }

}
