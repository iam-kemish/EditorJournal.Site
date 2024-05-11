


using EditorJournal.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EditorJournal.data.Repo.IRepo;

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



            if (id == null || id==0)
            {
                return View(new Item());
            } else
            {
                Item item = _UnitOfWork.ItemsRepo.Get(u => u.Id == id);
                if (item == null)
                {
                    return NotFound(); 
                }
                return View(item);
                
               
            }
          
           
        }
        [HttpPost]
        public IActionResult CreateUpdate(Item obj, IFormFile? file)
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
                    obj.ImageUrl = Path.Combine("Images", "ResultedImage", fileName);
                }

                
                if (obj.Id == 0)
                {
                    
                    _UnitOfWork.ItemsRepo.Add(obj);
                }
                else
                {
                   
                    var currentItem = _UnitOfWork.ItemsRepo.Get(u => u.Id == obj.Id);
                    if (currentItem != null)
                    {
                        currentItem.Description = obj.Description;
                        currentItem.Genre=obj.Genre;
                        currentItem.Price = obj.Price;
                        currentItem.Title = obj.Title;
                        currentItem.AuthorName = obj.AuthorName;
                        if (file != null)
                        {
                            currentItem.ImageUrl = obj.ImageUrl;
                          
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
            Item Object = _UnitOfWork.ItemsRepo.Get(u => u.Id == id);
            if (Object == null)
            {
                return NotFound();
            }
            _UnitOfWork.ItemsRepo.Remove(Object);


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
