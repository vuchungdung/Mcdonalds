import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product.component';
import { FormProductComponent } from './form-product/form-product.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    component: ProductComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [
    ProductComponent,
    FormProductComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    RouterModule
  ]
})
export class ProductModule { }
