import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryComponent } from './category.component';
import { CategoryService } from './category.service';

@NgModule({
  declarations: [
    CategoryComponent
  ],
  imports: [
    CommonModule
  ],
  providers:[
    CategoryService
  ]
})
export class CategoryModule { }
