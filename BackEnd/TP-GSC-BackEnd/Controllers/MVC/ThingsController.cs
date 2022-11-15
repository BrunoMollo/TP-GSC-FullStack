using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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


        public ThingsController(IUnitOfWork uow, IMapper mapper)
        {
            this.Uow = uow;
            this.Mapper = mapper;
        }




        public IActionResult Index()
        {
            var AllThings = Uow.ThingsRepo.GetAll();
            var AllThingsDto = Mapper.Map<List<ShowThingDto>>(AllThings);
            return View(AllThingsDto); ;
        }




        public IActionResult Create()
        {
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
        public IActionResult Create(CreateThingViewModel createThingViewModel)
        {
            if (!ModelState.IsValid)
            {
                var AllCategories = Uow.CategoryRepo.GetAll();
                var AllCategoriesDto = Mapper.Map<ShowCategoryDto[]>(AllCategories);
                createThingViewModel.Categories = AllCategoriesDto.ToList();
                return View(nameof(Create), createThingViewModel);
            }


            var selectedCategory = Uow.CategoryRepo.GetOne(createThingViewModel.CategoryId);
            if (selectedCategory is null)
            {
                var AllCategories = Uow.CategoryRepo.GetAll();
                var AllCategoriesDto = Mapper.Map<ShowCategoryDto[]>(AllCategories);
                createThingViewModel.Categories = AllCategoriesDto.ToList();
                return View(nameof(Create), createThingViewModel);
            }


            var newThing = new Thing();
            newThing.Description = createThingViewModel.Description;
            newThing.Category = selectedCategory;


            var createdThing = Uow.ThingsRepo.add(newThing);
            Uow.SaveChanges();

            return Redirect(nameof(Index));
        }



        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
                return NotFound();

            var thing = Uow.ThingsRepo.GetOne(id.Value);
            if (thing is null)
                return NotFound();

            var AllCategories = Uow.CategoryRepo.GetAll();
            var AllCategoriesDto = Mapper.Map<ShowCategoryDto[]>(AllCategories);

            var createThingViewModel = new CreateThingViewModel()
            {
                Categories = AllCategoriesDto.ToList(),
                Description = thing.Description,
                CategoryId = thing.Category.Id
            };

            return View(createThingViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, CreateThingViewModel createThingViewModel)
        {
            if (!ModelState.IsValid)
            {
                var AllCategories = Uow.CategoryRepo.GetAll();
                var AllCategoriesDto = Mapper.Map<ShowCategoryDto[]>(AllCategories);
                createThingViewModel.Categories = AllCategoriesDto.ToList();
                return View(nameof(Edit), createThingViewModel);
            }

            if (id is null || id == 0)
                return NotFound();

            var thing = Uow.ThingsRepo.GetOne(id.Value);
            if (thing is null)
                return NotFound();

            var newCategory = Uow.CategoryRepo.GetOne(createThingViewModel.CategoryId);
            if (newCategory is null)
                return NotFound();

            thing.Description = createThingViewModel.Description;
            thing.Category = newCategory;

            Uow.ThingsRepo.update(thing);
            Uow.SaveChanges();

            return RedirectToAction(nameof(Index));

        }


        //[ValidateAntiForgeryToken] ES BUENA IDEA HACER UNDELETE CON UN GET????
        public IActionResult Delete(int? id) {
            if (id is null || id == 0)
                return NotFound();

            var thing = Uow.ThingsRepo.GetOne(id.Value);
            if (thing is null)
                return NotFound();

            Uow.ThingsRepo.Delete(thing);
            Uow.SaveChanges();

            return RedirectToAction(nameof(Index));


        }








    }


}
