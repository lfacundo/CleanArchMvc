using System;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly INotyfService _notyfService;
        public CategoriesController(ICategoryService categoryService, INotyfService notyfService)
        {
            _categoryService = categoryService;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateAsync(categoryDto);
                _notyfService.Success("Categoria criada com sucesso!");
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetByIdAsync(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.UpdateAsync(categoryDto);
                    _notyfService.Success("Categoria atualizada com sucesso!");
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetByIdAsync(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _categoryService.RemoveAsync(id);
            
            _notyfService.Success("Categoria excluida com sucesso!");
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null) return NotFound();

            var categoryDto = _categoryService.GetByIdAsync(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }
    }
}
