using System;
using Vagant.Web.Models.Location;

namespace Vagant.Web.Models.Event
{
    public class BaseEventViewModel: BaseViewModel
    {
        #region Properties

        public int EventId { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }
        public string AuthorUserId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string BriefDescription { get; set; }
        public string FullDescription { get; set; }

        public LocationViewModel Location { get; set; }

        #endregion
    }
}