namespace Vagant.Web.Models.Profile
{
    public class BaseProfileViewModel: BaseViewModel
    {
        #region Properties

        public string UserPhotoUrl { get; set; }
        public bool IsPhotoEditable { get; set; }

        public string UserName { get; set; }

        #endregion
    }
}