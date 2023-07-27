namespace BookStoreWebAPI.API.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public double Price { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }        //Navigate Properties
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
