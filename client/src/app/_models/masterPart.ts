import * as internal from "events";
import { Photo } from './photo';
import { Location } from './location';

export interface MasterPart {
    masterPartId: number;
    partNumber: string;
    photoUrl: string;
    mlsPn: string;
    partDescription: string;
    customerId: number;
    customerName: string;
    customerDivisionId: number;
    customerDivisionName: string;
    mlsDivisionId: number;
    mlsDivisionName: string;
    isActive: boolean;
    partTypeId: number;
    partTypeName: string;
    qoh: number;
    htsCode: string;
    notes: string;
    dateCreated: Date;
    appUserId: number;

    photos: Photo[];
    locations: Location[];
}