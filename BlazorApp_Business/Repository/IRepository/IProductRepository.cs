using BlazorApp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Business.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<ProductDto> Create(ProductDto productDto);
        public Task<ProductDto> Update(ProductDto productDto);
        public Task<int> Delete(int id);
        public Task<ProductDto> GetById(int id);
        public Task<IEnumerable<ProductDto>> GetAll();
    }
}
