using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LtcProviderData.Data;
using LtcProviderData.Models;

namespace LtcProviderData.Controllers
{
    public class ProviderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProviderController()
        {
            _dbContext = new ApplicationDbContext();
        }

//INDEX OF ALL PROVIDERS
        public ActionResult index()
        {
            var Providers = _dbContext.Set<Provider>().ToList();

            IEnumerable<ProviderIndexViewModel> ViewModels = Providers.Select(provider => new ProviderIndexViewModel()
            {
                ID = provider.ID,
                CCN = provider.CCN,
                Comment = provider.Comment
            });

            return View(ViewModels);


        }

//CREATE PROVIDER
        //GET
        //return create view
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProviderCreateViewModel());
        }

        //POST
        //creating new provider record
        [HttpPost]
        public ActionResult Create(ProviderCreateViewModel viewModel)
        {
            Provider newProvider = new Provider()
            {
                CCN = viewModel.CCN,
                Comment = viewModel.Comment
            };

            _dbContext.Set<Provider>().Add(newProvider);
            _dbContext.SaveChanges();

            return RedirectToAction("Create");
        }


    }
}