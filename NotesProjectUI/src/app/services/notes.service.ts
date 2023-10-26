import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  private apiUrl = "https://localhost:7112/api/Notes";

  createNoteModel = this.fb.group({
    Title: [''],
    Content: [''],
    Author: ['']
  });

  updateNoteModel = this.fb.group({

    Content: [''],
  });

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  getNotes(){
    return this.http.get(this.apiUrl);
  }

  createNote(){
    var body={
      Title: this.createNoteModel.value.Title,
      Content: this.createNoteModel.value.Content,
      Author: this.createNoteModel.value.Author
    } 
    return this.http.post(this.apiUrl, body)
  }

  getNoteById(id: number){
    return this.http.get(`${this.apiUrl}/${id}`)
  }

  updateNote(id: number, ){
    var body={
      Content: this.updateNoteModel.value.Content,
    }
    return this.http.put(`${this.apiUrl}/${id}`, body);
  }

  deleteNote(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`)
  }
}
