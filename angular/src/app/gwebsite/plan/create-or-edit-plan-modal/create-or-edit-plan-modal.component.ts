import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import { PlanDto } from '../dto/plan.dto';

@Component({
    selector: 'createOrEditPlanModal',
    templateUrl: './create-or-edit-plan-modal.component.html',
    styleUrls: ['./create-or-edit-plan-modal.component.css']
})
export class CreateOrEditPlanModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('planCombobox') planCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    plan: PlanDto = new PlanDto();
    plans: ComboboxItemDto[] = [];

    public productsData = [
        {
          id: 1,
          name: 'Domestic'
        },
        {
          id: 2,
          name: 'Outsource'
        },
        {
          id: 3,
          name: 'Imports'
        }
      ];

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    show(planId?: number | null | undefined): void {
        this.active = true;

        this._apiService.getForEdit('api/MenuClient/GetMenuClientForEdit', planId).subscribe(result => {
            // tiennnnnnnnnnnnnnnnnnnnnnnnnnnnn
            this.plan = result.menuClient;
            this.plans = result.menuClients;
            this.modal.show();
            setTimeout(() => {
                    $(this.planCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    save(): void {
        let input = this.plan;
        this.saving = true;
        if (input.id) {
            this.updatePlan();
        } else {
            this.insertPlan();
        }
    }

    insertPlan() {
        // tiennnnnnnnnnnnnnnnnnnnnnnnnnnnn
        this._apiService.post('api/Purchase/CreatePurchase', this.plan)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updatePlan() {
        // tiennnnnnnnnnnnnnnnnnnnnnnnnnnnn
        this._apiService.put('api/MenuClient/UpdateMenuClient', this.plan)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
