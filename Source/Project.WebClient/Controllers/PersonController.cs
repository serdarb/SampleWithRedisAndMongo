
using Project.Common.Contracts;
using Project.WebClient.ViewModels;
using Project.WebClient.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Common.Models.Request;

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
            var model = _personService.SelectPage(request);

            //todo: implement
            
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(PersonViewModel model)
        {
            if (model == null)
            {
                return View();
            }

            var request = PersonMapper.MapRequestFromViewModel(model);
            if (request.IsNotValid())
            {
                model.Message = "Request is not valid!";
                return View(model);
            }

            var response = _personService.Insert(request);
            if (response.Status)
            {
                return Redirect($"{DETAIL_URL}{response.Model.UId}");
            }

            model.Message = response.Message;
            return View(model);
        }
    }
}