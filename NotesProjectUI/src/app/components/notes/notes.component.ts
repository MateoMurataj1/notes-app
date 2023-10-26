import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NotesService } from 'src/app/services/notes.service';
import { CreateNoteComponent } from '../create-note/create-note.component';
import { UpdateNoteComponent } from '../update-note/update-note.component';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit{

  notes: any;

  constructor(private notesService: NotesService, public dialog: MatDialog){}
  
  ngOnInit(): void {
    this.getAllNotes();
  }

  getAllNotes(){
    this.notesService.getNotes().subscribe(data =>{
      console.log(data,"data")
      this.notes = data;

    })
  }

  toggleNote(note: any) {
    note.expanded = !note.expanded;
    console.log(note)
    console.log(note.expanded)
  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(CreateNoteComponent, {
      width: '850px',
      height: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }

  deleteNote(id: number){
    this.notesService.deleteNote(id).subscribe(data =>{
      this.getAllNotes();
    })
  }

  editNote(id: number){
    this.dialog.open(UpdateNoteComponent, {
      width: '850px',
      height: '250px',
      data: id
    });
  }


}
