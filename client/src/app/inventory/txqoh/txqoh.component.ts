import { Component, OnInit,Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Pagination } from 'src/app/_models/pagination';
import { environment } from 'src/environments/environment';
import { GeneralService } from 'src/app/_services/general.service';
import { ConfirmService } from '../../_services/confirm.service';
import { ToastrService } from 'ngx-toastr';
import { TxqohModalComponent } from '../txqoh-modal/txqoh-modal.component';
import { TxQoh } from 'src/app/_models/txqoh';

@Component({
  selector: 'app-txqoh',
  templateUrl: './txqoh.component.html',
  styleUrls: ['./txqoh.component.css']
})
export class TxqohComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  baseUrl = environment.apiUrl;
  txqohs: TxQoh[];
  txqoh: TxQoh = JSON.parse(localStorage.getItem('txqoh'));
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  customerParams: any = {};
  pagination: Pagination;
  bsModalRef: BsModalRef;

  constructor(private generalService: GeneralService, private toastr: ToastrService, http: HttpClient, private fb: FormBuilder,
    private route: ActivatedRoute, private modalService: BsModalService, private confirmService: ConfirmService) { }

  ngOnInit(): void {
    this.getTxQohs();

    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  getTxQohs() {
    this.generalService.getTxQohs().subscribe((txqohs: TxQoh[]) => {
      this.txqohs = txqohs;
    }, error => {
      console.log(error);
    });
  }

  deleteTxQoh(id: number) {
    this.confirmService.confirm('Confirm delete message', 'This cannot be undone').subscribe(result => {
      if (result) {
        this.generalService.deleteTxQoh(id).subscribe(() => {
          this.txqohs.splice(this.txqohs.findIndex(m => m.txQohId === id), 1);
        })
      }
    })
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.getTxQohs();
  }

  createToggle() {
    this.createMode = true;
  }

  cancelCreateMode(createMode: boolean) {
    this.createMode = createMode;
  }

  cancel() {
    this.cancelCreate.emit(false);
  }

  editTxQohsModal(txqoh: TxQoh) {
    const initialState = {
      txqoh
    };
    this.bsModalRef = this.modalService.show(TxqohModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedTxQoh.subscribe(response => {
      console.log('UPDATED QOH', response);
      this.toastr.success('Customer updated successfully');
      }, error => {
        console.log(error);
      });
    }
  }


