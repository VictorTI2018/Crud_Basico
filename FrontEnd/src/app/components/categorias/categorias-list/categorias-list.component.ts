import { CategoriasService } from './../../../views/categorias/categorias.service';
import { ConfirmCustomComponent } from '../../../components/confirmCustom/confirm-custom/confirm-custom.component'
import { Component, OnInit } from '@angular/core';
import { Categorias } from 'src/app/models/categorias/categoria.model';
import { Router } from '@angular/router';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-categorias-list',
  templateUrl: './categorias-list.component.html',
  styleUrls: ['./categorias-list.component.css']
})
export class CategoriasListComponent implements OnInit {
  dialogRef: MatDialogRef<ConfirmCustomComponent> | undefined

  categoriasList: Categorias[] = [];

  headers: string[] = ["id", "nome", "descricao", "action"]

  constructor(private categoriasService: CategoriasService,
    private router: Router, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.buscarCategorias()
  }

  buscarCategorias(): void {
    this.categoriasService.getAll().subscribe(categorias => {
      this.categoriasList = categorias
    })
  }

  editar (id: number): void {
    this.router.navigate(['/categoria-dados', id])
  }

  deletar (id: number): void {
    this.dialogRef = this.dialog.open(ConfirmCustomComponent, {
      disableClose: false
    })
    this.dialogRef.componentInstance.confirmMessage = "Deseja realmente apagar essa categoria ?"
    this.dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.categoriasService.delete(id).subscribe(response => {
          if (response.status) {
            this.categoriasService.showMessage({ msg: 'Categoria deleta com sucesso', duration: 3000, classColor: 'alert-success' })
            this.buscarCategorias()
          }
        })
      }
      this.dialogRef = undefined
    })
  }

}
