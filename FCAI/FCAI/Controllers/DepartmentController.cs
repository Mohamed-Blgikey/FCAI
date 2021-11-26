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
    public class DepartmentController : Controller
    {
        #region Attribute
        private readonly IDepartmentRep departmentRep;
        private readonly IMapper mapper;
        #endregion
        
        #region Ctor
        public DepartmentController(IDepartmentRep departmentRep,IMapper mapper)
        {
            this.departmentRep = departmentRep;
            this.mapper = mapper;
        } 
        #endregion  
        
        #region Actions
        public IActionResult Index()
        {
            var model = mapper.Map<IEnumerable<DepartmentVM>>(departmentRep.Get());
            return View(model);
        } 

        [Authorize(Roles =("admin,super admin"))]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM departmentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Department>(departmentVM);
                    departmentRep.Create(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(departmentVM);
                }

            }
            catch (Exception)
            {
                ViewBag.x = "Check Code Should be uniqe";

                return View(departmentVM);
            }
        }
        [Authorize(Roles = ("admin,super admin"))]

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = mapper.Map<DepartmentVM>(departmentRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM departmentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Department>(departmentVM);
                    departmentRep.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(departmentVM);
                }

            }
            catch (Exception)
            {
                ViewBag.x = "Check Code Should be uniqe";
                return View(departmentVM);
            }
        }
        [Authorize(Roles = ("admin,super admin"))]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = mapper.Map<DepartmentVM>(departmentRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(DepartmentVM departmentVM)
        {
            try
            {
                
                    var model = mapper.Map<Department>(departmentVM);
                    departmentRep.Delete(model);
                    return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
                return View(departmentVM);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = mapper.Map<DepartmentVM>(departmentRep.GetById(id));
            return View(model);
        }
        #endregion
    }
}
