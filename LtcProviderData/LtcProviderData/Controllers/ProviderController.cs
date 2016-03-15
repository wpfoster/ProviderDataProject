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


 //detail view of individual provider
        //[Route("detail/{id:int}")]
        public ActionResult Detail(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }

            else
            {
                Provider SingleProvider = _dbContext.Set<Provider>().Single(Provider => Provider.ID == id);
                var viewmodel = new ProviderDetailViewModel()
                {
                    ID = SingleProvider.ID,
                    CCN = SingleProvider.CCN,
                    Comment = SingleProvider.Comment
                };
                return View(viewmodel);
            }
        }



        //edit single record
        //[Route("edit/{id:int}")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }

            else
            {
                //Provider SingleProvider = _dbContext.Set<Provider>().Single(Provider => Provider.ID == id);
                //var viewmodel = new ProviderEditViewModel()
                //{
                //    ID = SingleProvider.ID,
                //    CCN = SingleProvider.CCN,
                //    Comment = SingleProvider.Comment
                //};


                Provider provider = _dbContext.Set<Provider>().Single(Provider => Provider.ID == id);



                return View(provider);
            }
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,CCN,Comment")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(provider).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("index");
            }
            return View(provider);
        }

        //delete single record
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Provider provider = _dbContext.Set<Provider>().Single(Provider => Provider.ID == id);
            var viewmodel = new ProviderDeleteViewModel()
            {
                ID = provider.ID,
                CCN = provider.CCN,
                Comment = provider.Comment
            };

            return View(viewmodel);

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            Provider provider =_dbContext.Set<Provider>().Find(id);
            _dbContext.Set<Provider>().Remove(provider);
            _dbContext.SaveChanges();
            return RedirectToAction("index");
            
        }
    }
}