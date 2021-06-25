import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConteudoService } from 'src/app/conteudo.service';
import { conteudoModel } from '../conteudoModel';

@Component({
  selector: 'app-conteudo-delete',
  templateUrl: './conteudo-delete.component.html',
  styleUrls: ['./conteudo-delete.component.css']
})
export class ConteudoDeleteComponent implements OnInit {

  codigo_unico: number
  modelConteudo: conteudoModel

  constructor(private conteudoService: ConteudoService,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.codigo_unico = +this.route.snapshot.paramMap.get('codigo_unico');
    this.conteudoService.getPorCodigoUnico(this.codigo_unico).subscribe(res => {
      this.modelConteudo = res[0];
    })
  }

  delete(titulo, subtitulo, dataPublicacao, codigo_unico) {
    this.conteudoService.delete(codigo_unico).subscribe(res => {
      alert(JSON.stringify(res["mensagem"]));
    });
  }

  getPorCodigoUnico() {
    this.conteudoService.getPorCodigoUnico(this.codigo_unico).subscribe(res => {
      this.modelConteudo = res;
    })
  }
}
