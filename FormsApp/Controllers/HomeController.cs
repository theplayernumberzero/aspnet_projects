using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsApp.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
    }

    [HttpGet]
    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;
        if (!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            products = products.Where(p => p.Name!.ToLower().Contains(searchString)).ToList();
        }

        if (!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }

        // ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category);

        var model = new ProductViewModel
        {
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var extension = "";

        if (imageFile != null)
        {
            extension = Path.GetExtension(imageFile.FileName);
            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("imageFile", "Bu uzantıda resim kabul edilmemektedir.");
            }
        }
        if (ModelState.IsValid)
        {
            var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile!.CopyToAsync(stream);
            }

            model.Image = randomFileName;
            model.ProductId = Repository.Products.Count + 1;
            Repository.CreateProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();  //404 sayfası
        }
        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if (entity == null)
        {
            return NotFound();  //404 sayfası
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile)
    {
        if (id != model.ProductId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            if (imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                model.Image = randomFileName;
            }
            Repository.EditProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();  //404 sayfası
        }
        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if (entity == null)
        {
            return NotFound();  //404 sayfası
        }
        return View("DeleteConfirm", entity);
    }

    [HttpPost]
    public IActionResult Delete(int id, int ProductId)
    {
        if (id != ProductId)
        {
            return NotFound();  //404 sayfası
        }
        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == ProductId);
        if (entity == null)
        {
            return NotFound();  //404 sayfası
        }
        Repository.DeleteProduct(entity);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult EditProducts(List<Product> products)
    {
        foreach (var product in products)
        {
            Repository.EditProducts(product);
        }
        return RedirectToAction("Index");
    }
}
