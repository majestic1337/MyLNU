import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, map} from "rxjs";
import { News } from "../interfaces/news";




@Injectable({
    providedIn:'root'
})
export class NewsService{

    constructor(private http: HttpClient){

    }

    getNews():Observable<News[]>{
        return this.http.get<any>('https://localhost:44450/news')
        .pipe(
            map(response => response.Articles)
        )
    }
}