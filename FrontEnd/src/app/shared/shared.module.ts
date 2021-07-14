import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/admin/header/header.component';
import { SidebarComponent } from './components/admin/sidebar/sidebar.component';
import { PaginatorComponent } from './components/admin/paginator/paginator.component';
import { FooterComponent } from './components/admin/footer/footer.component';



@NgModule({
  declarations: [
    HeaderComponent,
    SidebarComponent,
    PaginatorComponent,
    FooterComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
