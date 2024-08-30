using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Provent.Application.Dtos
{
    public class EventDto
    {public int Id { get; set; }
        public string Place { get; set; }

        [Required,
        StringLength(50, MinimumLength = 3, ErrorMessage = "The field {0} must have more than 3 and less than 50 characters.")]
        public string Theme { get; set; }
        public string EventDate { get; set; }

        [Range(1, 150000, ErrorMessage = "The {0} must be more than 1 and less than 150000.")]
        public int Capacity { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Not a valid image (gif, jpg, jpeg, bpm, or png).")]
        public string ImageURL { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<SocialNetworkDto> SocialNetworks { get; set; }
        public IEnumerable<SpeakerDto> Speakers { get; set; }
    }
}