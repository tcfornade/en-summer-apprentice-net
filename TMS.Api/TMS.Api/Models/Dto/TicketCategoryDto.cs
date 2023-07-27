namespace TMS.Api.Models.Dto
{
    public class TicketCategoryDto
    {
        public int TicketCategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Event { get; set; }
    }
}
