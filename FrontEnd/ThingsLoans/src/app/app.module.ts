import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'

import { LoginComponent } from './components/login/login.component';

import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';

import { MainMenuComponent } from './components/main-menu/main-menu.component';
import { AddJwtToRequestInterceptor } from './interceptors/add-jwt-to-request.interceptor';
import { CreatePersonComponent } from './components/create-person/create-person.component';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MainMenuComponent,
    CreatePersonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatCardModule,MatInputModule,MatButtonModule, MatFormFieldModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass:AddJwtToRequestInterceptor, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
