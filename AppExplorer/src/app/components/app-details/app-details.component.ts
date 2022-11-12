import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppExplorerService } from 'src/app/services/app-explorer.service';
import { flatMap } from 'rxjs/operators';

@Component({
  selector: 'app-app-details',
  templateUrl: './app-details.component.html',
  styleUrls: ['./app-details.component.scss']
})
export class AppDetailsComponent implements OnInit {

  appDetails$ = this.route.paramMap.pipe(
    flatMap(p => {
      const id = +p.get('id');
      return this.service.getAppDetails(id);
    })
  );

  constructor(private route: ActivatedRoute, private service: AppExplorerService) { }

  ngOnInit(): void {
  }

}
