using BlazorApp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDto> Create(CategoryDto categoryDto);
        public Task<CategoryDto> Update(CategoryDto categoryDto);
        public Task<int> Delete(int id);
        public Task<CategoryDto> GetById(int id);
        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}
