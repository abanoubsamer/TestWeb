using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TestWeb.Models;
using TestWeb.Models.ViewModels.ViewCategories;
using TestWeb.Services.Interface;

namespace TestWeb.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        #region Fiald
        private readonly ICategoryServieces _CS;
        private readonly IMapper _Map;
        #endregion
        public CategoriesController(ICategoryServieces CS, IMapper Map)
        {
            _CS=CS;
            _Map=Map;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {            

            return View(await _CS.GetCategorysAsync());
        }


        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
     
            return View(await _CS.GetCategorysDetailsByIdAsync(id));
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Categories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] AddCategoryViewModel category)
        {
            var CategoryMap = _Map.Map<Category>(category);

            if (CategoryMap == null) return NotFound();
            try
            {
                if (await _CS.AddCategoryAsync(CategoryMap))
                    return RedirectToAction(nameof(Index));
                return View(CategoryMap);
            }
            catch (Exception ex) {
                return View(CategoryMap);
            }
            
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return NotFound();
          
            try
            {
                var Category =_Map.Map<EditCategoryViewModel>(await _CS.GetCategorysByIdAsync(id));

                if (Category == null) return NotFound();


                   return  View(Category);
            }
            catch(Exception e)
            {
                return NotFound($"{e.Message}");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] EditCategoryViewModel category)
        {
            var CategoryMap = _Map.Map<Category>(category);

            if (CategoryMap == null) return NotFound();
            try
            {
               if(await _CS.UpdateCategoryAsync(CategoryMap))
                    return RedirectToAction(nameof(Index));
                return View(CategoryMap);
            }
            catch (Exception e)
            {
                return View(CategoryMap);
            }
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            try
            {
                if (await _CS.DeleteCategoryAsync(id)) return RedirectToAction(nameof(Index));
                return NotFound();
            }
            catch (Exception ex) {

                return NotFound();
            }

        }

       

        public async Task<IActionResult> CategoryExist(string Name)
        {
            return await _CS.IsCategoryNameExitsAsync(Name) ? Json(false) : Json(true); 
        }
        public async Task<IActionResult> CategoryExistSelf(string Name, int Id)
        {
            return await _CS.IsCategoryExitsExcludeItSelfAsync(Name,Id) ? Json(false) : Json(true);
        }
    }
}
