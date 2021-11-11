import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormCategoryComponent } from './form-category.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoryService } from '../category.service';

const routes: Routes = [
  {
    path:'',
    component: FormCategoryComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [
    FormCategoryComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ],
  providers:[
    CategoryService
  ]
})
export class FormCategoryModule { }
