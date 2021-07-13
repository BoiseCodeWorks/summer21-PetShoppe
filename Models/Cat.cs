using System.ComponentModel.DataAnnotations;

namespace PetShoppe.Models
{
    public class Cat
    {
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
}