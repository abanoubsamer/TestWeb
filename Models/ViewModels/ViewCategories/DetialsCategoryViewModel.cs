namespace TestWeb.Models.ViewModels.ViewCategories
{
    public class DetialsCategoryViewModel
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public ICollection<TestItemcs>? Items { get; set; }

    }
}
