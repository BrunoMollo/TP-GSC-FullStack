import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'

import { LoginComponent } from './login/login/login.component';

import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTableModule} from '@angular/material/table';

import { AddJwtToRequestInterceptor } from './login/add-jwt--interceptor/add-jwt-to-request.interceptor';
import { CreatePersonComponent } from './People-feature/create-person/create-person.component';
import { ListPeopleComponent } from './People-feature/list-people/list-people.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import {MatMenuModule} from '@angular/material/menu';


import { NavigationComponent } from './navigation/navigation.component';
import { EditPersonComponent } from './People-feature/edit-person/edit-person.component';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CreatePersonComponent,
    ListPeopleComponent,
    NavigationComponent,
    EditPersonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatCardModule,MatInputModule,MatButtonModule, MatFormFieldModule, MatTableModule,
     LayoutModule, MatToolbarModule, MatSidenavModule, MatIconModule, MatListModule, MatMenuModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass:AddJwtToRequestInterceptor, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
