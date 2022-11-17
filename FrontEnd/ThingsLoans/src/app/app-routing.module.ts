import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreatePersonComponent } from './People-feature/create-person/create-person.component';
import { LoginComponent } from './login/login/login.component';
import { IsLoggedInGuard } from './login/is-logged-in--guard/is-logged-in.guard';
import { ListPeopleComponent } from './People-feature/list-people/list-people.component';
import { NavigationComponent } from './navigation/navigation.component';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"menu",component:NavigationComponent, canActivate:[IsLoggedInGuard],
      children:[
        {path:"people/new", component:CreatePersonComponent},
        {path:"people", component:ListPeopleComponent, pathMatch:'full'}
      ]
},
  {path:"**", redirectTo:"login", pathMatch: 'full'},
  {path:"", redirectTo:"login", pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
