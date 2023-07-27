﻿using BookStoreWebAPI.API.Models.Domain;
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public double Price { get; set; }
        //public Guid GenreId { get; set; }
        public AuthorDto Author { get; set; }
        public GenreDto Genre { get; set; }
    }
}