import { PurchaseOrderLine } from "./purchaseOrderLine";

export interface PurchaseOrder {
    purchaseOrderId: number;
    purchaseOrderNumber: string;
    orderDate: Date;
    supplierId: number;
    customerId: number;
    customerDivisionId: number;
    mlsDivisionId: number;
    poStatusId: number;
    supplierName: string;
    customerName: string;
    customerDivisionName: string;
    mlsDivisionName: string;
    poStatusName: string;
    notes: string;

    purchaseOrderLine: PurchaseOrderLine[];
}