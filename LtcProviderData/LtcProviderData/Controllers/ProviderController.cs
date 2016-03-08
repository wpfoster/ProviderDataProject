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

        // GET: Provider
        // public ActionResult index()


        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProviderCreateViewModel());
        }


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