using Microsoft.EntityFrameworkCore;

namespace PersonApi.Data
{
    public class LorenzContext : DbContext
    {
        public LorenzContext(DbContextOptions<LorenzContext> options)
            : base(options) 
        {

        }
    }
}
