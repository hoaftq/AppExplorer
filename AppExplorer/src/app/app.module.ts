import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';

import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppOverviewComponent } from './components/app-overview/app-overview.component';
import { AppDetailsComponent } from './components/app-details/app-details.component';
import { UpdateAppComponent } from './components/update-app/update-app.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { LanguageComponent } from './components/language/language.component';
import { AddNameEntityComponent } from './components/shared/add-name-entity/add-name-entity.component';
import { EditNameEntityComponent } from './components/shared/edit-name-entity/edit-name-entity.component';
import { MessagesComponent } from './components/shared/messages/messages.component';

@NgModule({
  declarations: [
    AppComponent,
    AppOverviewComponent,
    AppDetailsComponent,
    UpdateAppComponent,
    HomeComponent,
    AboutComponent,
    LanguageComponent,
    AddNameEntityComponent,
    EditNameEntityComponent,
    MessagesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
