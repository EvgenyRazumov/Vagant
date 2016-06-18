using Vagant.Web.Models.Achievement;
using Vagant.Web.Models.ProfileHistory;

namespace Vagant.Web.Models.Profile
{
    public class BaseProfileViewModel: BaseViewModel
    {
        #region Ctor

        public BaseProfileViewModel()
        {
            Achievements = new AchievementSectionViewModel();
            History = new ProfileHistoryViewModel();
        }

        #endregion

        #region Properties

        public string UserPhotoUrl { get; set; }
        public bool IsPhotoEditable { get; set; }

        public string UserName { get; set; }

        public AchievementSectionViewModel Achievements { get; set; }

        public double OverallRate { get; set; }

        public ProfileHistoryViewModel History { get; set; }

        #endregion
    }
}