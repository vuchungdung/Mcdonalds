import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FilterModel } from "src/app/core/models/filter.model";
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
        getlist: '/category/list',
        delete: '/category/delete',
        item: '/category/item',
    }

    insert(model: category):Observable<any>{
        return this.api.insert(`${environment.apiUrl}${this.url.insert}`,model);
    }

    update(model: category):Observable<any>{
        return this.api.update(`${environment.apiUrl}${this.url.update}`,model);
    }

    item(id:number):Observable<any>{
        return this.api.item(`${environment.apiUrl}${this.url.item}`,id);
    }

    getList(filter: FilterModel):Observable<any>{
        return this.api.getList(`${environment.apiUrl}${this.url.getlist}`,filter);
    }

    delete(id: number):Observable<any>{
        return this.api.delete(`${environment.apiUrl}${this.url.delete}`,id)
    }
}