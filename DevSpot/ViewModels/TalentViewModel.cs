using System.ComponentModel.DataAnnotations;

namespace DevSpot.ViewModels
{
    public class TalentViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Video_url { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
