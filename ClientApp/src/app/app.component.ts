import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  isToggled:boolean = false;
  gotoreg:boolean = false;
  displayNav: boolean = true;

  handleToggle(value: boolean){
    console.log(this.isToggled)
    this.isToggled = value;
    console.log(this.isToggled)
  }

  GoToRegPage(value: boolean){
    console.log(this.gotoreg)
    this.gotoreg = value
    console.log(this.gotoreg)
  }

  HideBar(value: boolean){
    this.displayNav = value;
  }
  // ShowAgaon(value:boolean){
  //   this.isToggled = value
  // }
}
