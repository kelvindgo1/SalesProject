using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesProject.Models;
using SalesProject.Models.ViewModels;
using SalesProject.Services;

namespace SalesProject.Controllers
{
    public class SellerController : Controller
    {
        private readonly DepartmentService _departmentService;
        private readonly SellerService _sellerService;

        public SellerController(SellerService sellerService, DepartmentService departmentService)
        {        
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var department = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = department };
            return View(viewModel);
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);

            return RedirectToAction(nameof(Index));
        }       
        
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}