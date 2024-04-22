import { Component, OnInit } from '@angular/core';
import { News } from '../interfaces/news';
import { NewsService } from '../services/fetch-news.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit{

  curretNews: News[] =[]
  text:string= "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Iste, quisquam soluta odio doloremque eveniet veniam iusto labore sed repudiandae. Eaque mollitia iste, quaerat nemo quam veritatis? Necessitatibus voluptates maxime sed."
  text2:string="Пес Патрон навідав ЛНУПес Патрон навідав ЛНУПес Патрон навідав ЛНУПес Патрон навідав ЛНУПес Патрон навідав ЛНУПес Патрон навідав ЛНУПес Патрон навідав ЛНУПес Патрон навідав ЛНУав ЛНУПес Патрон навідав ЛНУПес Патрон навідав ЛНУПе"
  constructor(private newsService: NewsService){

  }

  ngOnInit(): void {
    this.newsService.getNews().subscribe(data =>{
      this.curretNews =data
    })
  }
  

}
