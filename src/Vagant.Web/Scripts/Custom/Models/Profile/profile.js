var Profile = Profile || {};
Profile.constructors = Profile.constructors || {};

Profile.constructors.Profile = (function ($, ko) {

    function ProfilePage() {
        var self = this;

        self.contactInformation = new Profile.constructors.ContactInformation();
        self.achievements = new Profile.constructors.Achievements();
        self.profileHistory = new Profile.constructors.ProfileHistory();
    }

    ko.applyBindings(new ProfilePage());
    return ProfilePage();

})(jQuery, ko);