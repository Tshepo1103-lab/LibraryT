using Abp.Application.Services;
using Abp.Domain.Repositories;
using LibraryT.Domain;
using LibraryT.Services.CategoryService.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.CategoryService
{
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, Guid>
    {
        private readonly IRepository<Shelf,Guid> _shelfRepository;
        private readonly IRepository<Category, Guid> _repository;
        public CategoryAppService(IRepository<Shelf, Guid> shelfRepository, IRepository<Category, Guid> repository) : base(repository)
        {
            _shelfRepository =shelfRepository;
            _repository = repository;
        }
        public override async Task<CategoryDto> CreateAsync(CategoryDto input)
        {
            try
            {
                var category = ObjectMapper.Map<Category>(input);
                Console.WriteLine(input.ShelfId);
                category.Shelf = await _shelfRepository.GetAsync(input.ShelfId); // Assuming GetAsync exists
                var result = await _repository.InsertAsync(category);
                return ObjectMapper.Map<CategoryDto>(result);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                Console.WriteLine(ex.Message);
                throw; // Rethrow the exception after logging
            }
        }

        public async Task<List<CategoryDto>> GetAllIncluding(Guid shelfId)
        {
            var categories = await _repository.GetAll()
                                              .Include(e => e.Shelf)
                                              .Where(e => e.Shelf.Id == shelfId)
                                              .ToListAsync();

            return ObjectMapper.Map<List<CategoryDto>>(categories);
        }

    }
}
