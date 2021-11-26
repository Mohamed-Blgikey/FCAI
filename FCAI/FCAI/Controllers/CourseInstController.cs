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
    public class CourseInstController : Controller
    {
        private readonly ICourseInstRep courseInstRep;
        private readonly IMapper mapper;

        public CourseInstController(ICourseInstRep courseInstRep, IMapper mapper)
        {
            this.courseInstRep = courseInstRep;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(CourseInstVM courseInstVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<CourseInst>(courseInstVM);
                    courseInstRep.addCourse(model);
                    return RedirectToAction("Index");
                }
                else
                    return View(courseInstVM);
            }
            catch (Exception)
            {
                return View(courseInstVM);
            }
        }


        [HttpGet]
        public IActionResult Edit(int idInst,int idCrs)
        {
            var model = mapper.Map<CourseInstVM>(courseInstRep.GetById(idInst,idCrs));
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CourseInstVM courseInstVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<CourseInst>(courseInstVM);
                    courseInstRep.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(courseInstVM);
                }

            }
            catch (Exception)
            {

                return View(courseInstVM);
            }
        }


        [HttpGet]
        public IActionResult Delete(int idInst, int idCrs)
        {
            var model = mapper.Map<CourseInstVM>(courseInstRep.GetById(idInst, idCrs));
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(CourseInstVM courseInstVM)
        {
            try
            {
                
                    var model = mapper.Map<CourseInst>(courseInstVM);
                    courseInstRep.Delete(model);
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(courseInstVM);
            }
        }


    }
}
