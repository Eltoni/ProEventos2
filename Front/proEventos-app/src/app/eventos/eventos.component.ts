import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];

  mostrarImagem = true;

  public eventosFiltados: any = [];

  private _filtroLista : string = "";

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltados = this.filtroLista ? this.filtrarEventos(this.filtroLista): this.eventos;
  }

  filtrarEventos(filtrarPor: string): any {

    filtrarPor = filtrarPor.toLocaleLowerCase();
    
    return this.eventos.filter(

      ( evento: any ) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1

    )

  }

  constructor(private http: HttpClient) { }


  ngOnInit(): void {

    this.geteventos();

  }

  mostraImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  public geteventos(): void {

    this.http.get('https://localhost:5001/api/Eventos').subscribe(

      response =>

      { 
        this.eventos = response,
        this.eventosFiltados =  this.eventos
      },

      error => console.error(error)

    );

    // this.eventos = [
    //   {
    //     tema : 'Angular',
    //     local : 'Belo Horizonte'
    //   },

    //   {
    //     tema : 'DotNet',
    //     local : 'São Paulo'
    //   },

    //   {
    //     tema : 'C#',
    //     local : 'Rio de Janeiro'
    //   }
    // ]

  }

}
