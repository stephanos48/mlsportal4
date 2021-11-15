import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {
  jap: any = '../assets/img/jap.jpg';
  
  constructor() { }

  ngOnInit(): void {
  }

}
