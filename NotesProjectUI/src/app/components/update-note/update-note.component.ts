import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotesService } from 'src/app/services/notes.service';

@Component({
  selector: 'app-update-note',
  templateUrl: './update-note.component.html',
  styleUrls: ['./update-note.component.scss']
})
export class UpdateNoteComponent implements OnInit {
  
  noteId!: number;
  noteData: any = [];

  constructor(public notesService: NotesService, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.noteId = this.data;

    console.log(this.noteId," notoernek")

    this.notesService.getNoteById(this.noteId).subscribe(data =>{
      this.noteData = data;
    })
  }

  updateNote(){
    this.notesService.updateNote(this.noteId).subscribe(data =>{
      console.log(data,"dataaa")
    })
  }
}
