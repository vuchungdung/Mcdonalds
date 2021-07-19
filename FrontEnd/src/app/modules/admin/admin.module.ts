import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';

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
    SharedModule
  ],
  providers:[]
})
export class AdminModule { }
