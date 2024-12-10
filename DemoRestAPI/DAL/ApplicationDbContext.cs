using DemoRestAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoRestAPI.DAL
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{


		}

        public DbSet<Employee> Emps { get; set; }
    }
}
