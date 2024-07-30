using AutoMapper;
using TestWeb.Models;
using TestWeb.Models.ViewModels.ViewIteam;

namespace TestWeb.Mapping
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            CreateMap<AddItemsViewModel, TestItemcs>();
            CreateMap<EditItemsViewModel, TestItemcs>();
            CreateMap<TestItemcs, EditItemsViewModel>();
        }

        

    }
}
