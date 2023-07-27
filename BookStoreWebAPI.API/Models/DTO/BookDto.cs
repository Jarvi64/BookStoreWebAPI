using BookStoreWebAPI.API.Models.Domain;namespace BookStoreWebAPI.API.Models.DTO
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public double Price { get; set; }        //public Guid AuthorId { get; set; }
        //public Guid GenreId { get; set; }        //Navigate Properties
        public AuthorDto Author { get; set; }
        public GenreDto Genre { get; set; }
    }
}
