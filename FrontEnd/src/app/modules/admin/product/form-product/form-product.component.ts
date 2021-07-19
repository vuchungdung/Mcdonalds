import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-form-product',
  templateUrl: './form-product.component.html',
  styleUrls: ['./form-product.component.css']
})
export class FormProductComponent implements OnInit {
  loading = false;
  avatarUrl?: string;
  listOfOption: any = ['a','b','c','d'];
  constructor() { }

  ngOnInit(): void {
  }

}
