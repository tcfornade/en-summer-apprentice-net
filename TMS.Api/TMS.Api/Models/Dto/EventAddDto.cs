namespace TMS.Api.Models.Dto
{
    public class EventAddDto
    {
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public int EventTypeId { get; set; }
        public int VenueId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
