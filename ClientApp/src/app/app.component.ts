import { Component, HostListener } from '@angular/core';

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
   this.isToggled = value;  
  }

  GoToRegPage(value: boolean){   
    this.gotoreg = value
  }

  HideBar(value: boolean){  
    this.displayNav = value;
  }
 
}
