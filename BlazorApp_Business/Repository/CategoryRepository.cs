using BlazorApp_Business.Repository.IRepository;
using BlazorApp_DataAccess.Data;
using BlazorApp_DataAccess;
using BlazorApp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);
            category.CreatedDate = DateTime.Now;

            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDto>(category);
        }

        public async Task<int> Delete(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(category != null)
            {
                _db.Categories.Remove(category);
                return await _db.SaveChangesAsync();
            }
            return 0;

        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_db.Categories);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                return _mapper.Map<Category, CategoryDto>(category);
            }
            return new CategoryDto();
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            var categoryFromDb = await _db.Categories.FirstOrDefaultAsync(c => c.Id == categoryDto.Id);

            if(categoryFromDb != null)
            {
                categoryFromDb.Name = categoryDto.Name;
                _db.Categories.Update(categoryFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDto>(categoryFromDb);
            }

            return categoryDto;

        }
    }
}
