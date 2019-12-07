﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CompileError.Model.Model;
using CompileError.Manager.Manager;
using CompileError.Models;

namespace CompileError.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManager _productManager = new ProductManager();
        private readonly CategoryManager _categoryManager = new CategoryManager();

        [HttpGet]
        public ActionResult AddProduct()
        {
            ProductModelView productModelView = new ProductModelView()
            {
                Products = _productManager.GetAll(),
                CategorySelectListItems = _categoryManager.GetAll()
                    .Select(c=>new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList()
            };

            

            return View(productModelView);
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModelView productModelView)
        {
            Product product = Mapper.Map<Product>(productModelView);

            if(ModelState.IsValid)
            {
                ViewBag.Message = _productManager.Add(product) ? "Saved" : "Not Saved";
            }
            else
            {
                ViewBag.Message = "Model State Error";
            }

            productModelView.CategorySelectListItems = _categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            productModelView.Products = _productManager.GetAll();
            return View(productModelView);
        }

        [HttpGet]
        public ActionResult SearchProduct()
        {
            ProductModelView productModelView = new ProductModelView()
            {
                Products = _productManager.GetAll(),
                CategorySelectListItems = _categoryManager.GetAll()
                    .Select(c=>new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                            
                    }).ToList()
            };

            return View(productModelView);
        }

        [HttpPost]
        public ActionResult SearchProduct(ProductModelView productModelView)
        {


            var products = _productManager.GetAll();

            if (!string.IsNullOrEmpty(productModelView.Code))
            {
                products = products.Where(p =>
                    p.Code.ToLower().Contains(productModelView.Code.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(productModelView.Name))
            {
                products = products.Where(p =>
                    p.Name.ToLower().Contains(productModelView.Name.ToLower())).ToList();
            }

            if (productModelView.CategoryId != 0)
            {
                products = products.Where(p => p.CategoryId == productModelView.CategoryId).ToList();
            }

            if (!string.IsNullOrEmpty(productModelView.Description))
            {
                products = products.Where(p =>
                    p.Description.ToLower().Contains(productModelView.Description.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(productModelView.ReorderLevel.ToString()))
            {
                products = products.Where(p =>
                    p.ReorderLevel.ToString().Contains(productModelView.ReorderLevel.ToString())).ToList();
            }

            productModelView.Products = products;
            productModelView.CategorySelectListItems = _categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View(productModelView);
        }

        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            Product product = _productManager.GetById(Id);

            ProductModelView productModelView =  Mapper.Map<ProductModelView>(product);

            productModelView.CategorySelectListItems = _categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            productModelView.Products = _productManager.GetAll();

            return View(productModelView);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductModelView productModelView)
        {
            Product product = Mapper.Map<Product>(productModelView);

            if (ModelState.IsValid)
            {
                _productManager.Update(product);
            }

            productModelView.Products = _productManager.GetAll();
            productModelView.CategorySelectListItems = _categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(productModelView);
        }


    }
}