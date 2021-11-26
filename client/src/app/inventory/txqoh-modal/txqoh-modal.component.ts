import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { MasterPart } from 'src/app/_models/masterPart';
import { GeneralService } from 'src/app/_services/general.service';

@Component({
  selector: 'app-txqoh-modal',
  templateUrl: './txqoh-modal.component.html',
  styleUrls: ['./txqoh-modal.component.css']
})
export class TxqohModalComponent implements OnInit {
  @Output() updateSelectedTxQoh = new EventEmitter();
  masterPart: MasterPart;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(public bsModalRef: BsModalRef, private generalService: GeneralService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  updateMasterPart() {
    this.generalService.updateMasterPart(this.masterPart.masterPartId, this.masterPart)
      .subscribe(response => {
        console.log('Server Response: Update Successful', response);
        this.updateSelectedTxQoh.emit(this.masterPart);
        this.bsModalRef.hide();
      });
  }
  
}
