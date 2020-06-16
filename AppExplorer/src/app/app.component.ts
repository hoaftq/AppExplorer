import { Component } from '@angular/core';
import { AppExplorerService } from './services/app-explorer.service';
import { AuthorizationService } from './services/authorization.service';
import { AppDto } from './dtos/app-dtos';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AppExplorer';
  apps: AppDto[];
  isAuthorized: boolean;

  constructor(private service: AppExplorerService, private authService: AuthorizationService) {
    this.apps = this.service.getApps();
    this.isAuthorized = authService.IsAuthorized;
  }
}
