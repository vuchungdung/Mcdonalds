import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FilterModel } from "../models/filter.model";
import { ResponseModel } from "../models/response.model";
import { map } from 'rxjs/operators';
import { ResponseStatus } from "../enums/response-status.enum";

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    constructor(private http: HttpClient) { }

    getList(url:string,filter: FilterModel):Observable<ResponseModel>{
        return this.http.post<ResponseModel>(url,filter).pipe(
            map((data:ResponseModel)=>{
                if(data.status == ResponseStatus.success){
                    return data;
                }
                return null;
            })
        );
    }

    insert(url:string, model:any):Observable<ResponseModel>{
        return this.http.post<ResponseModel>(url,model).pipe(
            map((data:ResponseModel)=>{
                if(data.status == ResponseStatus.success){
                    return data;
                }
                return null;
            })
        )
    }

    update(url, model:any):Observable<ResponseModel>{
        return this.http.put<ResponseModel>(url,model).pipe(
            map((data:ResponseModel)=>{
                if(data.status == ResponseStatus.success){
                    return data;
                }
                return null;
            })
        )
    }

    delete(url:string, id:number):Observable<ResponseModel>{
        return this.http.delete<ResponseModel>(url+"?id="+id).pipe(
            map((data:ResponseModel)=>{
                if(data.status == ResponseStatus.success){
                    return data;
                }
                return null;
            })
        )
    }

    item(url:string, id:number):Observable<ResponseModel>{
        return this.http.get<ResponseModel>(url+"?id="+id).pipe(
            map((data:ResponseModel)=>{
                if(data.status == ResponseStatus.success){
                    return data;
                }
                return null;
            })
        )
    }
}