import { Component, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, ReactiveFormsModule} from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { GroupService } from '../services/fetch-groups.service';

import { OneGroup } from '../interfaces/group';
import { Lesson} from '../interfaces/schedules';




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
  shedule:Lesson[] =[];
  groups: any[] = [];
  currentID:string = ''
  

  constructor(private groupService : GroupService){
    // this.filterOptions = this.facultiNameControl.valueChanges.pipe(
    //   startWith(''),
    //   map(value => this._filter(value))
    // );
      // const group = new Group();
      // this.groups = [...group.department]
  }

  

  ngOnInit(): void {
    this.groupService.getData().subscribe(data =>{
      this.departments =data;
    })

    // this.faculties = AllFaculties.faculties;
    // console.log(this.faculties)


}

  groupSend(idnumber: string){
    this.groupService.sendGroup(idnumber).subscribe(
      (response =>{
        console.log(response)
      }) 
    )
  }

//  getShedule():void{
//   // if (!this.selectedGroup)
//   this.groupService.sendData(this.currentID)
//   .subscribe(response => {
//     this.shedule = response.psrozklad_export.roz_items;
//     console.log(this.shedule)
//   })
//  }
 
  // private _filter(value: string){
    
  //   const FilterValue = value.toLowerCase();
  //   return this.faculties.filter(option => option.toLowerCase().includes(FilterValue))
  // }

  // handleInputChange(){
  //   this.facultiPicked = true;
  // }
 
  selectOption(option: OneGroup) {      
    this.facultiPicked = option 
  }

  selectGroup(group: string, id: string){
    this.selectedGroup = group;
    this.currentID = id;
    console.log(this.selectedGroup, this.currentID)
    
  }



 
  SwitchInfo(){
    if(this.currentInfo == 'Чисельник'){
      this.currentInfo = "Знаменник"
    }
    else{
      this.currentInfo = 'Чисельник'
    }
    }

  FindCurrentShedule(){
    this.showEmptyShedule = false;
    this.showFillShedule = true;
    this.groupSend(this.currentID)
  }

  }




  

