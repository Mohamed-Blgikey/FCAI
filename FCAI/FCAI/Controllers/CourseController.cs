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
    public class CourseController : Controller
    {
        #region Attribute
        private readonly ICourseRep courseRep;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public CourseController(ICourseRep courseRep, IMapper mapper)
        {
            this.courseRep = courseRep;
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
        public IActionResult Create(CourseVM courseVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Course>(courseVM);
                    courseRep.Create(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(courseVM);
                }

            }
            catch (Exception)
            {

                return View(courseVM);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = mapper.Map<CourseVM>(courseRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CourseVM  courseVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Course>(courseVM);
                    courseRep.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(courseVM);
                }

            }
            catch (Exception)
            {

                return View(courseVM);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = mapper.Map<CourseVM>(courseRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(CourseVM courseVM)
        {
            try
            {

                var model = mapper.Map<Course>(courseVM);
                courseRep.Delete(model);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
                return View(courseVM);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = mapper.Map<CourseVM>(courseRep.GetById(id));
            return View(model);
        }
        #endregion
    }
}
