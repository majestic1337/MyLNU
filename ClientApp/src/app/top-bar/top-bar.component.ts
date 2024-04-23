import { Component, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent {


  @Output() GoToLoginComp = new EventEmitter<boolean>();
  @Output() HideNavBar = new EventEmitter<boolean>()
  isToggled = false;
  removeNav = false

  ChangePage(){
    this.isToggled = !this.isToggled;
    this.GoToLoginComp.emit(this.isToggled)
  }

  Hide(){
    this.removeNav = !this.removeNav;
    this.HideNavBar.emit(this.removeNav)
  }
}
