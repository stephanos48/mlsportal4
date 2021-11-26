import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { MasterPart } from 'src/app/_models/masterPart';
import { GeneralService } from 'src/app/_services/general.service';


@Component({
  selector: 'app-txqoh-edit',
  templateUrl: './txqoh-edit.component.html',
  styleUrls: ['./txqoh-edit.component.css']
})
export class TxqohEditComponent implements OnInit {
  @ViewChild('editForm', { static: true }) editForm: NgForm;
  masterPart: MasterPart;
  photoUrl: string;
  bsConfig: Partial<BsDatepickerConfig>
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private route: ActivatedRoute, private toastr: ToastrService, private generalService: GeneralService) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.masterPart = data['masterPart'];
    });
    this.bsConfig = {
      containerClass: 'theme-red'
    };
    this.generalService.currentPhotoUrl.subscribe(photoUrl => this.photoUrl = photoUrl);
  }

  updateMasterPart() {
    this.generalService.updateMasterPart(this.masterPart.masterPartId, this.masterPart).subscribe(next => {
      this.toastr.success('Update successful');
      this.editForm.reset(this.masterPart);
    }, error => {
      this.toastr.error(error);
    });
  }

  updateMainPhoto(photoUrl) {
    this.masterPart.photoUrl = photoUrl;
  }

}
