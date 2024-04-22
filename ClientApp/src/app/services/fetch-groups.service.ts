import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";

import { Lesson, Schedule } from "../interfaces/schedules";
import { OneGroup } from "../interfaces/group";


@Injectable({
    providedIn:'root'
})
export class GroupService{
    constructor(private http: HttpClient){

    }

    getData(): Observable<OneGroup[]>{
        return this.http.get<any>('https://dekanat.lnu.edu.ua/cgi-bin/timetable_export.cgi?req_type=obj_list&req_mode=group&show_ID=yes&req_format=json&coding_mode=UTF8')
        .pipe(
            map(response => response.psrozklad_export.departments)
        );
    }

    sendData(param: string):Observable<Schedule>{
        let params = new HttpParams().set('param', param);
        return this.http.get<Schedule>('https://dekanat.lnu.edu.ua/cgi-bin/timetable_export.cgi?req_type=rozklad&req_mode=group&OBJ_ID=&OBJ_name=%CF%CC%C0-22%F1&dep_name=&ros_text=separated&begin_date=23.03.2024&end_date=31.03.2024&req_format=json&coding_mode=UTF8&bs=ok', { params })

    }
    sendGroup(id:string){
        return this.http.post<any>('http://localhost:56263/schedule', {id});
    } 
}