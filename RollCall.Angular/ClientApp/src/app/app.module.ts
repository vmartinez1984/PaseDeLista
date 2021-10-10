import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AddUserComponent } from './components/user/add-user/add-user.component';

import { ListAreaComponent } from './components/area/list-area/list-area.component';
import { EditAreaComponent } from "./components/area/edit-area/edit-area.component";
import { AddAreaComponent } from "./components/area/add-area/add-area.component";
import { ListSchedulesComponent } from './components/schedule/list-schedule/list-schedule.component';
import { SaveScheduleComponent } from './components/schedule/save-schedule/save-schedule.component';
import { ListEmployeeComponent } from './components/employee/list-employee.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AddUserComponent,
    ListAreaComponent,
    EditAreaComponent,
    AddAreaComponent,
    ListSchedulesComponent,
    SaveScheduleComponent,
    ListEmployeeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'add-user', component: AddUserComponent },
      { path: 'list-area', component: ListAreaComponent },
      { path: 'edit-area/:id', component: EditAreaComponent },
      { path: 'add-area', component: AddAreaComponent },
      { path: "list-schedule", component: ListSchedulesComponent },
      { path: "save-schedule/:id", component: SaveScheduleComponent },
      { path: "list-employee", component: ListEmployeeComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
