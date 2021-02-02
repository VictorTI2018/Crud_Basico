import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Categorias } from 'src/app/models/categorias/categoria.model';
import { MatSnackBar } from '@angular/material/snack-bar'
import { Observable } from 'rxjs';

interface MessageOptions {
    msg: string,
    duration: number,
    classColor: string
}

export interface ResponseRequest {
  status: boolean,
  resource: Categorias,
  messages: string[]
}

@Injectable({
  providedIn: 'root'
})



export class CategoriasService {

  baseUrl = "categoria"

  

  constructor(private httpCliente: HttpClient, private snackBar: MatSnackBar) { }

  showMessage(messaOptions: MessageOptions): void {
    this.snackBar.open(messaOptions.msg, 'X', {
      duration: messaOptions.duration,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: messaOptions.classColor
    })
  }

  getAll (): Observable<Categorias[]> {
    return this.httpCliente.get<Categorias[]>(this.baseUrl)
  }

  getById (id: string) : Observable<ResponseRequest> {
    const urlBase = `${this.baseUrl}/${id}`
    return this.httpCliente.get<ResponseRequest>(urlBase)
  }

  create (categoria: Categorias): Observable<ResponseRequest> {
    return this.httpCliente.post<ResponseRequest>(this.baseUrl, categoria)
  }

  update (categoria: Categorias): Observable<ResponseRequest> {
    return this.httpCliente.put<ResponseRequest>(this.baseUrl, categoria)
  }

  delete (id: number): Observable<ResponseRequest>{
    const urlBase = `${this.baseUrl}/${id}`
    return this.httpCliente.delete<ResponseRequest>(urlBase)
  }
}
