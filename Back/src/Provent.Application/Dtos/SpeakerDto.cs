using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Provent.Application.Dtos
{
    public class SpeakerDto
    {
        public int Id { get; set; }

        [Required,
        StringLength(50, MinimumLength = 3, ErrorMessage = "The field {0} must have more than 3 and less than 50 characters.")]
        public string Name { get; set; }
        public string MiniResume { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Not a valid image (gif, jpg, jpeg, bpm, or png).")]
        public string ImageURL { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }
        public IEnumerable<SocialNetworkDto> SocialNetworks { get; set; }
        public IEnumerable<EventDto> Events { get; set; }
    }
}