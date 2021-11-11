import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { FilterModel } from 'src/app/core/models/filter.model';
import { category } from './category.model';
import { CategoryService } from './category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  public listCategories :readonly category[];
  public categories :readonly category[];
  public filter = new FilterModel();

  constructor(
    private categoryService: CategoryService,
    private route : Router
    ) { }

  ngOnInit(): void {
    this.load();
  }
  load(){
    this.categoryService.getList(this.filter).subscribe((res:any)=>{
      if(res != null){
        this.listCategories = res.records
      }
    })
  }
  toEdit(id:number){
    this.route.navigate(['admin/category/'+id],{})
  }
  deleted(id:number){
    this.categoryService.delete(id).subscribe((res:any)=>{
      if(res != null){
        this.load();
      }
    })
  }
  onCurrentPageDataChange(categories:readonly category[]):void{
    this.categories = categories
  }
}
