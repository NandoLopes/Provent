using System;
using System.ComponentModel.DataAnnotations;

namespace Provent.Application.Dtos
{
    public class BatchDto
    {
        public int Id { get; set; }

        [Required,
        StringLength(50, MinimumLength = 3, ErrorMessage = "The field {0} must have more than 3 and less than 50 characters.")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }

        [Range(1, 150000, ErrorMessage = "The {0} must be more than 1 and less than 150000.")]
        public int Quantity { get; set; }
        public int EventId { get; set; }
        public EventDto Event { get; set; }
    }
}