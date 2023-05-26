using AutoMapper;
using BlazorApp_Business.Repository.IRepository;
using BlazorApp_DataAccess.Data;
using BlazorApp_DataAccess;
using BlazorApp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_Business.Repository
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductPriceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductPriceDto> Create(ProductPriceDto productPriceDto)
        {
            var productPrice = _mapper.Map<ProductPriceDto, ProductPrice>(productPriceDto);

            _db.ProductPrices.Add(productPrice);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductPrice, ProductPriceDto>(productPrice);
        }

        public async Task<int> Delete(int id)
        {
            var productPrice = await _db.ProductPrices.FirstOrDefaultAsync(c => c.PriceId == id);
            if (productPrice != null)
            {
                _db.ProductPrices.Remove(productPrice);
                return await _db.SaveChangesAsync();
            }
            return 0;

        }

        public async Task<IEnumerable<ProductPriceDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDto>>(_db.ProductPrices);
        }

        public async Task<ProductPriceDto> GetById(int id)
        {
            var ProductPrice = await _db.ProductPrices.FirstOrDefaultAsync(c => c.PriceId == id);
            if (ProductPrice != null)
            {
                return _mapper.Map<ProductPrice, ProductPriceDto>(ProductPrice);
            }
            return new ProductPriceDto();
        }

        public async Task<ProductPriceDto> Update(ProductPriceDto productPriceDto)
        {
            var priceFromDb = await _db.ProductPrices.FirstOrDefaultAsync(c => c.PriceId == productPriceDto.PriceId);

            if (priceFromDb != null)
            {
                priceFromDb.Price = productPriceDto.Price;
                priceFromDb.Size = productPriceDto.Size;
                priceFromDb.ProductId = productPriceDto.ProductId;
                _db.ProductPrices.Update(priceFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<ProductPrice, ProductPriceDto>(priceFromDb);
            }

            return productPriceDto;

        }
    }
}
