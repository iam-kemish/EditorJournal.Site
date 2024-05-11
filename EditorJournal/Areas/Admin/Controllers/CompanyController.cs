


using EditorJournal.Modals;
using Microsoft.AspNetCore.Mvc;
using EditorJournal.data.Repo.IRepo;

namespace EditorJournal.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
       
        public CompanyController(IUnitOfWork Debase, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = Debase;
            
        }
        public IActionResult Index() 
        {
            List<Company> CompanyList = _UnitOfWork.CompanyRepo.GetAll().ToList();
           
            return View(CompanyList);
        }
        public IActionResult CreateUpdate(int? id)
        {



            if (id == null || id==0)
            {
                return View(new Company());
            } else
            {
                Company Company = _UnitOfWork.CompanyRepo.Get(u => u.Id == id);
                if (Company == null)
                {
                    return NotFound(); 
                }
                return View(Company);
                
               
            }
          
           
        }
        [HttpPost]
        public IActionResult CreateUpdate(Company obj)
        {
            if (ModelState.IsValid)
            {
              
                
                if (obj.Id == 0)
                {
                    
                    _UnitOfWork.CompanyRepo.Add(obj);
                }
                else
                {
                   
                    var currentCompany = _UnitOfWork.CompanyRepo.Get(u => u.Id == obj.Id);
                    if (currentCompany != null)
                    {
                        currentCompany.StreetAddress = obj.StreetAddress;
                        currentCompany.City = obj.City;
                        currentCompany.PhoneNumber = obj.PhoneNumber;
                        currentCompany.Name = obj.Name;
                        currentCompany.State = obj.State;
                        currentCompany.PostalCode = obj.PostalCode;
                       
                        _UnitOfWork.CompanyRepo.Update(currentCompany);
                    }
                    else
                    {
                      
                        return NotFound();
                    }
                }

                _UnitOfWork.Save();
                //TempData["success"] = obj.Id == 0 ? "New Company created Successfully." : "Company updated Successfully.";
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
            Company CompanyFromDebase = _UnitOfWork.CompanyRepo.Get(u => u.Id == id);
            if (CompanyFromDebase == null)
            {
                return NotFound();
            }
            return View(CompanyFromDebase);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteObject(int id)
        {
            Company Object = _UnitOfWork.CompanyRepo.Get(u => u.Id == id);
            if (Object == null)
            {
                return NotFound();
            }
            _UnitOfWork.CompanyRepo.Remove(Object);


            _UnitOfWork.Save();
            TempData["success"] = "Company deleted Successfully.";
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> CompanyList = _UnitOfWork.CompanyRepo.GetAll().ToList();
            return Json(new { data = CompanyList });
        }
    
    }

}
