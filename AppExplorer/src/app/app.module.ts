import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppOverviewComponent } from './components/app-overview/app-overview.component';
import { AppDetailsComponent } from './components/app-details/app-details.component';
import { UpdateAppComponent } from './components/update-app/update-app.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    AppOverviewComponent,
    AppDetailsComponent,
    UpdateAppComponent,
    HomeComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
