import { Component,Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-reg',
  templateUrl: './reg.component.html',
  styleUrls: ['./reg.component.css']
})
export class RegComponent {

@Output() GoToLog = new EventEmitter<boolean>()
inreg = true;

Back(){
  this.inreg = !this.inreg;
  this.GoToLog.emit(this.inreg);
}
}
