﻿using AutoMapper;
using BookStoreWebAPI.API.CustomActionFilters;
using BookStoreWebAPI.API.Data;
using BookStoreWebAPI.API.Models.Domain;
using BookStoreWebAPI.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IActionResult> GetAll()
        {
            var authors = await dbContext.Authors.ToListAsync();
            var authorsDto = mapper.Map<List<AuthorDto>>(authors);
            return Ok(authorsDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var author = await dbContext.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            var authorDto = mapper.Map<AuthorDto>(author);
            return Ok(authorDto);
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddAuthorDto addAuthorDto)
        {
            var author = mapper.Map<Author>(addAuthorDto);
            await dbContext.SaveChangesAsync();
            var authorDto = mapper.Map<AuthorDto>(author);
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAuthorDto updateAuthorDto)
        {
            if (author == null) { return NotFound(); }
            //updating author with new Dto info
            author.Country = updateAuthorDto.Country;
            //domain to Dto
            var authorDto = mapper.Map<AuthorDto>(author);
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var author = await dbContext.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
            if (author == null) { return NotFound(); };
            dbContext.Remove(author);
            await dbContext.SaveChangesAsync();
            var authorDto = mapper.Map<AuthorDto>(author);
            //var authorDto = new AuthorDto()
            //{
            //    AuthorId = author.AuthorId,
            //    Name = author.Name,
            //    Country = author.Country,
            //};
            return Ok(authorDto);
        }
    }
}