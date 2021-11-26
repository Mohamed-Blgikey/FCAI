using AutoMapper;
using FCAI.BL.Interface;
using FCAI.BL.Model;
using FCAI.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCAI.Controllers
{
    public class InstractorController : Controller
    {
        #region Attribute
        private readonly IInstractorRep instractorRep;
        private readonly IMapper mapper;
        #endregion
        #region Ctor
        public InstractorController(IInstractorRep instractorRep, IMapper mapper)
        {
            this.instractorRep = instractorRep;
            this.mapper = mapper;
        }
        #endregion
        #region Actions
        [Authorize(Roles =("admin,user,super admin"))]
        public IActionResult Index()
        {
            var model = mapper.Map<IEnumerable<InstractorVM>>(instractorRep.Get());
            return View(model);
        }

        [Authorize(Roles = ("admin,super admin"))]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(InstractorVM instractorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Instractor>(instractorVM);
                    instractorRep.Create(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(instractorVM);
                }

            }
            catch (Exception)
            {
                ViewBag.x = "Check Phone Or Email Should be uniqe";
                return View(instractorVM);
            }
        }
        [Authorize(Roles = ("admin,super admin"))]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = mapper.Map<InstractorVM>(instractorRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(InstractorVM instractorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Instractor>(instractorVM);
                    instractorRep.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(instractorVM);
                }

            }
            catch (Exception)
            {
                ViewBag.x = "Check Phone Or Email Should be uniqe";
                return View(instractorVM);
            }
        }
        [Authorize(Roles = ("admin,super admin"))]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = mapper.Map<InstractorVM>(instractorRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(InstractorVM instractorVM)
        {
            try
            {

                var model = mapper.Map<Instractor>(instractorVM);
                instractorRep.Delete(model);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(instractorVM);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = mapper.Map<InstractorVM>(instractorRep.GetById(id));
            return View(model);
        }


        #endregion
    }
}
