import { Eventos } from "./Eventos";
import { EventosPalestrantes } from "./EventosPalestrantes";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {

  id: number;

  nome: string;

  miniCurriculo: string;

  imagemURL: string;

  telefone: string;

  email: string;

  redeSociais: RedeSocial[];

  eventosPalestrantes: Eventos[];

}
