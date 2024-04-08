using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using LibraryT.Authorization;
using LibraryT.Domain;
using LibraryT.Services.BookService.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryT.Services.BookService
{
    public class BookAppService : AsyncCrudAppService<Book, BookDto, Guid>
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly IRepository<Book, Guid> _repository;

        public BookAppService(IRepository<Category, Guid> categoryRepository, IRepository<Book, Guid> repository)
            : base(repository)
        {
            _categoryRepository = categoryRepository;
            _repository = repository;
        }
        [AbpAuthorize(PermissionNames.Admin_Roles)]
        [HttpPost]
        public override async Task<BookDto> CreateAsync(BookDto input)
        {
            var book = ObjectMapper.Map<Book>(input);
            book.Category = await _categoryRepository.GetAsync((Guid)input.CategoryId);
            var result = await _repository.InsertAsync(book);
            return ObjectMapper.Map<BookDto>(result);
        }

        [HttpGet]
        public async Task<List<BookDto>> GetAllBooksAsync([FromQuery]string ? filterby, [FromQuery]string ? filtervalue)
        {
            var query = _repository.GetAllIncluding(x => x.Category).AsQueryable();

            if (string.IsNullOrEmpty(filterby)==false) {
                switch (filterby)
                {
                    case "author": query=query.Where(x=>x.Author.ToLower().Contains(filtervalue.ToLower())); break;
                    case "title":query = query.Where(x => x.Title.ToLower().Contains(filtervalue.ToLower()));break;
                    case "isbn": query = query.Where(x => x.ISBN.ToLower().Contains(filtervalue.ToLower())); break;
                    case "category": query = query.Where(x => x.Category.Name.ToLower().Contains(filtervalue.ToLower())); break;
                }
            }

            /*
                        var books = await _repository.GetAllIncluding(x => x.Category).ToListAsync();*/
                        return  ObjectMapper.Map<List<BookDto>>(await query.ToListAsync());
        }

        [HttpGet]
        public async Task<List<BookDto>> GetAllBooksByCategoryAsync(Guid categoryId)
        {
            var books = await _repository.GetAllIncluding(b => b.Category).Where(b => b.Category.Id == categoryId).ToListAsync();
          

            return ObjectMapper.Map<List<BookDto>>(books);
        }
        [HttpGet]
        public async Task<List<BookDto>> GetTop5BooksByCountAsync()
        {
            var topBooks = await _repository.GetAll()
                .OrderByDescending(b => b.Count) // Order by count in descending order
                .Take(5) // Take the top 5 books
                .ToListAsync();

            return ObjectMapper.Map<List<BookDto>>(topBooks);
        }
        [HttpGet]
        public async Task<List<BookDto>> GetBooksWithCategoryNameAsync()
        {
            var topBooks = await _repository.GetAll()
                .OrderByDescending(b => b.Count) // Order by count in descending order
                .Take(5) // Take the top 5 books
                .Include(b=>b.Category)
                .ToListAsync();

            return ObjectMapper.Map<List<BookDto>>(topBooks);
        }
        [HttpGet]
        public async Task<int> GetBooksCountAsync()
        {
            return await _repository.CountAsync();
        }
    }
}
