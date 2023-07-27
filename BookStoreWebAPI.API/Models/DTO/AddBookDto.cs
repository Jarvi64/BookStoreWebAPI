using System.ComponentModel.DataAnnotations;namespace BookStoreWebAPI.API.Models.DTO
{
    public class AddBookDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(10)]
        public string ISBN { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        [Range(0, 10000)]
        public double Price { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public Guid GenreId { get; set; }
    }
}
