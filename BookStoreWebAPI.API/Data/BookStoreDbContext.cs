using BookStoreWebAPI.API.Models.Domain;
using Microsoft.EntityFrameworkCore;namespace BookStoreWebAPI.API.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }        public DbSet<Book> Books { get; set; } //prop double tab 
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }        //srtct override Onmodel tab
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            //seeding data for Genre
            //"Fiction","Mystery","Romance","Science Fiction","Fantasy"            var genres = new List<Genre>()
            {
                new Genre()
                {
                    GenreId = Guid.Parse("2ecdf04f-70cd-4df7-aaed-5e84221cbace"),
                    GenreName = "Fiction"
                },
                new Genre()
                {
                    GenreId =Guid.Parse("9f0bfd52-5aff-4b2b-9fb4-751ec7c53be0") ,
                    GenreName = "Mystery"
                },
               new Genre()
                {
                    GenreId = Guid.Parse("25290ad1-9ff5-4ed7-817e-3d90ff2f600e"),
                    GenreName = "Romance"
                },
               new Genre()
                {
                    GenreId = Guid.Parse("f76e5b2b-8ef8-45e4-a910-93bc89e68dac"),
                    GenreName = "Science Fiction"
                },
                new Genre()
                {
                    GenreId = Guid.Parse("e786fcd3-0a66-4e12-85c4-86f27886dde4"),
                    GenreName = "Fantasy"
                }
            };
            //seeding genres to the database
            modelBuilder.Entity<Genre>().HasData(genres);            //Seed Data for Authors            var authors = new List<Author>
            {
                new Author
                {
                    AuthorId = Guid.Parse("a8210012-4e0b-4f8c-b4e0-0857e8de30b0"),
                    Name = "John Doe",
                    Country = "United States"
                },
                new Author
                {
                    AuthorId = Guid.Parse("e9831d11-87ae-4540-9b9c-3c04b3c71cc7"),
                    Name = "Jane Smith",
                    Country = "United Kingdom"
                },
                new Author
                {
                    AuthorId = Guid.Parse("92fda86a-c051-4c4d-819e-cde2abbc0971"),
                    Name = "Michael Johnson",
                    Country = "Canada"
                },
                new Author
                {
                    AuthorId = Guid.Parse("d69536a2-71c8-43ac-aed3-0209a4f5a8db"),
                    Name = "Emily Brown",
                    Country = "Australia"
                },
                new Author
                {
                    AuthorId = Guid.Parse("1f4e4f7c-6377-473f-bb25-0b31a1c95af3"),
                    Name = "William Lee",
                    Country = "India"
                },
                new Author
                {
                    AuthorId = Guid.Parse("9a1ab2f9-d8c0-4a0c-a185-40e9137ef5a2"),
                    Name = "Sophia Kim",
                    Country = "South Korea"
                }
            };            modelBuilder.Entity<Author>().HasData(authors);
        }    }
}
