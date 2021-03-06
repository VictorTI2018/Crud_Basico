import { LivrosComponent } from './views/livros/livros.component';
import { LivrosCreateComponent } from './components/livros/livros-create/livros-create.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CategoriasComponent } from './views/categorias/categorias.component'
import { CategoriasCreateComponent } from './components/categorias/categorias-create/categorias-create.component'

const routes: Routes = [
  { path: '', component: CategoriasComponent },
  { path: 'categoria-dados', component: CategoriasCreateComponent },
  { path: 'categoria-dados/:id', component: CategoriasCreateComponent },
  { path: 'livros', component: LivrosComponent },
  { path: 'livro-dados', component: LivrosCreateComponent },
  { path: 'livro-dados/:id', component: LivrosCreateComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
