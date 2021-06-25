import { Component, OnInit } from '@angular/core';
import { ConteudoService } from '../conteudo.service';
import { conteudoModel } from './conteudoModel';

@Component({
  selector: 'app-conteudo',
  templateUrl: './conteudo.component.html',
  styleUrls: ['./conteudo.component.css']
})
export class ConteudoComponent implements OnInit {

  conteudoModel: conteudoModel;

  constructor(private conteudoService: ConteudoService) { }

  ngOnInit(): void {
    this.get();
  }

  get() {
    this.conteudoService.get().subscribe(res => {
      this.conteudoModel = res;
    });
  }

  getPorTitulo(titulo: string) {
    this.conteudoService.getPorTitulo(titulo).subscribe(res => {
      this.conteudoModel = res;
    });
  }

}
