import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { HttpClientModule } from '@angular/common/http';

const routes: Routes = [
  {
    path:'',
    component: AdminComponent,
    children:[
      {
        path:'',
        redirectTo:'dashboard'
      },
      {
        path:'dashboard',
        loadChildren: () => import('./dashboard/dashboard.module').then(m=>m.DashboardModule)
      },
      {
        path:'product',
        loadChildren: () => import('./product/product.module').then(m=>m.ProductModule)
      },
      {
        path:'form-product',
        loadChildren: ()=> import('./product/form-product/form-product.module').then(m=>m.FormProductModule)
      },
      {
        path:'category',
        loadChildren: () => import('./category/category.module').then(m=>m.CategoryModule)
      },
      {
        path:'category/:id',
        loadChildren: () => import('./category/form-category/form-category.module').then(m=>m.FormCategoryModule)
      },
      {
        path:'form-category',
        loadChildren: ()=> import('./category/form-category/form-category.module').then(m=>m.FormCategoryModule)
      }
    ]
  },
  {
    path:'login',
    loadChildren: () => import('./login/login.module').then(m=>m.LoginModule)
  }
]

@NgModule({
  declarations: [
    AdminComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    RouterModule,
    SharedModule,
    HttpClientModule
  ],
  providers:[]
})
export class AdminModule { }
