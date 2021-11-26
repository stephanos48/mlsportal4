import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
//import { PoPlan } from '../_models/poplan';
//import { Quote } from '../_models/quote';
//import { QuoteDetail } from '../_models/quotedetail';
//import { SoPlan } from '../_models/soplan';
//import { Supplier } from '../_models/supplier';
import { MasterPart } from '../_models/masterPart';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  baseUrl = environment.apiUrl;
  formData: MasterPart;
  masterPart: any;
  currentMasterPart: MasterPart;
  private currentMasterPartSource = new ReplaySubject<MasterPart>(1);
  currentMasterPart$ = this.currentMasterPartSource.asObservable();
  photoUrl = new BehaviorSubject<string>('../../assets/part.jpg');
  currentPhotoUrl = this.photoUrl.asObservable();
  //formData1: PoPlan;
  //formData2: SoPlan;

  constructor(private http: HttpClient) { }

  Form: FormGroup = new FormGroup({
    $key: new FormControl(null),
    partNumber: new FormControl(''),
    partDescription: new FormControl(''),
    qoh: new FormControl(''),
    notes: new FormControl('')
  });

  /*getResponsibles() {
    return this.http.get(this.baseUrl + 'responsibles/getResponsibles');
  }*/

  setMainPhoto(photoId: number) {
    return this.http.put(this.baseUrl + 'masterPart/set-main-photo/' + photoId, {});
  }

  deletePhoto(photoId: number) {
    return this.http.delete(this.baseUrl + 'masterPart/delete-photo/' + photoId);
  }

  setCurrentMasterPart(masterPart: MasterPart) {
    //user.roles = [];
    //const roles = this.getDecodedToken(user.token).role;
    //Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('masterPart', JSON.stringify(masterPart));
    this.currentMasterPartSource.next(masterPart);
  }

  //TxQoh Methods

  getMasterParts() {
    return this.http.get(this.baseUrl + 'masterPart/getMasterParts');
  }

  getActualQohs() {
    return this.http.get(this.baseUrl + 'masterPart/getActualQohs');
  }

  updateMasterPart(id: number, masterPart: MasterPart) {
    return this.http.put(this.baseUrl + 'masterPart/' + id, masterPart);
  }

  createMasterPart(masterPart: MasterPart) {
    return this.http.post(this.baseUrl + 'masterPart/createMasterPart', masterPart);
  }

  getMasterPart(id): Observable<MasterPart> {
    return this.http.get<MasterPart>(this.baseUrl + 'masterPart/' + id);
  }

  deleteMasterPart(id: number) {
    return this.http.delete(this.baseUrl + 'masterPart/' + id);
  }

  //Purchase Orders Methods

  getPoPlans() {
    return this.http.get(this.baseUrl + 'poplans/getPoPlans');
  }

  getNotReceived() {
    return this.http.get(this.baseUrl + 'poplans/getNotReceived');
  }

  getReceived() {
    return this.http.get(this.baseUrl + 'poplans/getReceived');
  }

  getTransit() {
    return this.http.get(this.baseUrl + 'poplans/getTransit');
  }
/*
  createPoPlan(poplan: PoPlan) {
    return this.http.post(this.baseUrl + 'poplans/createPoPlan', poplan);
  }

  getPoPlan(id): Observable<PoPlan> {
    return this.http.get<PoPlan>(this.baseUrl + 'poplans/' + id);
  }

  deletePoPlan(id: number, poplan: PoPlan) {
    return this.http.post(this.baseUrl + 'poplans/' + id, poplan);
  }

  updatePoPlan(id: number, poplan: PoPlan) {
    return this.http.put(this.baseUrl + 'poplans/' + id, poplan);
  }
*/
  //Sales Orders Methods

  getShipOuts() {
    return this.http.get(this.baseUrl + 'soplans/getShipOuts');
  }

  getSlotted() {
    return this.http.get(this.baseUrl + 'soplans/getSlotted');
  }

  getSoPlans() {
    return this.http.get(this.baseUrl + 'soplans/getSoPlans');
  }

  getOpenSoPlans() {
    return this.http.get(this.baseUrl + 'soplans/getOpenSoPlans');
  }
/*
  getSoPlan(id): Observable<SoPlan> {
    return this.http.get<SoPlan>(this.baseUrl + 'soplans/' + id);
  }

  updateSoPlan(id: number, soplan: SoPlan) {
    return this.http.put(this.baseUrl + 'soplans/' + id, soplan);
  }

  createSoPlan(soplan: SoPlan) {
    return this.http.post(this.baseUrl + 'soplans/createSoPlan', soplan);
  }

  deleteSoPlan(id: number) {
    return this.http.delete(this.baseUrl + 'soplans/' + id);
  }
*/
  //Quote Methods

  getQuotes() {
    return this.http.get(this.baseUrl + 'quote/getQuotes');
  }
/*
  updateQuote(id: number, quote: Quote) {
    return this.http.put(this.baseUrl + 'quote/' + id, quote);
  }

  createQuote(quote: Quote) {
    return this.http.post(this.baseUrl + 'quote/createQuote', quote);
  }

  getQuote(id): Observable<Quote> {
    return this.http.get<Quote>(this.baseUrl + 'quote/' + id);
  }

  deleteQuote(id: number) {
    return this.http.delete(this.baseUrl + 'quote/deleteQuote' + id);
  }
*/
  //Supplier Methods

  getSuppliers() {
    return this.http.get(this.baseUrl + 'supplier/getSuppliers');
  }
/*/
  updateSupplier(id: number, supplier: Supplier) {
    return this.http.put(this.baseUrl + 'supplier/' + id, supplier);
  }

  createSupplier(supplier: Supplier) {
    return this.http.post(this.baseUrl + 'supplier/createSupplier', supplier);
  }

  getSupplier(id): Observable<Supplier> {
    return this.http.get<Supplier>(this.baseUrl + 'supplier/' + id);
  }

  deleteSupplier(id: number) {
    return this.http.delete(this.baseUrl + 'supplier/deleteSupplier' + id);
  }
*/
  //QuoteDetail Methods

  getQuoteDetails() {
    return this.http.get(this.baseUrl + 'quoteDetail/getQuoteDetails');
  }
/*
  updateQuoteDetail(id: number, quoteDetail: QuoteDetail) {
    return this.http.put(this.baseUrl + 'quoteDetail/' + id, quoteDetail);
  }

  createQuoteDetail(quoteDetail: QuoteDetail) {
    return this.http.post(this.baseUrl + 'quoteDetail/createQuoteDetail', quoteDetail);
  }

  getQuoteDetail(id): Observable<QuoteDetail> {
    return this.http.get<QuoteDetail>(this.baseUrl + 'quoteDetail/' + id);
  }

  deleteQuoteDetail(id: number) {
    return this.http.delete(this.baseUrl + 'quoteDetail/deleteQuoteDetail' + id);
  }
  */
}