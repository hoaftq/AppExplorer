import { Component, OnInit } from '@angular/core';
import { AppExplorerService } from 'src/app/services/app-explorer.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  recentApps$ = this.service.recentApps$;

  constructor(private service: AppExplorerService) { }

  ngOnInit(): void {
  }

}
