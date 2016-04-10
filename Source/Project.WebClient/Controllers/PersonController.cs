
using Project.Common.Contracts;
using Project.WebClient.ViewModels;
using Project.WebClient.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Common.Models.Request;
using Project.Common.Helpers;
using Project.WebClient.Filters;

namespace Project.WebClient.Controllers
{
    public class PersonController : BaseController
    {
        public const string LIST_URL = "/Person/List/";
        public const string DETAIL_URL = "/Person/Detail/";

        IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ViewResult List(int skip = 0, int take = 100, string filter = "")
        {
            if (skip < 0)
            {
                skip = 0;
            }

            if (take > 100)
            {
                take = 100;
            }

            if (filter.Length > 10)
            {
                filter = filter.Substring(0, 10);
            }

            var request = new PersonSelectPageRequest(skip, take, filter);
            var response = _personService.SelectPage(request);
                        
            var model = new PersonPageViewModel();
            model.TotalCount = response.TotalCount;

            foreach (var item in response.Items)
            {
                var mapped = PersonMapper.MapViewModelFromModel(item);
                model.Items.Add(mapped);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(string uid)
        {
            var request = new PersonSelectRequest(uid);

            if (request.IsNotValid())
            {
                return RedirectToNotFound();
            }

            var response = _personService.Select(request);
            if (response.Status)
            {
                var model = PersonMapper.MapViewModelFromModel(response.Model);
                return View(model);
            }

            return RedirectToNotFound();
        }

        [HttpGet]
        public ActionResult Edit(string uid)
        {
            var request = new PersonSelectRequest(uid);

            if (request.IsNotValid())
            {
                return RedirectToNotFound();
            }

            var response = _personService.Select(request);
            if (!response.Status)
            {
                return RedirectToNotFound();
            }

            var model = PersonMapper.MapViewModelFromModel(response.Model);
            return View(model);
        }

        [HttpPost,
         ValidateAntiForgeryToken,
         Journal(Message = "Person Editted")]
        public ActionResult Edit(PersonViewModel model)
        {
            if (model == null)
            {
                return View();
            }

            var request = PersonMapper.MapUpdateRequestFromViewModel(model);
            if (request.IsNotValid())
            {
                model.Message = ConstHelper.REQUEST_NOT_VALID;
                return View(model);
            }

            var response = _personService.Update(request);
            if (response.Status)
            {
                return Redirect($"{DETAIL_URL}?uid={response.Model.UId}");
            }

            model.Message = response.Message;
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost,
         ValidateAntiForgeryToken,
         Journal(Message = "Person Inserted")]
        public ActionResult New(PersonViewModel model)
        {
            if (model == null)
            {
                return View();
            }

            var request = PersonMapper.MapRequestFromViewModel(model);
            if (request.IsNotValid())
            {
                model.Message = ConstHelper.REQUEST_NOT_VALID;
                return View(model);
            }

            var response = _personService.Insert(request);
            if (response.Status)
            {
                return Redirect($"{DETAIL_URL}?uid={response.Model.UId}");
            }

            model.Message = response.Message;
            return View(model);
        }


    }
}