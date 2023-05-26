using BlazorApp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Business.Repository.IRepository
{
    public interface IProductPriceRepository
    {
        public Task<ProductPriceDto> Create(ProductPriceDto productPriceDto);
        public Task<ProductPriceDto> Update(ProductPriceDto productPriceDto);
        public Task<int> Delete(int id);
        public Task<ProductPriceDto> GetById(int id);
        public Task<IEnumerable<ProductPriceDto>> GetAll();
    }
}
