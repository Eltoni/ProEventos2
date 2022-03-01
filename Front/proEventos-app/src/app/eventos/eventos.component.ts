import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Eventos } from '../models/Eventos';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  modalRef?: BsModalRef;

  public eventos: Eventos[] = [];

  mostrarImagem = true;

  public eventosFiltados: Eventos[] = [];

  private _filtroLista : string = "";

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltados = this.filtroLista ? this.filtrarEventos(this.filtroLista): this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Eventos[] {

    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(

      ( evento: any ) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1

    )

  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }


  public ngOnInit(): void {
    this.spinner.show();
    this.geteventos();


    /** spinner starts on init */
    

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      
    }, 5000);

  }

  public mostraImagem(): void{
    this.mostrarImagem = !this.mostrarImagem;
  }

  public geteventos(): void {

    this.eventoService.getEventos().subscribe({

        next : (eventos : Eventos[]) =>

      {
        this.eventos = eventos;
        this.eventosFiltados =  this.eventos;
      },

      error: (error:any) => {

        this.spinner.hide()
        this.toastr.error('Erro a carregar Eventos', 'Erro!');

      },
      
      //console.error(error),

      complete: () => this.spinner.hide()

      });

  }


  openModal(template: TemplateRef<any>): void{
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirm(): void {
    
    this.modalRef?.hide();

    this.toastr.success('O evento foi deletado com sucesso!', 'Deletado!');
  }
 
  decline(): void {
    
    this.modalRef?.hide();
  }

}
