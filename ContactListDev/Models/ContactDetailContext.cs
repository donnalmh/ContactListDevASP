using Microsoft.EntityFrameworkCore;

namespace ContactListDev.Models
{
    public class ContactDetailContext:DbContext
    {
        public ContactDetailContext(DbContextOptions<ContactDetailContext> options) : base(options)
        {

        }

        public DbSet<ContactDetail> Contact { get; set; }
    }
}
