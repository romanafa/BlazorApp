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
        public CategoryDto Create(CategoryDto categoryDto);
        public CategoryDto Update(CategoryDto categoryDto);
        public int Delete(int id);
        public CategoryDto GetById(int id);
        public IEnumerable<CategoryDto> GetAll();
    }
}
