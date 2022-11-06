import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { MainMenuComponent } from './components/main-menu/main-menu.component';
import { IsLoggedInGuard } from './guards/is-logged-in.guard';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"menu",component:MainMenuComponent, canActivate:[IsLoggedInGuard]},
  {path:"**", redirectTo:"login", pathMatch: 'full'},
  {path:"", redirectTo:"login", pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
