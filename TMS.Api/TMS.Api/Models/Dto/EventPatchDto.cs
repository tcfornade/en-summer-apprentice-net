﻿namespace TMS.Api.Models.Dto
{
    public class EventPatchDto
    {
        public int EventId { get; set; }
        public string EventDescription { get; set; } = string.Empty;
        public string EventName { get; set; }

    }
}
