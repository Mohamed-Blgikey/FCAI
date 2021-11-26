using AutoMapper;
using FCAI.BL.Interface;
using FCAI.BL.Model;
using FCAI.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCAI.Controllers
{
    public class StudentController : Controller
    {
        

        #region Attribute
        private readonly IStudentRep studentRep;
        private readonly IMapper mapper;
        #endregion
        #region Ctor
        public StudentController(IStudentRep studentRep, IMapper mapper)
        {
            this.studentRep = studentRep;
            this.mapper = mapper;
        }
        #endregion
        #region Actions
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentVM studentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Student>(studentVM);
                    studentRep.Create(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(studentVM);
                }

            }
            catch (Exception)
            {
                ViewBag.x = "Check Code Or Email Should be uniqe";
                return View(studentVM);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = mapper.Map<StudentVM>(studentRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(StudentVM studentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Student>(studentVM);
                    studentRep.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(studentVM);
                }

            }
            catch (Exception)
            {
                ViewBag.x = "Check Code Or Email Should be uniqe";
                return View(studentVM);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = mapper.Map<StudentVM>(studentRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(StudentVM studentVM)
        {
            try
            {

                var model = mapper.Map<Student>(studentVM);
                studentRep.Delete(model);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(studentVM);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = mapper.Map<StudentVM>(studentRep.GetById(id));
            return View(model);
        }


        #endregion
    }
}
