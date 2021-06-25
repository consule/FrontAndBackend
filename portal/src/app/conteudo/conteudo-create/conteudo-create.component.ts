import { Component, OnInit } from '@angular/core';
import { ConteudoService } from 'src/app/conteudo.service';
import { conteudoModel } from '../conteudoModel';

@Component({
  selector: 'app-conteudo-create',
  templateUrl: './conteudo-create.component.html',
  styleUrls: ['./conteudo-create.component.css']
})
export class ConteudoCreateComponent implements OnInit {

  conteudoModel: conteudoModel

  constructor(private conteudoService: ConteudoService) { }

  ngOnInit(): void {
  }

  create(titulo, subtitulo, dataPublicacao) {
    let conteudo = {
      titulo: titulo,
      subtitulo: subtitulo,
      dataPublicacao: dataPublicacao
    }
    this.conteudoService.create(conteudo).subscribe(res => {
      alert(JSON.stringify(res["mensagem"]));
    });
  }

}
