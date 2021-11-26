import { ContainerDetail } from "./containerDetail";
import { ShipMode } from "./shipMode";

export interface Container {
    containerId: number;
    containerNoFF: string;
    containerNoInt: string;
    etdDate: Date;
    departureDate: Date;
    etpDate: Date;
    portDate: Date;
    etaDate: Date;
    arrvivalDate: Date;
    bol: string;
    ams: string;
    freightForwarder: string;
    destination: string;
    departurePort: string;
    arrivalPort: string;
    containerStatusId: number;
    containerStatusName: string;
    shipModeId: number;
    shipModeName: string;
    notes: string;
    
    containerDetail: ContainerDetail[];
    shipMode: ShipMode[];
}