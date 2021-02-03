import { ConfirmCustomComponent } from './../../confirmCustom/confirm-custom/confirm-custom.component';
import { Livro } from './../../../models/livros/livro.model';
import { LivrosService } from './../../../views/livros/livros.service';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-livros-list',
  templateUrl: './livros-list.component.html',
  styleUrls: ['./livros-list.component.css']
})
export class LivrosListComponent implements OnInit {
  dialogRef: MatDialogRef<ConfirmCustomComponent> | undefined

  @Output() onLoadLivros: EventEmitter<any> = new EventEmitter<any>()

  @Input() livros: Livro[] = []

  constructor(private livroService: LivrosService, private router: Router, 
    public dialog: MatDialog) { }

  headers = ['id', 'nome', 'autor', 'editora', 'dataPublicacao', 'action']

  ngOnInit(): void {
  }

  editar (id:number): void {
    this.router.navigate(['/livro-dados', id])
  }

  deletar (id: number): void {
    this.dialogRef = this.dialog.open(ConfirmCustomComponent, {
      disableClose: false
    })
    this.dialogRef.componentInstance.confirmMessage = "Deseja realmente apagar essa categoria ?"
    this.dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.livroService.delete(id).subscribe(response => {
          if (response) {
            this.livroService.showMessage({ msg: 'Categoria deleta com sucesso', duration: 3000, classColor: 'alert-success' })
            this.livros = []
          }
        })
      }
      this.dialogRef = undefined
    })
  }

  buscarLivros (): void {
    this.onLoadLivros.emit()
  }
}
