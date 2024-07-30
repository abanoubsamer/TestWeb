using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using TestWeb.Models;
using TestWeb.Models.ViewModels.ViewIteam;
using TestWeb.Repository.Interface;
using TestWeb.Services.Interface;

namespace TestWeb.Controllers
{
    [Authorize(Roles = Role.RoleAdmin)]
    public class ItemsController : Controller
    {

        #region Fiald
        private IItemServices _IS;
        private ICategoryServieces _CategoryServieces;
        private IMapper _Map;
        #endregion


        #region Constacutor
        public ItemsController(IItemServices IS, ICategoryServieces CategoryServieces, IMapper Map)
        {
            _IS = IS;
            _CategoryServieces = CategoryServieces;
            _Map=Map;
        }
        #endregion

        #region HelperFunction
        [HttpPost]
        public async Task<IActionResult> IsItemNameExists(string Name)
        {
            return await _IS.IsItemNameExitsAsync(Name) ? Json(false) : Json(true);
        }
        public async Task<IActionResult> IsItemExitsExcludeItSelf(string Name, int Id)
        {
          
            return await _IS.IsItemExitsExcludeItSelfAsync(Name, Id) ? Json(false) : Json(true);

        }
        private async Task CreateCategoryAsync<T>(T? selectid = null) where T : class
        {
            var categories = await _CategoryServieces.GetCategorysAsync();
            SelectList selectListItems;
            if (selectid == null)
            {
                selectListItems = new SelectList(categories, "Id", "Name");
            }
            else
            {
                selectListItems = new SelectList(categories, "Id", "Name", selectid);
            }

            ViewBag.CategoryList = selectListItems;
        }
        #endregion



        #region Index
        public async Task<IActionResult> Index()
        {
            return View(await _IS.GetItemsAsync("Categorys"));
        }
        #endregion


        #region New
        // GET: New
        public async Task<IActionResult> New()
        {
            await CreateCategoryAsync<AddItemsViewModel>();
            return View();
        }

        [HttpPost]// hna ana bolh an dh post function
        [ValidateAntiForgeryToken]// hna hwa hy3ml validat lw7doh /hyro7 ly ale model we y4of ale ana 3mloh lw 4bh ale mbo3ot 5las
        //POST()
        public async Task<IActionResult> New(AddItemsViewModel item)
        {
            var categoryMap = _Map.Map<TestItemcs>(item);
            await CreateCategoryAsync<AddItemsViewModel>();
            Regex r1 = new Regex(@"^[A-Z][a-z]+$");

            if (categoryMap == null)
            {
                ModelState.AddModelError("", "Item is Null");
            }

            // Validate the item.Name against the regex pattern
            if (!r1.IsMatch(categoryMap.Name))
            {
                // Add a model state error with a meaningful message
                ModelState.AddModelError("Name", "The Name must start with an uppercase letter followed by lowercase letters And Name Must Be Empty Number.");
            }

           
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                try
                {
                    if (await _IS.AddItemAsync(categoryMap))
                    {
                        TempData["SuccessData"] = "Success Add New Item";
                        return RedirectToAction("Index");
                    }
                    await CreateCategoryAsync(categoryMap);
                    TempData["errorData"] = "Eror is AddIteam";
                    return View(item);
                }
                catch (Exception e)
                {
                    await CreateCategoryAsync(categoryMap);
                    ModelState.AddModelError("", $"Error Add Item: {e.Message}");
                    TempData["errorData"] = $"Error Add Item: {e.Message}";
                    return View(item);
                }
            }
            else
            {
                await CreateCategoryAsync(categoryMap);
                TempData["errorData"] = "Eror is Validation Data Fiald";
                return View(item);
            }

        }
        #endregion


        #region Edite
        public async Task<IActionResult> Edite(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
            var Item = _Map.Map<EditItemsViewModel>(await _IS.GetItemByIdAsync(id));

            if (Item == null)
            {
                return NotFound();
            }
            await CreateCategoryAsync(Item);
            return View(Item);

        }
        [HttpPost]// hna ana bolh an dh post function
        [ValidateAntiForgeryToken]// hna hwa hy3ml validat lw7doh /hyro7 ly ale model we y4of ale ana 3mloh lw 4bh ale mbo3ot 5las
        //POST()
        public async Task<IActionResult> Edite(EditItemsViewModel item)
        {

            var CategoryMap = _Map.Map<TestItemcs>(item);
            Regex r1 = new Regex(@"^[A-Z][a-z]+$");

            // Validate the item.Name against the regex pattern
            if (!r1.IsMatch(CategoryMap.Name))
            {
                // Add a model state error with a meaningful message
                ModelState.AddModelError("Name", "The Name must start with an uppercase letter followed by lowercase letters And Name Must Be Empty Number.");
               
            }
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _IS.UpdateItemAsync(CategoryMap))
                        return RedirectToAction("Index");
                    TempData["errorData"] = "Eror is EditIteam";
                    return View(CategoryMap);
                }
                await CreateCategoryAsync(CategoryMap);
                return View(CategoryMap);
            }
            catch (Exception e)
            {
                await CreateCategoryAsync(CategoryMap);
                TempData["errorData"] = $"Error Edit Item: {e.Message}";
                return View(CategoryMap);
            }

        }

        #endregion


        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            try
            {
                if( await _IS.DeleteItemAsync(id))
                {
                    TempData["DeleteData"] = "Success Delete Item";
                    return RedirectToAction("Index");
                }
                TempData["errorData"] = "Eror is DeleteIteam";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["errorData"] = $"Eror is DeleteIteam Messeage{e}";
                return RedirectToAction("Index");
            }

          

        }

        #endregion







    }

}
