import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, map} from "rxjs";
import { Schedule } from "../interfaces/schedules";


@Injectable({
    providedIn:'root'
})
export class ScheduleService{
    private apiUrl = 'https://localhost:44450/schedule'

    constructor(private http: HttpClient){}

    getSchedule(group: string):Observable<Schedule>{

        const url = `${this.apiUrl}?group=${group}`;
        // const url = `${this.apiUrl}?group=%CF%CC%C0-22%F1`;
        // const url = 'https://localhost:44450/schedule?group=ПМА-22с'
        
        return this.http.get<any>(url)
        .pipe(
            map(response => response.Schedule)
        )
    }
}