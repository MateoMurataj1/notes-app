using NotesProject.Models.Domain;
using NotesProject.Models.DTO;

namespace NotesProject.Repositories
{
    public interface INotesRepository
    {
        Task<List<Notes>> GetAllAsync();
        Task<Notes> GetByIdAsync(int id);
        Task<Notes> CreateAsync(Notes notes);
        Task<Notes> UpdateAsync(int id, Notes notes);
        Task<Notes> DeleteAsync(int id);

    }
}
