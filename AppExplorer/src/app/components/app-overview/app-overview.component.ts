import { Component, OnInit } from '@angular/core';
import { AppExplorerService } from 'src/app/services/app-explorer.service';
import { AppDto } from 'src/app/dtos/app-dtos';

@Component({
  selector: 'app-app-overview',
  templateUrl: './app-overview.component.html',
  styleUrls: ['./app-overview.component.scss']
})
export class AppOverviewComponent implements OnInit {

  apps: AppDto[];

  constructor(private service: AppExplorerService) { }

  ngOnInit(): void {
    this.apps = this.service.getApps();
  }

}
