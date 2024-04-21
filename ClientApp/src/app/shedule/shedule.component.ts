import { Component, OnInit, SimpleChanges } from '@angular/core';
import { AllFaculties } from '../faculties';
import { FormControl, ReactiveFormsModule} from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { GroupService } from '../services/fetch-groups.service';
import { Group } from '../interfaces/groups';
import { OneGroup } from '../interfaces/group';




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
  departments: Group[] = [];
  selectedGroup: string = ''
  showEmptyShedule: boolean = true;
  showFillShedule: boolean = false;
  
  groups: any[] = [];

  constructor(private groupService : GroupService){
    // this.filterOptions = this.facultiNameControl.valueChanges.pipe(
    //   startWith(''),
    //   map(value => this._filter(value))
    // );
      const group = new Group();
      this.groups = [...group.department]
  }

  

  ngOnInit(): void {
    this.groupService.getData().subscribe(data =>{
      this.departments =data;
    })

    // this.faculties = AllFaculties.faculties;
    // console.log(this.faculties)
}

 
 
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

  selectGroup(group: string){
    this.selectedGroup = group
    console.log(this.selectedGroup)
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
  
  }

  }




  

