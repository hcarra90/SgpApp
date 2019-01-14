import { TransactionalInformation } from './transactionalinformation.entity';

export class Laboratorio extends TransactionalInformation {
    public Id: number;
    public Nombre: string;
    public Estado: string;
    public laboratorios: Array<Laboratorio>;
}
