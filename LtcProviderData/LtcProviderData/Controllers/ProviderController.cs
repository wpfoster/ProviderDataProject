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
                BED_CNT = provider.BED_CNT,
                FAC_NAME = provider.FAC_NAME,
                //ST_ADR = provider.ST_ADR,
                CITY_NAME = provider.CITY_NAME,
                //ZIP_CD = provider.ZIP_CD,
                STATE_CD = provider.STATE_CD,
                //PHNE_NUM = provider.PHNE_NUM,
                //FAX_PHNE_NUM = provider.FAX_PHNE_NUM,
                ELGBLTY_SW = provider.ELGBLTY_SW,
                CMPLNC_STUS_CD = provider.CMPLNC_STUS_CD,
                ORGNL_PRTCPTN_DT = provider.ORGNL_PRTCPTN_DT,
                CRTFCTN_DT = provider.CRTFCTN_DT,
                TRMNTN_EXPRTN_DT = provider.TRMNTN_EXPRTN_DT,
                //PGM_TRMNTN_CD = provider.PGM_TRMNTN_CD,
                //ACRDTN_TYPE_CD = provider.ACRDTN_TYPE_CD,
                //ACRDTN_EFCTV_DT = provider.ACRDTN_EFCTV_DT,
                //ACRDTN_EXPRTN_DT = provider.ACRDTN_EXPRTN_DT,
                //INTRMDRY_CARR_CD = provider.INTRMDRY_CARR_CD,
                //Comment = provider.Comment

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
                BED_CNT = viewModel.BED_CNT,
                FAC_NAME = viewModel.FAC_NAME,
                ST_ADR = viewModel.ST_ADR,
                CITY_NAME = viewModel.CITY_NAME,
                ZIP_CD = viewModel.ZIP_CD,
                STATE_CD = viewModel.STATE_CD,
                PHNE_NUM = viewModel.PHNE_NUM,
                FAX_PHNE_NUM = viewModel.FAX_PHNE_NUM,
                ELGBLTY_SW = viewModel.ELGBLTY_SW,
                CMPLNC_STUS_CD = viewModel.CMPLNC_STUS_CD,
                ORGNL_PRTCPTN_DT = viewModel.ORGNL_PRTCPTN_DT,
                CRTFCTN_DT = viewModel.CRTFCTN_DT,
                TRMNTN_EXPRTN_DT = viewModel.TRMNTN_EXPRTN_DT,
                PGM_TRMNTN_CD = viewModel.PGM_TRMNTN_CD,
                ACRDTN_TYPE_CD = viewModel.ACRDTN_TYPE_CD,
                ACRDTN_EFCTV_DT = viewModel.ACRDTN_EFCTV_DT,
                ACRDTN_EXPRTN_DT = viewModel.ACRDTN_EXPRTN_DT,
                INTRMDRY_CARR_CD = viewModel.INTRMDRY_CARR_CD,
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
                    BED_CNT = SingleProvider.BED_CNT,
                    FAC_NAME = SingleProvider.FAC_NAME,
                    ST_ADR = SingleProvider.ST_ADR,
                    CITY_NAME = SingleProvider.CITY_NAME,
                    ZIP_CD = SingleProvider.ZIP_CD,
                    STATE_CD = SingleProvider.STATE_CD,
                    PHNE_NUM = SingleProvider.PHNE_NUM,
                    FAX_PHNE_NUM = SingleProvider.FAX_PHNE_NUM,
                    ELGBLTY_SW = SingleProvider.ELGBLTY_SW,
                    CMPLNC_STUS_CD = SingleProvider.CMPLNC_STUS_CD,
                    ORGNL_PRTCPTN_DT = SingleProvider.ORGNL_PRTCPTN_DT,
                    CRTFCTN_DT = SingleProvider.CRTFCTN_DT,
                    TRMNTN_EXPRTN_DT = SingleProvider.TRMNTN_EXPRTN_DT,
                    PGM_TRMNTN_CD = SingleProvider.PGM_TRMNTN_CD,
                    ACRDTN_TYPE_CD = SingleProvider.ACRDTN_TYPE_CD,
                    ACRDTN_EFCTV_DT = SingleProvider.ACRDTN_EFCTV_DT,
                    ACRDTN_EXPRTN_DT = SingleProvider.ACRDTN_EXPRTN_DT,
                    INTRMDRY_CARR_CD = SingleProvider.INTRMDRY_CARR_CD,
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
                BED_CNT = provider.BED_CNT,
                FAC_NAME = provider.FAC_NAME,
                ST_ADR = provider.ST_ADR,
                CITY_NAME = provider.CITY_NAME,
                ZIP_CD = provider.ZIP_CD,
                STATE_CD = provider.STATE_CD,
                PHNE_NUM = provider.PHNE_NUM,
                FAX_PHNE_NUM = provider.FAX_PHNE_NUM,
                ELGBLTY_SW = provider.ELGBLTY_SW,
                CMPLNC_STUS_CD = provider.CMPLNC_STUS_CD,
                ORGNL_PRTCPTN_DT = provider.ORGNL_PRTCPTN_DT,
                CRTFCTN_DT = provider.CRTFCTN_DT,
                TRMNTN_EXPRTN_DT = provider.TRMNTN_EXPRTN_DT,
                PGM_TRMNTN_CD = provider.PGM_TRMNTN_CD,
                ACRDTN_TYPE_CD = provider.ACRDTN_TYPE_CD,
                ACRDTN_EFCTV_DT = provider.ACRDTN_EFCTV_DT,
                ACRDTN_EXPRTN_DT = provider.ACRDTN_EXPRTN_DT,
                INTRMDRY_CARR_CD = provider.INTRMDRY_CARR_CD,
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