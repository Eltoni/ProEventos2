import { Eventos } from "./Eventos";

export interface Lote {

  id: number;

  nome: string;

  preco:  number;

  dataInicio?:  Date;

  dateTime?:  Date;

  quantidade: number;

  eventoId: number;

  evento: Eventos;

}
