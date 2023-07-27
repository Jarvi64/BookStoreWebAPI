using AutoMapper;
using BookStoreWebAPI.API.CustomActionFilters;
using BookStoreWebAPI.API.Data;
using BookStoreWebAPI.API.Models.Domain;
using BookStoreWebAPI.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;namespace BookStoreWebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;        public BooksController(BookStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        //POST : api/Books //Creating Book
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddBookDto addBookDto)
        {
            //Mappinf Dto to Domain Model            var book = mapper.Map<Book>(addBookDto);            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();            //Domain To Dto
            var bookDto = mapper.Map<BookDto>(book);
            bookDto.Id = Guid.NewGuid();            return Ok(bookDto);        }        //GET : /api/Books  //Get all books
        //Get : /api/Books?filterOn=Title&filterQuery=Sample
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filteron = null, [FromQuery] string? filterQuery = null,
            [FromQuery] string? sortBy = null, [FromQuery] bool? isAscending = null,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {            var books = dbContext.Books.Include("Author").Include("Genre").AsQueryable();
            //Filtering
            if (string.IsNullOrWhiteSpace(filteron) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filteron.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    books = books.Where(x => x.Title.Contains(filterQuery));
                }                else if (filteron.Equals("ISBN", StringComparison.OrdinalIgnoreCase))
                {
                    books = books.Where(x => x.ISBN.Contains(filterQuery));
                }            }            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    books = (bool)isAscending ? books.OrderBy(x => x.Title) : books.OrderByDescending(x => x.Title);
                }
                else if (sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    books = (bool)isAscending ? books.OrderBy(x => x.Price) : books.OrderByDescending(x => x.Price);
                }
            }            //Paging
            var skipResults = (pageNumber - 1) * pageSize;
            books = books.Skip(skipResults).Take(pageSize);
            await books.ToListAsync();
            var bookDto = mapper.Map<List<BookDto>>(books);
            return Ok(bookDto);
            //var books = await dbContext.Books.Include("Author").Include("Genre").ToListAsync();
            //var booksDto = mapper.Map<List<BookDto>>(books);
            //return Ok(booksDto);        }
        //GET : /api/Book - Get book by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var book = await dbContext.Books.Include("Author").Include("Genre").FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }
        //PUT : /api/Book - update a Book
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateBookDto updateBookDto)
        {            var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = updateBookDto.Title;
            book.ISBN = updateBookDto.ISBN;
            book.PublicationDate = updateBookDto.PublicationDate;
            book.Price = updateBookDto.Price;
            book.AuthorId = updateBookDto.AuthorId;
            book.GenreId = updateBookDto.GenreId;            await dbContext.SaveChangesAsync();            var bookDto = mapper.Map<BookDto>(book);
            return Ok(bookDto);        }        //DELETE : api/Books/{id} => Delete a book
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            dbContext.Remove(book);
            await dbContext.SaveChangesAsync();
            var bookDto = mapper.Map<BookDto>(book);
            return Ok();        }    }
}
