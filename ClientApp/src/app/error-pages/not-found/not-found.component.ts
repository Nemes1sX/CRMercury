import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit {

  public errorMessage: string = "404 SERVER ERROR, NOT FOUND CONTACT ADMINISTRATOR!!!!";


  constructor() { }

  ngOnInit() {
  }

}
