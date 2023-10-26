using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NotesProject.Data;
using NotesProject.Models.Domain;
using NotesProject.Models.DTO;
using NotesProject.Repositories;

namespace NotesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepository notesRepository;
        public NotesController(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await notesRepository.GetAllAsync();

            var notesDto = new List<NotesDto>();
            foreach (var noteDomain in notes)
            {
                notesDto.Add(new NotesDto()
                {
                    Id = noteDomain.Id,
                    Content = noteDomain.Content,
                    ModifiedAt = noteDomain.ModifiedAt
                });
            }

            var jsonData = JsonConvert.SerializeObject(notesDto);

            return Ok(jsonData);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var note = await notesRepository.GetByIdAsync(id);

            if(note == null)
            {
                return NotFound();
            }

            var noteDto = new NotesDto()
            {
                Content = note.Content,
                ModifiedAt = note.ModifiedAt
            };

            var jsonData = JsonConvert.SerializeObject(noteDto);
            return Ok(jsonData);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddNoteRequestDto addNoteRequestDto)
        {
            var note = new Notes
            {
                Title = addNoteRequestDto.Title,
                Content = addNoteRequestDto.Content,
                //CreatedAt = addNoteRequestDto.CreatedAt,
                //ModifiedAt = addNoteRequestDto.ModifiedAt,
                Author = addNoteRequestDto.Author
            };

            note = await notesRepository.CreateAsync(note);

            var noteDto = new NotesDto
            {
                Content = note.Content,
                ModifiedAt = note.ModifiedAt
            };

            //return CreatedAtAction(nameof(GetAll), noteDto);
            return Ok(noteDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, UpdateNoteRequestDto updateNoteRequestDto)
        {
            var note = new Notes
            {
                Content = updateNoteRequestDto.Content
            };

            note = await notesRepository.UpdateAsync(id, note);

            if(note == null)
            {
                return NotFound();
            }

            var noteDto = new NotesDto
            {
                Content = note.Content,
                ModifiedAt = note.ModifiedAt
            };

            return Ok(noteDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var note = await notesRepository.DeleteAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            var noteDto = new NotesDto()
            {
                Content = note.Content,
            };

            return Ok(noteDto);
        }
    }
}
