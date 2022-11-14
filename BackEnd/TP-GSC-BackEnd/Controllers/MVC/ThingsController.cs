using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP_GSC_BackEnd.Data_Access.CategoryData;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto.CategotyDto;
using TP_GSC_BackEnd.Dto.ThingDto;
using TP_GSC_BackEnd.Entities;
using TP_GSC_BackEnd.Models;

namespace TP_GSC_BackEnd.Controllers.MVC
{
    public class ThingsController : Controller
    {
        private readonly IUnitOfWork Uow;
        private readonly IMapper Mapper;
        public ThingsController(IUnitOfWork uow, IMapper mapper) { 
            this.Uow = uow;
            this.Mapper = mapper;
        }


        public IActionResult Index()
        {
            var AllThings = Uow.CategoryRepo.GetAll();
            var AllThingsDto = Mapper.Map<List<ShowThingDto>>(AllThings);
            return View(AllThingsDto); ;
        }




        public IActionResult Create() {
            var AllCategories = Uow.CategoryRepo.GetAll();
            var AllCategoriesDto = Mapper.Map<ShowCategoryDto[]>(AllCategories);

            var createThingViewModel = new CreateThingViewModel()
            {
                Categories = AllCategoriesDto.ToList(),
            };

            return View(createThingViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateThingViewModel createThingViewModel) {
            if (!ModelState.IsValid)
                return View("Create", createThingViewModel);

            
            var selectedCategory = Uow.CategoryRepo.GetOne(createThingViewModel.CategoryId);
            if (selectedCategory is null)
                return View("Create", createThingViewModel);

            var newThing = new Thing();
            newThing.Description = createThingViewModel.Description;
            newThing.Category = selectedCategory;


            var createdThing = Uow.ThingsRepo.add(newThing);
            Uow.SaveChanges();

            return Redirect(nameof(Index));
        }

    }
}
