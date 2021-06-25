import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ConteudoComponent } from './conteudo/conteudo.component';
import { ConteudoCreateComponent } from './conteudo/conteudo-create/conteudo-create.component';
import { ConteudoUpdateComponent } from './conteudo/conteudo-update/conteudo-update.component';
import { ConteudoDeleteComponent } from './conteudo/conteudo-delete/conteudo-delete.component';


const routes: Routes = [
  {
    path: "",
    component: ConteudoComponent
  },
  {
    path: "create",
    component: ConteudoCreateComponent
  },
  {
    path: "update/:codigo_unico",
    component: ConteudoUpdateComponent
  },
  {
    path: "delete/:codigo_unico",
    component: ConteudoDeleteComponent
  }
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes),
    CommonModule
  ]
})
export class AppRoutingModule { }
