import { PurchaseOrderLine } from "./purchaseOrderLine";

export interface ContainerDetail {
    containerDetailId: number;
    containerId: number;
    masterPartId: number;
    containerQty: number;
    containerPalletNo: string;
    notes: string;

    purchaseOrderLine: PurchaseOrderLine[];
}