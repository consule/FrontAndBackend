import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ConteudoService } from 'src/app/conteudo.service';
import { conteudoModel } from '../conteudoModel';

@Component({
  selector: 'app-conteudo-update',
  templateUrl: './conteudo-update.component.html',
  styleUrls: ['./conteudo-update.component.css']
})
export class ConteudoUpdateComponent implements OnInit {

  form: FormGroup;
  codigo_unico: number
  modelConteudo: conteudoModel

  constructor(private conteudoService: ConteudoService,  private route: ActivatedRoute, private formBuilder: FormBuilder) { }

  ngOnInit(): void {

    this.codigo_unico = +this.route.snapshot.paramMap.get('codigo_unico');
    this.conteudoService.getPorCodigoUnico(this.codigo_unico).subscribe(res => {
      this.modelConteudo = res[0];
    })

    this.form = this.formBuilder.group({
      titulo: [null, Validators.required], 
      subTitulo: [null, Validators.required], 
      dataPublicacao: [null, Validators.required]
    });

  }

  update(titulo, subtitulo, dataPublicacao, codigo_unico) {
    let conteudo = {
      titulo: titulo,
      subTitulo: subtitulo,
      dataPublicacao: dataPublicacao
    }
    this.conteudoService.update(conteudo, codigo_unico).subscribe(res => {
      alert(JSON.stringify(res["mensagem"]));
    });
  }

  getPorCodigoUnico() {
    this.conteudoService.getPorCodigoUnico(this.codigo_unico).subscribe(res => {
      this.modelConteudo = res;
    })
  }

}
