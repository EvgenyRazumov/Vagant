using System.Web.Mvc;
using Vagant.Domain.Services;

namespace Vagant.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Profile
        public ActionResult Index()
        {
            var users = _userService.GetAll();
            return View();
        }
    }
}