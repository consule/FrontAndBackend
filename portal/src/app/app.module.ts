import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ConteudoComponent } from './conteudo/conteudo.component';
import { ConteudoCreateComponent } from './conteudo/conteudo-create/conteudo-create.component';
import { ConteudoUpdateComponent } from './conteudo/conteudo-update/conteudo-update.component';
import { ConteudoDeleteComponent } from './conteudo/conteudo-delete/conteudo-delete.component';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    ConteudoComponent,
    ConteudoCreateComponent,
    ConteudoUpdateComponent,
    ConteudoDeleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
