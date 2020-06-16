import { Component, OnInit } from '@angular/core';
import { AppExplorerService } from 'src/app/services/app-explorer.service';
import { AppDto } from 'src/app/dtos/app-dtos';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  apps: AppDto[];

  constructor(private service: AppExplorerService) { }

  ngOnInit(): void {
    this.apps = this.service.getBestApps();
  }

}
