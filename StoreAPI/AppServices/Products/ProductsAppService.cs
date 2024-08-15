using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Entities;

namespace StoreAPI.AppServices.Products
{
    public class ProductsAppService : IProductsAppService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductsAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDto>> GetProducts()
        {

            //var  data = await _context.Products.Select(p=>
            //new ProductDto() { Id=p.Id, Name=p.Name, Description=p.Description, CatId=p.CatId, CategoryName=p.Category.Name } ).ToListAsync();


            var data = await _context.Products
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
            return data;

        }

        public async Task<int> Create(CreateProductDto input)
        {
            var  product  =_mapper.Map<Product>(input);

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task< ProductDto?> GetById(int id)
        {
            var data = await _context.Products.Where(p=>p.Id==id)
               .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return data;

        }
    }
}
