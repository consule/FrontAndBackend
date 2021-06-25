import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { conteudoModel } from './conteudo/conteudoModel';

const url = "http://localhost:62166/api/infra/conteudo";

@Injectable({
  providedIn: 'root'
})
export class ConteudoService {

  constructor(private http: HttpClient) { }

  get() : Observable<conteudoModel> {
    return this.http.get<conteudoModel>(url);
  }

  getPorTitulo(titulo: string) : Observable<conteudoModel> {
    return this.http.get<conteudoModel>(url+`/${titulo}`);
  }

  getPorCodigoUnico(codigo_unico: number) : Observable<conteudoModel> {
    return this.http.get<conteudoModel>(url+`/codigo_unico/${codigo_unico}`);
  }

  create(conteudo) : Observable<conteudoModel> {
    return this.http.post<conteudoModel>(url, conteudo);
  }

  update(conteudo, codigo_unico) : Observable<conteudoModel> {
    return this.http.put<conteudoModel>(url+`/${codigo_unico}`, conteudo);
  }

  delete(codigo_unico) : Observable<conteudoModel> {
    return this.http.delete<conteudoModel>(url+`/${codigo_unico}`);
  }


}
