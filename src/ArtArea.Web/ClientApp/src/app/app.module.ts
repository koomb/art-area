import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { jwtInterceptorProvider } from './app-auth/jwt.interceptor';
import { errorInterceptorProvider } from './app-auth/error.interceptor';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { NavComponent } from './nav/nav.component';
import { NavUserBadgeComponent } from './nav-user-badge/nav-user-badge.component';
import { UserDataComponent } from './user-data/user-data.component';
import { UserProjectsComponent } from './user-projects/user-projects.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    UserComponent,
    NavComponent,
    NavUserBadgeComponent,
    UserDataComponent,
    UserProjectsComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ],
  exports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ],
  providers: [
    jwtInterceptorProvider,
    errorInterceptorProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
