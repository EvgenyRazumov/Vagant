using System;
using System.Collections.Generic;

namespace Vagant.Domain.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string BriefDescription { get; set; }

        public string FullDescription { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public double Rate { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string LocationDisplayName { get; set; }

        public int? LogoId { get; set; }

        public string AuthorId { get; set; }

        public IList<int> Images { get; set; }
    }
}
