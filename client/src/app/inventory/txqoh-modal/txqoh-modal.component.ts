import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { TxQoh } from 'src/app/_models/txqoh';
import { GeneralService } from 'src/app/_services/general.service';

@Component({
  selector: 'app-txqoh-modal',
  templateUrl: './txqoh-modal.component.html',
  styleUrls: ['./txqoh-modal.component.css']
})
export class TxqohModalComponent implements OnInit {
  @Output() updateSelectedTxQoh = new EventEmitter();
  txqoh: TxQoh;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(public bsModalRef: BsModalRef, private generalService: GeneralService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  updateTxQoh() {
    this.generalService.updateTxQoh(this.txqoh.txQohId, this.txqoh)
      .subscribe(response => {
        console.log('Server Response: Update Successful', response);
        this.updateSelectedTxQoh.emit(this.txqoh);
        this.bsModalRef.hide();
      });
  }
  
}
