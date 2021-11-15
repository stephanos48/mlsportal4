import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TxQoh } from 'src/app/_models/txqoh';
import { GeneralService } from 'src/app/_services/general.service';

@Component({
  selector: 'app-txqoh-edit',
  templateUrl: './txqoh-edit.component.html',
  styleUrls: ['./txqoh-edit.component.css']
})
export class TxqohEditComponent implements OnInit {
  @ViewChild('editForm', { static: true }) editForm: NgForm;
  txqoh: TxQoh;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private route: ActivatedRoute, private toastr: ToastrService, private generalService: GeneralService) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.txqoh = data['txqoh'];
    });
  }

  updateTxQoh() {
    this.generalService.updateTxQoh(this.txqoh.txQohId, this.txqoh).subscribe(next => {
      this.toastr.success('Update successful');
      this.editForm.reset(this.txqoh);
    }, error => {
      this.toastr.error(error);
    });
  }

}
