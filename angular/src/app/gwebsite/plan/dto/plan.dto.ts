import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class PlanDto {
    id: number;
    purchaseProducts: PurchaseProducts;
    userId: number;
    status: number;
    comment: string;
    departmentId: number;
    raisedDate: string;
}

export interface PurchaseProducts {
    quantity: number;
    productId: number;
}

export class GetPlanOutput {
    plan: PlanDto;
    plans: ComboboxItemDto[];
}
