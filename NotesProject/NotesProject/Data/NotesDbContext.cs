using Microsoft.EntityFrameworkCore;
using NotesProject.Models.Domain;

namespace NotesProject.Data
{
    public class NotesDbContext: DbContext
    {
        public NotesDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<Notes> Notes { get; set; }
    }
}
