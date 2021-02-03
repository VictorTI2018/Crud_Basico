import { LivrosService } from './../../../views/livros/livros.service';
import { Livro } from './../../../models/livros/livro.model';
import { CategoriasService } from './../../../views/categorias/categorias.service';
import { Component, OnInit } from '@angular/core';
import { Categorias } from 'src/app/models/categorias/categoria.model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-livros-create',
  templateUrl: './livros-create.component.html',
  styleUrls: ['./livros-create.component.css']
})
export class LivrosCreateComponent implements OnInit {

  categorias: Categorias[] = []

  idCotegoriaControl = new FormControl()

  livros: Livro = {
    id: 0,
    nome: '',
    autor: '',
    idCategoria: 0,
    editora: '',
    isbn: '',
    dataPublicacao: ''
  }

  constructor(private categoriaService: CategoriasService, private livroService: LivrosService,
    private routerParams: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    if (this.routerParams.snapshot.paramMap.get('id') !== null) {
      this.buscarLivroPorId(Number(this.routerParams.snapshot.paramMap.get('id')))
    }
    this.buscarCategorias()
  }

  handleSubmit(): void {
    if (this.livros.id && this.livros.id > 0) {
      this.update()
    } else {
      this.salvar()
    }
    this.router.navigate(['/livros'])
  }

  voltar(): void {
    this.router.navigate(['/livros'])
  }

  salvar(): void {
    this.livroService.create(this.livros)
      .subscribe(result => {
        this.livroService.showMessage({ msg: 'Livro cadastrado com sucesso', duration: 3000, classColor: 'alert-success' })
      })
  }

  update(): void {
    this.livroService.update(this.livros)
      .subscribe(result => {
        this.livroService.showMessage({ msg: 'Livro atualizado com sucesso', duration: 3000, classColor: 'alert-success' })

      })
  }

  buscarCategorias(): void {
    this.categoriaService.getAll()
      .subscribe(result => {
        this.categorias = result
      })
  }

  buscarLivroPorId(id: number): void {
    this.livroService.getOne(id)
      .subscribe(result => {
        this.livros = result
        const date = result.dataPublicacao.split('T')[0].split('-')
        this.livros.dataPublicacao = String(`${date[0]}-${date[1]}-${date[2]}`)
      })
  }
}
