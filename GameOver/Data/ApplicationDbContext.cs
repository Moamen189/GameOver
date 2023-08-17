using Microsoft.EntityFrameworkCore;

namespace GameOver.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
    }
}
