using MySQL.Data;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MySQL.Models
{
    public static class SampleData
    {
        public static async Task InitializeBlog(IServiceProvider serviceProvider)
        {
            try
            {
                var db = serviceProvider.GetService<BlogContext>();
                await db.Database.EnsureCreatedAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
                        
        }
    }
}
