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
    public class TopicController : Controller
    {
        #region Attribute
        private readonly ITopicRep topicRep;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public TopicController(ITopicRep topicRep, IMapper mapper)
        {
            this.topicRep = topicRep;
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
        public IActionResult Create(TopicVM topicVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Topic>(topicVM);
                    topicRep.Create(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(topicVM);
                }

            }
            catch (Exception)
            {

                return View(topicVM);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = mapper.Map<TopicVM>(topicRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(TopicVM topicVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Topic>(topicVM);
                    topicRep.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(topicVM);
                }

            }
            catch (Exception)
            {

                return View(topicVM);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = mapper.Map<TopicVM>(topicRep.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(TopicVM topicVM)
        {
            try
            {

                var model = mapper.Map<Topic>(topicVM);
                topicRep.Delete(model);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
                return View(topicVM);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = mapper.Map<TopicVM>(topicRep.GetById(id));
            return View(model);
        }
        #endregion
    }
}
