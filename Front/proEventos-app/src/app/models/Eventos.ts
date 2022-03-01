import { EventosPalestrantes } from "./EventosPalestrantes";
import { Lote } from "./Lote";
import { Palestrante } from "./Palestrante";
import { RedeSocial } from "./RedeSocial";

export interface Eventos {

  id: number;

  local: string;

  dataEvento?: Date;

  tema: string;

  qtdPessoas: number;

  imagemURL: string;

  telefone: string;

  email: string;

  lote: Lote[];

  redeSociais: RedeSocial[];

  eventosPalestrantes: Palestrante[];
  //EventosPalestrantes: EventosPalestrantes[];

}
