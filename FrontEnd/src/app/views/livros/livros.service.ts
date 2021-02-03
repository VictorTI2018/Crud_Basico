import { MessageOptions } from './../categorias/categorias.service';
import { MatSnackBar } from '@angular/material/snack-bar'
import { Observable } from 'rxjs';
import { HttpClient, HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Livro } from '../../models/livros/livro.model'



@Injectable({
  providedIn: 'root'
})
export class LivrosService {

  baseUrl = 'livro'

  constructor(private httpClient: HttpClient, private snackBar: MatSnackBar) { }

  showMessage(messaOptions: MessageOptions): void {
    this.snackBar.open(messaOptions.msg, 'X', {
      duration: messaOptions.duration,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: messaOptions.classColor
    })
  }

  getAll (idCategoria: number): Observable<Livro[]> {
    const urlBase = `${this.baseUrl}/${idCategoria}`
    return this.httpClient.get<Livro[]>(urlBase)
  }

  getOne(id: number): Observable<Livro> {
    const urlBase = `${this.baseUrl}/obter/${id}`
    return this.httpClient.get<Livro>(urlBase)
  }

  create (livro: Livro): Observable<Livro> {
    return this.httpClient.post<Livro>(this.baseUrl, livro)
  }

  update(livro: Livro): Observable<Livro> {
    return this.httpClient.put<Livro>(this.baseUrl, livro)
  }

  delete (id: number): Observable<boolean> {
    const urlBase = `${this.baseUrl}/${id}`
    return this.httpClient.delete<boolean>(urlBase)
  }
}
