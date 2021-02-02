import { Observable } from 'rxjs';
import { CategoriasService, ResponseRequest } from './../../../views/categorias/categorias.service';
import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router'
import { Categorias } from 'src/app/models/categorias/categoria.model';



@Component({
  selector: 'app-categorias-create',
  templateUrl: './categorias-create.component.html',
  styleUrls: ['./categorias-create.component.css']
})
export class CategoriasCreateComponent implements OnInit {

  categoria: Categorias = {
    id: 0,
    nome: '',
    descricao: ''
  }

  constructor(private router: Router, private categoriaService: CategoriasService,
    private routerParams: ActivatedRoute ) { }

  ngOnInit(): void {
    if (this.routerParams.snapshot.paramMap.get('id') !== null) {
      let id = String(this.routerParams.snapshot.paramMap.get('id'))
      this.buscarCategoria(id)
    }
  }

  voltar (): void {
    this.router.navigate(['/'])
  }

  buscarCategoria (id: string): void {
    this.categoriaService.getById(id).subscribe(result => {
      const { resource } = result
      this.categoria = resource
    })
  }

  handleSubmit ():void {
    if (this.categoria.id && this.categoria.id > 0) {
      this.atualizar()
    } else {
     this.salvar()
    }
  }

  salvar (): void {
    this.categoriaService.create(this.categoria).subscribe(result => {
      if (result.status) {
        this.categoriaService.showMessage({ msg: result.messages[0], duration: 3000, classColor: 'alert-success'})
        this.router.navigate(['/'])
      }else {
        this.categoriaService.showMessage({ msg: result.messages[0], duration: 3000, classColor: 'alert-danger'})
      }
    })
    
  }

  atualizar (): void{
    this.categoriaService.update(this.categoria).subscribe(result => {
      if (result.status) {
        this.categoriaService.showMessage({ msg: result.messages[0], duration: 3000, classColor: 'alert-success'})
        this.router.navigate(['/'])
      }else {
        this.categoriaService.showMessage({ msg: result.messages[0], duration: 3000, classColor: 'alert-danger'})
      }
    })
  }
}
