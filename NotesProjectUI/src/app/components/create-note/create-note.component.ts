import { Component } from '@angular/core';
import { NotesService } from 'src/app/services/notes.service';

@Component({
  selector: 'app-create-note',
  templateUrl: './create-note.component.html',
  styleUrls: ['./create-note.component.scss']
})
export class CreateNoteComponent {
  
  constructor(public notesService: NotesService) { }

  createNote(){
    this.notesService.createNote().subscribe(data =>{
      console.log(data,"dataaa")
    })
  }
}
