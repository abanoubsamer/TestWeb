namespace TestWeb.Models.ViewModels.Roles
{
    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }
        public IList<string> AllRoles { get; set; }
    }
}
