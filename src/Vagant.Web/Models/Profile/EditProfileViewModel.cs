using Vagant.Web.Models.Achievement;
using Vagant.Web.Models.ContactInfo;
using Vagant.Web.Models.ProfileHistory;

namespace Vagant.Web.Models.Profile
{
    public class EditProfileViewModel : BaseProfileViewModel
    {
        #region Ctor

        public EditProfileViewModel()
        {
            ContactInfo = new EditContactInfoViewModel();
            Achievements = new AchievementSectionViewModel();
            History = new ProfileHistoryViewModel();
        }

        #endregion

        #region Properties

        public EditContactInfoViewModel ContactInfo { get; set; }

        public AchievementSectionViewModel Achievements { get; set; }

        public double OverallRate { get; set; }

        public ProfileHistoryViewModel History { get; set; }

        #endregion
    }
}