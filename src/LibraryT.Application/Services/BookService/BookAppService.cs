using Abp.Application.Services;
using Abp.Domain.Repositories;
using LibraryT.Domain;
using LibraryT.Services.BookService.Dto;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<BookDto> CreateAsync(BookDto input)
        {
            try
            {
                var book = ObjectMapper.Map<Book>(input);
                Console.WriteLine(input.CategoryId); // Assuming CategoryId is present in BookDto
                book.Category = await _categoryRepository.GetAsync(input.CategoryId);
                var result = await _repository.InsertAsync(book);
                return ObjectMapper.Map<BookDto>(result);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                Console.WriteLine(ex.Message);
                throw; // Rethrow the exception after logging
            }
        }

        public async Task<List<BookDto>> GetAllIncluding(Guid categoryId)
        {
            var books = await _repository.GetAll()
                                         .Include(e => e.Category)
                                         .Where(e => e.Category.Id == categoryId)
                                         .ToListAsync();

            return ObjectMapper.Map<List<BookDto>>(books);
        }
    }
}
