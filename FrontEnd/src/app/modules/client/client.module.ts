import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientComponent } from './client.component';
import { RouterModule, Routes } from '@angular/router';

const routes : Routes =[
  {
    path:'',
    component: ClientComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [
    ClientComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    RouterModule
  ]
})
export class ClientModule { }
