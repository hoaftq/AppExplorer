import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppDetailsComponent } from './components/app-details/app-details.component';
import { AppOverviewComponent } from './components/app-overview/app-overview.component';
import { UpdateAppComponent } from './components/update-app/update-app.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'apps', component: AppOverviewComponent },
  { path: 'apps/:id', component: AppDetailsComponent },
  { path: 'admin/update-app', component: UpdateAppComponent },
  { path: 'admin/update-app/:id', component: UpdateAppComponent },
  { path: 'about', component: AboutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
