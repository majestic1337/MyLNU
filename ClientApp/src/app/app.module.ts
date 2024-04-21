import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ErrorComponent } from './error/error.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { MessagesComponent } from './messages/messages.component';
import { UserinformationComponent } from './userinformation/userinformation.component';
import { SheduleComponent } from './shedule/shedule.component';
import { ForumComponent } from './forum/forum.component';
import { CalendarModule, DatePickerModule, TimePickerModule, DateRangePickerModule, DateTimePickerModule } from '@syncfusion/ej2-angular-calendars';
import { SmallTextPipe } from './Pipes/smalltext.pipe';
import { NewsComponent } from './news/news.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GroupService } from './services/fetch-groups.service';
import { EachDaySheduleComponent } from './each-day-shedule/each-day-shedule.component';





@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TopBarComponent,
    ErrorComponent,
    NotificationsComponent,
    MessagesComponent,
    UserinformationComponent, 
    SheduleComponent,
    ForumComponent,
    SmallTextPipe,
    NewsComponent,
    EachDaySheduleComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    

    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'shedule', component: SheduleComponent},
      { path: 'forum', component: ForumComponent},
      { path: 'news', component: NewsComponent},
      { path: '**', component: ErrorComponent },
    
    ]),
    FontAwesomeModule,
    CalendarModule, DatePickerModule, TimePickerModule, DateRangePickerModule, DateTimePickerModule, BrowserAnimationsModule
  ],
  providers: [
    GroupService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
