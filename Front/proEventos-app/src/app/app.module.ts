import { NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import { FormsModule } from '@angular/forms'
import { DataTimeFormatPipePipe } from './helpers/DataTimeFormatPipe.pipe';


@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
    NavComponent,
    DataTimeFormatPipePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot( 
      {
        timeOut: 5000,
        positionClass:'toast-bottom-right',
        preventDuplicates: true,
        progressBar: true
      }
    ),
    NgxSpinnerModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
