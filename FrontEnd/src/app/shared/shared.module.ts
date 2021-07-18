import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from './components/paginator/paginator.component';
import { IconsProviderModule } from './modules/icons-provider.module';

@NgModule({
  declarations: [
    PaginatorComponent,
  ],
  imports: [
    CommonModule,
    IconsProviderModule
  ],
  exports:[
    PaginatorComponent,
    IconsProviderModule
  ]
})
export class SharedModule { }
