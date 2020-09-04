using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Infraestruture.Configuration;
using ApplicationApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Web_DDD_2020.Controllers
{
    //[Authorize]
    public class ProductsController : Controller
    {
        private readonly InterfaceProductApp _productApp;

        public ProductsController(InterfaceProductApp productApp)
        {
            _productApp = productApp;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _productApp.List());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productApp.GetEntityById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Preco,Ativo,Id,Nome")] Product product)
        {
            if (ModelState.IsValid)
            {
                //await _productApp.Add(product);
                await _productApp.AddProduct(product);
                if (product.Notitycoes.Any())
                {
                    foreach (var item in product.Notitycoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                    return View("Create", product);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productApp.GetEntityById(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Preco,Ativo,Id,Nome")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //await _productApp.Update(product);
                    await _productApp.UpdateProduct(product);
                    if (product.Notitycoes.Any())
                    {
                        foreach (var item in product.Notitycoes)
                        {
                            ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                        }
                        return View("Edit", product);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productApp.GetEntityById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productApp.GetEntityById(id);
            await _productApp.Delete(product);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExists(int id)
        {
            var produto = await _productApp.GetEntityById(id);
            return produto != null;
        }
    }
}
