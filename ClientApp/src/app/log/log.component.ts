import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})
export class LogComponent implements OnInit{
  reactiveForm!: FormGroup;
  email:string = '';
  password: string ='';
  valid:boolean = false

 ngOnInit(): void {
   this.reactiveForm = new FormGroup({
    email:new FormControl(null, [Validators.required, Validators.email]),
    password:new FormControl(null, Validators.required)
   })
 }
 OnLogSubmit(){
  console.log(this.reactiveForm)
  if(this.reactiveForm.valid){
    this.password = this.reactiveForm.get('password')?.value;
    this.email = this.reactiveForm.get('email')?.value;
    this.valid = true;
  }
  console.log(this.email)
 }

 @Output() ShowMain = new EventEmitter<boolean>();
 @Output() ShowReg = new EventEmitter<boolean>()
 isToggled = true;
 inreg = false; 
 
 GoBack(){
  this.isToggled = !this.isToggled;
  this.ShowMain.emit(this.isToggled);
 }
 GoToReg(){
  this.inreg = !this.inreg;
  this.ShowReg.emit(this.inreg)
 }
 
}
