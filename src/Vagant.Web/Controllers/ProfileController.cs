using Agile.Web.Framework.ActionResults;
using System;
using System.Web.Mvc;
using Vagant.Web.Models.Message;
using Vagant.Web.Models.Profile;

namespace Vagant.Web.Controllers
{
    public class ProfileController : BaseController
    {
        #region Ctor

        public ProfileController()
        {
        }

        #endregion

        #region Actions

        public ActionResult Index(string userId)
        {
            try
            {
                var viewModel = GetEditableProfileViewModel(userId);
                return View(viewModel);
            }
            catch (Exception)
            {
                //todo: log error
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Details(string userId)
        {
            try
            {
                var viewModel = GetProfileDetailsViewModel(userId);
                return View(viewModel);
            }
            catch (Exception)
            {
                //todo: log error
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SendMessage(SendMessageViewModel messageModel)
        {
            try
            {
                return new SuccessJsonResult();
            }
            catch (Exception)
            {
                //todo: log error
                return new HttpBadRequestResult();
            }
        }

        #endregion

        #region Private Methods

        private EditProfileViewModel GetEditableProfileViewModel(string userId)
        {
            var result = new EditProfileViewModel();

            return result;
        }

        private ProfileDetailsViewModel GetProfileDetailsViewModel(string userId)
        {
            var result = new ProfileDetailsViewModel();

            return result;
        }

        #endregion
    }
}