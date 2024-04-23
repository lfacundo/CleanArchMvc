using System.IO;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly INotyfService _notyfService;
        private readonly IWebHostEnvironment _environment;
        public ProductsController(IProductService productService, ICategoryService categoryService, INotyfService notyfService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _notyfService = notyfService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreateAsync(productDto);

                _notyfService.Success("Produto cadastrado com sucesso!");

                return RedirectToAction(nameof(Index));

            }
            return View(productDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var products = await _productService.GetByIdAsync(id);

            if (products == null) return NotFound();

            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", products.CategoryId);

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductDTO productDto)
        {
            if (id != productDto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(productDto);

                _notyfService.Success("Produto atualizado com sucesso!");

                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) return NotFound();

            var products = await _productService.GetByIdAsync(id);

            if (products == null) return NotFound();

            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _productService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetByIdAsync(id);

            if(product == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + product.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(product);
        }
    }
}
