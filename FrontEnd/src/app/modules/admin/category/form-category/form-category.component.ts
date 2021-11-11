import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { category } from '../category.model';
import { CategoryService } from '../category.service';

@Component({
  selector: 'app-form-category',
  templateUrl: './form-category.component.html',
  styleUrls: ['./form-category.component.css']
})
export class FormCategoryComponent implements OnInit {

  public categoryForm : FormGroup;
  public category : category;
  public id : number = 0;

  constructor(
    private fb : FormBuilder,
    private route : Router,
    private categoryService : CategoryService,
    private router : ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.initial();
    this.router.params.subscribe(param =>{this.id = param['id']});
    if(this.id != undefined){
      this.item(this.id);
    }
  }
  initial(){
    this.categoryForm = this.fb.group({
      id:[0,Validators.required],
      name:['',Validators.required],
      description:['',Validators.required]
    })
  }
  save(){
    this.category = this.categoryForm.getRawValue();
    if(this.id == undefined){
      this.categoryService.insert(this.category).subscribe((res:any)=>{
        debugger
        if(res != null){
          this.route.navigate(['/admin/category'], {});
        }
        else{
          console.log("Failed!")
        }
      })
    }
    else{
      this.categoryService.update(this.category).subscribe((res:any)=>{
        debugger
        if(res != null){
          this.route.navigate(['/admin/category'], {});
        }
        else{
          console.log("Failed!")
        }
      })
    }
  }
  back(){
    this.route.navigate(['/admin/category'], {});
  }
  item(id:number){
    this.categoryService.item(id).subscribe((res:any)=>{
      if(res != null){
        console.log(res)
        this.bind(res)
      }
    })
  }
  bind(data:any){
    this.categoryForm.get('id').setValue(data.id);
    this.categoryForm.get('name').setValue(data.name);
    this.categoryForm.get('description').setValue(data.description);
  }
}
