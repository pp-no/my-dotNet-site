using System.ComponentModel.DataAnnotations;

namespace SampleMvcApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "–¼‘O‚Í•K{‚Å‚·")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "‰¿Ši‚Í0ˆÈã‚Å“ü—Í‚µ‚Ä‚­‚¾‚³‚¢")]
        public decimal Price { get; set; }
    }
}
