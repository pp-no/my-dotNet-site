using System.ComponentModel.DataAnnotations;

namespace SampleMvcApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "���O�͕K�{�ł�")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "���i��0�ȏ�œ��͂��Ă�������")]
        public decimal Price { get; set; }
    }
}
