using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;
using TestWeb.Models.ViewModels.Roles;


[Authorize(Roles =Role.RoleAdmin)]
public class RoleManagementController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleManagementController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var model = new List<ManageUserRolesViewModel>();
        foreach (var user in users)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            model.Add(new ManageUserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = userRoles,
                AllRoles = _roleManager.Roles.Select(r => r.Name).ToList()
            });
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUserRoles(string userId, List<string> roles)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var addedRoles = roles.Except(userRoles);
        var removedRoles = userRoles.Except(roles);

        await _userManager.AddToRolesAsync(user, addedRoles);
        await _userManager.RemoveFromRolesAsync(user, removedRoles);

        return RedirectToAction("Index");
    }
}
