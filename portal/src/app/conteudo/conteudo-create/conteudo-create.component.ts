import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConteudoService } from 'src/app/conteudo.service';
import { conteudoModel } from '../conteudoModel';

@Component({
  selector: 'app-conteudo-create',
  templateUrl: './conteudo-create.component.html',
  styleUrls: ['./conteudo-create.component.css']
})
export class ConteudoCreateComponent implements OnInit {

  form: FormGroup;

  conteudoModel: conteudoModel

  constructor(private conteudoService: ConteudoService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      titulo: [null, Validators.required],
      subtitulo: [null, Validators.required],
      dataPublicacao: [null, Validators.required]
    });
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
