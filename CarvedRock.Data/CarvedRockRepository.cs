using System.Diagnostics;
using CarvedRock.Data.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarvedRock.Data
{
    public class CarvedRockRepository :ICarvedRockRepository
    {
        private readonly LocalContext _ctx;
        private readonly ILogger<CarvedRockRepository> _logger;   
        private readonly ILogger _factoryLogger;     

        public CarvedRockRepository(LocalContext ctx, ILogger<CarvedRockRepository> logger,
            ILoggerFactory loggerFactory)
        {
            _ctx = ctx;
            _logger = logger;
            _factoryLogger = loggerFactory.CreateLogger("DataAccessLayer");
        }

        public async Task<List<Product>> GetProductsAsync(string category)
        {            
            _logger.LogInformation("Getting products in repository for {category}", category);
            if(category == "clothing")
            {
                var ex = new ApplicationException("Database error occured!!");
                ex.Data.Add("category", category);
                throw ex;
            }
            if (category == "equip")
            {
                throw new SqliteException("Database error occured!!", 551);
            }

            try
            {
                return await _ctx.Products.Where(p => p.Category == category || category == "all").ToListAsync();
            }
            catch(Exception ex)
            {
                var newEx = new ApplicationException("Something bad happened in database", ex);
                newEx.Data.Add("category", category);
                throw newEx;
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _ctx.Products.FindAsync(id);
        }

        public List<Product> GetProducts(string category)
        {
            return _ctx.Products.Where(p => p.Category == category || category == "all").ToList();
        }

        public Product? GetProductById(int id)
        {
            var timer = new Stopwatch();
            timer.Start();
            var product = _ctx.Products.Find(id);
            timer.Stop();

            _logger.LogDebug("Query products for {id} finished in {milliseconds} ms", id, timer.ElapsedMilliseconds);
            _factoryLogger.LogInformation("(F) Querying products for {id} finished in {ticks} ticks", id, timer.ElapsedTicks);

            return product;
        }       
    }
}