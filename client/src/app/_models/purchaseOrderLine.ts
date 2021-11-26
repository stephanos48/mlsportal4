import { ContainerDetail } from "./containerDetail";

export interface PurchaseOrderLine {
    purchaseOrderLineId: number;
    purchaseOrderId: number;
    masterPartId: number,
    purchaseOrderLineNo: string;
    requestDate: Date;
    promiseDate: Date;
    receivedDate: Date;
    orderQty: number;
    notes: string;

    containerDetail: ContainerDetail[];
}