import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
//import { PoPlan } from '../_models/poplan';
//import { Quote } from '../_models/quote';
//import { QuoteDetail } from '../_models/quotedetail';
//import { SoPlan } from '../_models/soplan';
//import { Supplier } from '../_models/supplier';
import { TxQoh } from '../_models/txqoh';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  baseUrl = environment.apiUrl;
  formData: TxQoh;
  //formData1: PoPlan;
  //formData2: SoPlan;

  constructor(private http: HttpClient) { }

  Form: FormGroup = new FormGroup({
    $key: new FormControl(null),
    pn: new FormControl(''),
    partDescription: new FormControl(''),
    qoh: new FormControl(''),
    location: new FormControl(''),
    notes: new FormControl('')
  });

  /*getResponsibles() {
    return this.http.get(this.baseUrl + 'responsibles/getResponsibles');
  }*/

  //TxQoh Methods

  getTxQohs() {
    return this.http.get(this.baseUrl + 'txqoh/getTxQohs');
  }

  getActualQohs() {
    return this.http.get(this.baseUrl + 'txqoh/getActualQohs');
  }

  updateTxQoh(id: number, txqoh: TxQoh) {
    return this.http.put(this.baseUrl + 'txqoh/' + id, txqoh);
  }

  createTxQoh(txqoh: TxQoh) {
    return this.http.post(this.baseUrl + 'txqoh/createTxQoh', txqoh);
  }

  getTxQoh(id): Observable<TxQoh> {
    return this.http.get<TxQoh>(this.baseUrl + 'txqoh/' + id);
  }

  deleteTxQoh(id: number) {
    return this.http.delete(this.baseUrl + 'txqoh/' + id);
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