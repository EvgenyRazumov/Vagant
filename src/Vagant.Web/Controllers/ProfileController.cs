using System;
using System.Web.Mvc;
using Vagant.Web.Models.Profile;

namespace Vagant.Web.Controllers
{
    public class ProfileController: BaseController
    {
        #region Ctor

        public ProfileController()
        {

        }

        #endregion

        #region Actions

        public ActionResult Index(int userId)
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

        public ActionResult Details(int userId)
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

        #endregion

        #region Private Methods

        private EditProfileViewModel GetEditableProfileViewModel(int userId)
        {
            var result = new EditProfileViewModel();

            return result;
        }

        private ProfileDetailsViewModel GetProfileDetailsViewModel(int userId)
        {
            var result = new ProfileDetailsViewModel();

            return result;
        }

        #endregion
    }
}