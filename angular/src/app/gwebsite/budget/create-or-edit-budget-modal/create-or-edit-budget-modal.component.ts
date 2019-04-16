import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import { BudgetDto } from '../dto/budget.dto';

@Component({
    selector: 'createOrEditBudgetModal',
    templateUrl: './create-or-edit-budget-modal.component.html',
    styleUrls: ['./create-or-edit-budget-modal.component.css']
})
export class CreateOrEditBudgetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('budgetCombobox') budgetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    budget: BudgetDto = new BudgetDto();
    budgets: ComboboxItemDto[] = [];

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    show(budgetId?: number | null | undefined): void {
        this.active = true;

        this._apiService.getForEdit('api/MenuClient/GetMenuClientForEdit', budgetId).subscribe(result => {
            // tiennnnnnnnnnnnnnnnnnnnnnnnnnnnn
            this.budget = result.menuClient;
            this.budgets = result.menuClients;
            this.modal.show();
            setTimeout(() => {
                    $(this.budgetCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    save(): void {
        let input = this.budget;
        this.saving = true;
        if (input.id) {
            this.updateBudget();
        } else {
            this.insertBudget();
        }
    }

    insertBudget() {
        // tiennnnnnnnnnnnnnnnnnnnnnnnnnnnn
        this._apiService.post('api/MenuClient/CreateMenuClient', this.budget)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateBudget() {
        // tiennnnnnnnnnnnnnnnnnnnnnnnnnnnn
        this._apiService.put('api/MenuClient/UpdateMenuClient', this.budget)
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
