import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppExplorerService } from 'src/app/services/app-explorer.service';
import { AppDetailsDto } from 'src/app/dtos/app-dtos';

@Component({
  selector: 'app-app-details',
  templateUrl: './app-details.component.html',
  styleUrls: ['./app-details.component.scss']
})
export class AppDetailsComponent implements OnInit {

  appDetails: AppDetailsDto;

  constructor(private route: ActivatedRoute, private service: AppExplorerService) { }

  ngOnInit(): void {
    let id = +this.route.snapshot.paramMap.get('id');
    this.appDetails = this.service.getAppDetails(id);
  }

}
