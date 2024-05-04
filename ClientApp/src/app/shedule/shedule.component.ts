import { Component, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, ReactiveFormsModule} from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { GroupService } from '../services/fetch-groups.service';

import { OneGroup } from '../interfaces/group';
import { Lesson, Schedule} from '../interfaces/schedules';
import { ScheduleService } from '../services/fetch-shedule.sevice';




@Component({
  selector: 'app-shedule',
  templateUrl: './shedule.component.html',
  styleUrls: ['./shedule.component.css']
})
export class SheduleComponent implements OnInit{

  facultiNameControl = new FormControl();
  faculties:string[] = [];
  filterOptions!: Observable<string[]>;
  currentInfo :string = 'Чисельник';
  facultiPicked!: OneGroup; 
  listOfGroups: any;
  departments: OneGroup[] = [];
  selectedGroup: string = ''
  showEmptyShedule: boolean = true;
  showFillShedule: boolean = false;
  lessonsTime: string[] = ['8:30-9:50','10:10-11:30','11:50-13:10','13.30-14:50','15:05-16:25','16:40-18:00'];
  DayOfTheWeek:string[]=['Понеділок', 'Вівторок','Серееда','Четверг',"П'ятниця"]
  currentShedule !: Schedule;
  groups: any[] = [];
  currentID:string = ''
  dataread: boolean = false
  

  constructor(private groupService : GroupService, private schedule: ScheduleService){
   
  }


  ngOnInit(): void {
    this.groupService.getData().subscribe(data =>{
      this.departments =data;
    })

}

 
  selectOption(option: OneGroup) {      
    this.facultiPicked = option 
  }

  selectGroup(group: string, id: string){
    this.selectedGroup = group;
    this.currentID = id;
    // console.log(this.selectedGroup, this.currentID)
    // this.schedule.getSchedule(this.selectedGroup).subscribe(data =>{
    //   this.currentShedule = data
    //   console.log(this.currentShedule)
     
    // })
    
  }


  FindCurrentShedule(){
    this.showEmptyShedule = false;
    this.showFillShedule = true;
    console.log(this.selectedGroup, this.currentID)
    this.schedule.getSchedule(this.selectedGroup).subscribe(data =>{
      this.currentShedule = data
      console.log(this.currentShedule)
     this.dataread=true;
    })
  }
  
 
  }




  

