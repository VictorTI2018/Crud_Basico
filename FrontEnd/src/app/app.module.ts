import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser'

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatListModule } from '@angular/material/list'
import { MatCardModule } from '@angular/material/card'
import { FormsModule } from '@angular/forms'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatButtonModule } from '@angular/material/button'
import { MatTableModule } from '@angular/material/table'
import { MatSnackBarModule } from '@angular/material/snack-bar'
import { MatDialogModule } from '@angular/material/dialog'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/templates/header/header.component'
import { FooterComponent } from './components/templates/footer/footer.component'
import { NavComponent } from './components/templates/nav/nav.component'
import { RedDirective } from './directives/colors/red.directive';
import { CategoriasComponent } from './views/categorias/categorias.component';
import { CategoriasCreateComponent } from './components/categorias/categorias-create/categorias-create.component';
import { CategoriasListComponent } from './components/categorias/categorias-list/categorias-list.component';
import { HttpIntercerptor } from './http/http-intercerptor';
import { ConfirmCustomComponent } from './components/confirmCustom/confirm-custom/confirm-custom.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    RedDirective,
    NavComponent,
    CategoriasComponent,
    CategoriasCreateComponent,
    CategoriasListComponent,
    ConfirmCustomComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    HttpClientModule,
    FormsModule,
    MatSnackBarModule,
    MatDialogModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: HttpIntercerptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
