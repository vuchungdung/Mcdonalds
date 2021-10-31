import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FilterModel } from "src/app/core/models/filter.model";
import { ResponseModel } from "src/app/core/models/response.model";
import { ApiService } from "src/app/core/services/api.service";
import { environment } from "src/environments/environment";
import { category } from "./category.model";

@Injectable({
    providedIn:'root'
})
export class CategoryService{
    constructor(private api: ApiService){}

    private url={
        insert: '/category/insert',
        update: '/category/update',
        getlist: '/category/get-list',
        delete: '/category/delete',
        item: '/category/item',
    }

    insert(model: category):Observable<ResponseModel>{
        return this.api.insert(`${environment.apiUrl}${this.url.insert}`,model);
    }

    update(model: category):Observable<ResponseModel>{
        return this.api.update(`${environment.apiUrl}${this.url.update}`,model);
    }

    item(id:number):Observable<ResponseModel>{
        return this.api.item(`${environment.apiUrl}${this.url.item}`,id);
    }

    getList(filter: FilterModel):Observable<ResponseModel>{
        return this.api.getList(`${environment.apiUrl}${this.url.getlist}`,filter);
    }
}