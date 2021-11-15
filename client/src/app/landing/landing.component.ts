import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {
  jap: any = '../assets/img/jap.jpg';
  
  constructor() { }

  ngOnInit(): void {
  }

}
