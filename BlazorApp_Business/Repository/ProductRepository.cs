using AutoMapper;
using BlazorApp_Business.Repository.IRepository;
using BlazorApp_DataAccess;
using BlazorApp_DataAccess.Data;
using BlazorApp_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);

            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<int> Delete(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(c => c.ProductId == id);
            if (product != null)
            {
                _db.Products.Remove(product);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_db.Products);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(c => c.ProductId == id);
            if (product != null)
            {
                return _mapper.Map<Product, ProductDto>(product);
            }
            return new ProductDto();
        }

        public async Task<ProductDto> Update(ProductDto productDto)
        {
            var productFromDb = await _db.Products.FirstOrDefaultAsync(c => c.ProductId == productDto.ProductId);

            if (productFromDb != null)
            {
                productFromDb.ProductName = productDto.ProductName;
                productFromDb.Description = productDto.Description;
                productFromDb.ImageUrl = productDto.ImageUrl;
                productFromDb.Color = productDto.Color;
                productFromDb.IsCustomersFavorite = productDto.IsCustomersFavorite;
                productFromDb.CategoryId = productDto.CategoryId;

                _db.Products.Update(productFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDto>(productFromDb);
            }

            return productDto;
        }
    }
}
