using BlazorApp_Models;

namespace BlazorApp_Client.Service.IService
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetAll();
        public Task<ProductDto> GetById(int id);
    }
}
