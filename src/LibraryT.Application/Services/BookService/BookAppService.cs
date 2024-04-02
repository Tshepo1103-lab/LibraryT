using Abp.Application.Services;
using Abp.Domain.Repositories;
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

        [HttpPost]
        public override async Task<BookDto> CreateAsync(BookDto input)
        {
            var book = ObjectMapper.Map<Book>(input);
            book.Category = await _categoryRepository.GetAsync((Guid)input.CategoryId);
            var result = await _repository.InsertAsync(book);
            return ObjectMapper.Map<BookDto>(result);
        }

        [HttpGet]
        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _repository.GetAllIncluding(x => x.Category).ToListAsync();
            return  ObjectMapper.Map<List<BookDto>>(books);
        }

        [HttpGet]
        public async Task<List<BookDto>> GetAllBooksByCategoryAsync(Guid categoryId)
        {
            var books = await _repository.GetAllIncluding(b => b.Category).Where(b => b.Category.Id == categoryId).ToListAsync();
          

            return ObjectMapper.Map<List<BookDto>>(books);
        }
    }
}
