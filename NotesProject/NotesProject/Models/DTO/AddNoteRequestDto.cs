namespace NotesProject.Models.DTO
{
    public class AddNoteRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime ModifiedAt { get; set; }
        public string? Author { get; set; }
    }
}
