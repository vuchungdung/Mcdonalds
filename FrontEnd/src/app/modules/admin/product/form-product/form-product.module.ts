import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormProductComponent } from './form-product.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { CKEditorModule } from 'ckeditor4-angular';
const routes: Routes = [
  {
    path:'',
    component: FormProductComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [FormProductComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    RouterModule,
    SharedModule,
    CKEditorModule
  ]
})
export class FormProductModule { }
