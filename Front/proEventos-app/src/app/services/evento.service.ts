import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Eventos } from '../models/Eventos';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  baseUrl = "https://localhost:5001/api/Eventos";

  constructor(private http: HttpClient) { }

  getEventos (): Observable <Eventos[]>{

    return this.http.get<Eventos[]>(this.baseUrl);

  }

  getEventoByTema (tema : string): Observable <Eventos[]>{

    return this.http.get<Eventos[]>(`${this.baseUrl}/${tema}/tema`);

  }

  getEventoById (id: number): Observable <Eventos>{

    return this.http.get<Eventos>(`${this.baseUrl}/${id}/id`);

  }

}
