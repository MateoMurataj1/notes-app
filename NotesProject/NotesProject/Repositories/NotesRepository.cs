using Microsoft.EntityFrameworkCore;
using NotesProject.Data;
using NotesProject.Models.Domain;

namespace NotesProject.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesDbContext dbContext;

        public NotesRepository(NotesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Notes>> GetAllAsync()
        {
            return await dbContext.Notes.ToListAsync();
        }

        public async Task<Notes> GetByIdAsync(int id)
        {
            return await dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Notes> CreateAsync(Notes notes)
        {
            notes.CreatedAt = DateTime.Now;
            notes.ModifiedAt = DateTime.Now;

            await dbContext.Notes.AddAsync(notes);
            await dbContext.SaveChangesAsync();
            return notes;
        }

        public async Task<Notes> UpdateAsync(int id, Notes notes)
        {
            var existingNote = await dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingNote == null)
            {
                return null;
            }

            existingNote.Content = notes.Content;
            existingNote.ModifiedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();
            return existingNote;
        }

        public async Task<Notes> DeleteAsync(int id)
        {
            var existingNote = await dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingNote == null)
            {
                return null;
            }

            dbContext.Notes.Remove(existingNote);
            await dbContext.SaveChangesAsync();
            return existingNote;
        }
    }
}
