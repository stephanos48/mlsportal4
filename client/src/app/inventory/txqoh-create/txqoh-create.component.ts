import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { MasterPart } from 'src/app/_models/masterPart';
import { GeneralService } from 'src/app/_services/general.service';

@Component({
  selector: 'app-txqoh-create',
  templateUrl: './txqoh-create.component.html',
  styleUrls: ['./txqoh-create.component.css']
})
export class TxqohCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  model: any = {};
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(private generalService: GeneralService, private http: HttpClient,
    private router: Router, private Toastr: ToastrService) { }

  ngOnInit(): void {
  }

  create() {
    this.generalService.createMasterPart(this.model).subscribe(() => {
      console.log('created successfully');
    }, error => {
      this.Toastr.error(error);
    }, () => {
      this.router.navigate(['/txqoh']);
    });
  }

  cancel() {
    this.cancelCreate.emit(false);
    console.log('cancelled');
    this.router.navigate(['/inventory']);
  }

}
