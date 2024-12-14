import { Routes } from '@angular/router';
import {LoginComponent} from "./components/login/login.component";
import {LayoutComponent} from "./components/layout/layout.component";
import {DashboardComponent} from "./components/dashboard/dashboard.component";
import { RegisterComponent } from './components/register/register.component';
import { EditComponent } from './components/edit/edit.component';

export const routes: Routes = [
  {
    path: '', redirectTo:'login' , pathMatch:'full'
  },
  {
    path:'login',
    component:LoginComponent
  },
  {
    path:'',
    component:DashboardComponent,
    children:[
      {
        path:'dashboard',
        component:DashboardComponent
      }
    ]
  },
  {
    path:'register',
    component:RegisterComponent
  },

  {
    path:'edit/:id',
    component:EditComponent
  }
];
