import { Eventos } from "./Eventos";
import { Palestrante } from "./Palestrante";

export interface RedeSocial {

  id: number;

  nome: string;

  URL: string;

  eventoId?: number;

  evento:  Eventos;

  palestranteId? : number;

  //Palestrante:  Palestrante;


}
