using System.ComponentModel.DataAnnotations;

namespace Provent.Application.Dtos
{
    public class SocialNetworkDto
    {
        public int Id { get; set; }
        
        [Required,
        StringLength(50, MinimumLength = 1, ErrorMessage = "The field {0} must have more than 1 and less than 50 characters.")]
        public string Name { get; set; }

        [RegularExpression(@"/^(https:|http:|www\.)\S*")]
        public string URL { get; set; }
        public int? EventId { get; set; }
        public EventDto Event { get; set; }
        public int? SpeakerId { get; set; }
        public SpeakerDto Speaker { get; set; }
    }
}