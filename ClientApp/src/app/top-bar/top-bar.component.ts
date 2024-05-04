import { Component, Input, Output, EventEmitter, HostListener } from '@angular/core';


@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent {


  @Output() GoToLoginComp = new EventEmitter<boolean>();
  @Output() HideNavBar = new EventEmitter<boolean>()
  isToggled = false;
  removeNav = true;
  click = true

  ChangePage(){
    this.isToggled = !this.isToggled;
    this.GoToLoginComp.emit(this.isToggled)
  }

   @HostListener('window:resize', ['$event'])
  onResize(event: any){
    if( window.innerWidth > 768 ){
    this.removeNav = true  
    this.HideNavBar.emit(this.removeNav)
  }
  }
  Hide(){
    
    this.removeNav = !this.removeNav;
    this.HideNavBar.emit(this.removeNav)
  }
}
