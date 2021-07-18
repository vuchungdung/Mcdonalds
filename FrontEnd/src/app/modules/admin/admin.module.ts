import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
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
    NzLayoutModule,
    NzMenuModule,
    SharedModule
  ],
  providers:[]
})
export class AdminModule { }
