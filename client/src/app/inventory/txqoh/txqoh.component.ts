import { Component, OnInit,Output, EventEmitter, Input } from '@angular/core';
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
import { MasterPart } from 'src/app/_models/masterPart';

@Component({
  selector: 'app-txqoh',
  templateUrl: './txqoh.component.html',
  styleUrls: ['./txqoh.component.css']
})
export class TxqohComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  //@Input() masterPart: MasterPart;
  baseUrl = environment.apiUrl;
  masterParts: MasterPart[];
  masterPart: MasterPart = JSON.parse(localStorage.getItem('masterPart'));
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  pagination: Pagination;
  bsModalRef: BsModalRef;

  constructor(private generalService: GeneralService, private toastr: ToastrService, http: HttpClient, private fb: FormBuilder,
    private route: ActivatedRoute, private modalService: BsModalService, private confirmService: ConfirmService) { }

  ngOnInit(): void {
    this.getMasterParts();

    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  getMasterParts() {
    this.generalService.getMasterParts().subscribe((masterParts: MasterPart[]) => {
      this.masterParts = masterParts;
    }, error => {
      console.log(error);
    });
  }

  deleteMasterPart(id: number) {
    this.confirmService.confirm('Confirm delete message', 'This cannot be undone').subscribe(result => {
      if (result) {
        this.generalService.deleteMasterPart(id).subscribe(() => {
          this.masterParts.splice(this.masterParts.findIndex(m => m.masterPartId === id), 1);
        })
      }
    })
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.getMasterParts();
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

  formatDate(date: string): string {
    const parsedDate = new Date(date);
  const formattedDate = (parsedDate.getMonth() + 1) + '-' + parsedDate.getDate() + '-' + parsedDate.getFullYear();
    return formattedDate;
  }

  editTxQohsModal(masterPart: MasterPart) {
    const initialState = {
      masterPart
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


