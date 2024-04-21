import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { Group } from "../interfaces/groups";

@Injectable({
    providedIn:'root'
})
export class GroupService{
    constructor(private http: HttpClient){

    }

    getData(): Observable<Group[]>{
        return this.http.get<any>('https://dekanat.lnu.edu.ua/cgi-bin/timetable_export.cgi?req_type=obj_list&req_mode=group&show_ID=yes&req_format=json&coding_mode=UTF8')
        .pipe(
            map(response => response.psrozklad_export.departments)
        );
    }
}