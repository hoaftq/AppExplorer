import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-app',
  templateUrl: './update-app.component.html',
  styleUrls: ['./update-app.component.scss']
})
export class UpdateAppComponent implements OnInit {

  isNew: boolean;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('id');
    this.isNew = !id;
  }

}
