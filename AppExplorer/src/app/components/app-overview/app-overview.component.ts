import { Component, OnInit } from '@angular/core';
import { AppExplorerService } from 'src/app/services/app-explorer.service';

@Component({
  selector: 'app-app-overview',
  templateUrl: './app-overview.component.html',
  styleUrls: ['./app-overview.component.scss']
})
export class AppOverviewComponent implements OnInit {

  apps$ = this.service.apps$;

  constructor(private service: AppExplorerService) { }

  ngOnInit(): void {
  }

}
