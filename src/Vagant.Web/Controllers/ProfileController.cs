﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vagant.Domain.Models;
using Vagant.Domain.Services;
using Vagant.Web.Models.Profile;
using Vagant.Web.Models.ProfileHistory;

namespace Vagant.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IEventService _eventService;

        #region Ctor

        public ProfileController(IEventService eventService)
        {
            _eventService = eventService;
        }

        #endregion

        #region Actions

        [HttpGet]
        [Authorize]
        public ActionResult Details(string userId)
        {
            try
            {
                var userEvents = _eventService.GetUserEvents(userId);
                var viewModel = GetProfileDetailsViewModel(userId, userEvents);
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

        private ProfileDetailsViewModel GetProfileDetailsViewModel(string userId, IList<EventModel> userEvents)
        {
            var result = new ProfileDetailsViewModel();
            if (UserId == userId)
            {
                result.HistoryItems = userEvents
                                        .OrderBy(x => x.StartTime)
                                        .Select(GetProfileHistoryItemViewModel).ToList();
            }

            return result;
        }

        private ProfileHistoryItemViewModel GetProfileHistoryItemViewModel(EventModel model)
        {
            return new ProfileHistoryItemViewModel
            {
                EventDate = model.StartTime,
                EventName = model.Title,
                EventId = model.Id,
                EventRate = model.Rate
            };
        }

        #endregion
    }
}