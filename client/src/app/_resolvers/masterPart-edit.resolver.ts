import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { MasterPart } from '../_models/masterPart';
import { GeneralService } from '../_services/general.service';

@Injectable({
    providedIn: 'root'
})
export class MasterPartEditResolver implements Resolve<MasterPart> {

    constructor(private generalService: GeneralService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<MasterPart> {
        return this.generalService.getMasterPart(route.paramMap.get('id'));
    }

} 