using System;
using System.ComponentModel;
using Vagant.Web.Models.Location;

namespace Vagant.Web.Models.Event
{
    public class BaseEventViewModel : BaseViewModel
    {
        public BaseEventViewModel()
        {
            EventInstruments = new EventInstrumentsViewModel();
            Location = new LocationViewModel();
        }

        #region Properties

        public int EventId { get; set; }

        public string Title { get; set; }

        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [DisplayName("End Time")]
        public DateTime? EndTime { get; set; }

        [DisplayName("Brief Description")]
        public string BriefDescription { get; set; }

        [DisplayName("Full Description")]
        public string FullDescription { get; set; }

        public int? LogoId { get; set; }

        public int? AudioId { get; set; }

        [DisplayName("Instruments")]
        public EventInstrumentsViewModel EventInstruments { get; set; }

        public LocationViewModel Location { get; set; }

        #endregion
    }
}