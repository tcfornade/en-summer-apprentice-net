namespace TMS.Api.Models.Dto
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string EventDescription { get; set; } = string.Empty;
        public string EventName { get; set; }
        public string EventType { get; set; } = string.Empty;

        public string Venue { get; set; }

        public List<TicketCategoryDto>TicketCategory { get; set; }
        //..
        //public string EventTypeName { get; set; }

    }
}
