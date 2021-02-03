import { Livro } from './../../models/livros/livro.model';
import { LivrosService } from './livros.service';
import { CategoriasService } from './../categorias/categorias.service';
import { Component, Input, OnInit, SimpleChange } from '@angular/core';
import { Router } from '@angular/router';
import { Categorias } from 'src/app/models/categorias/categoria.model';

@Component({
  selector: 'app-livros',
  templateUrl: './livros.component.html',
  styleUrls: ['./livros.component.css']
})
export class LivrosComponent implements OnInit {

  livros: Livro[] = []

  categorias: Categorias[] = []

  idCategoria: number = 0

  constructor(private router: Router, private categoriaService: CategoriasService,
    private livroService: LivrosService) { }

  ngOnInit(): void {
    this.buscarCategorias()
  }

  novoLivro () {
    this.router.navigate(['/livro-dados'])
  }

  buscarCategorias (): void {
    this.categoriaService.getAll()
    .subscribe(result => {
      this.categorias = result
    })
  }

  buscarLivrosPorCategoria (idCategoria: number) {
    this.livroService.getAll(idCategoria).subscribe(result => {
      console.log(result)
      this.livros = result
    })
  }


}
