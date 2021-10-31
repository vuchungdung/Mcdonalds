import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ProductService } from './product.service';
import { HttpClientModule } from '@angular/common/http';

const routes: Routes = [
  {
    path:'',
    component: ProductComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [
    ProductComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    RouterModule,
    SharedModule,
    HttpClientModule
  ],
  providers:[
    ProductService
  ]
})
export class ProductModule { }
