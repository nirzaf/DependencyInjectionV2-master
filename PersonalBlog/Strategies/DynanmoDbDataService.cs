using Amazon.DynamoDBv2.DataModel;
using PersonalBlog.Interface;
using PersonalBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalBlog.Strategies
{
    public class DynanmoDbDataService : IDataService
    {
        private readonly IDynamoDBContext _context;
        public DynanmoDbDataService(IDynamoDBContext context)
        {
            _context = context;
        }
        public async Task Create(Post model)
        {
            await _context.SaveAsync<Post>(model);
        }

        public async Task<List<Post>> GetAll()
        {
           return await _context.ScanAsync<Post>(new List<ScanCondition>()).GetRemainingAsync();
        }
    }
}
