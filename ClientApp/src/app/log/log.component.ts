import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})
export class LogComponent {

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
