import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any;


  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    this.geteventos();

  }
  public geteventos(): void {

    this.http.get('https://localhost:5001/api/Eventos').subscribe(

      response => this.eventos = response,
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
