using System;
using System.Web.Mvc;
using Vagant.Web.Models.Event;

namespace Vagant.Web.Controllers
{
    public class EventController : BaseController
    {
        #region Ctor

        public EventController()
        {
        }

        #endregion

        #region Actions

        public ActionResult Create()
        {
            try
            {
                var viewModel = GetEmptyEventViewModel();

                return View("CreateEvent", viewModel);
            }
            catch (Exception)
            {
                //todo: log error
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var viewModel = GetEditableEventViewModel(id);

                return View("EditEvent", viewModel);
            }
            catch (Exception)
            {
                //todo: log error
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var viewModel = GetEventDetailsViewModel(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                //todo: log error
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion

        #region Private Methods

        private EditEventViewModel GetEmptyEventViewModel()
        {
            var result = new EditEventViewModel();

            result.AuthorUserId = string.Empty; //todo: get current user id
            result.AuthorName = User.Identity.Name;

            return result;
        }

        private EditEventViewModel GetEditableEventViewModel(int eventId)
        {
            var result = new EditEventViewModel();

            //todo: get data from service

            return result;
        }

        private EventDetailsViewModel GetEventDetailsViewModel(int eventId)
        {
            var result = new EventDetailsViewModel();

            //todo: get data from service

            return result;
        }

        #endregion
    }
}