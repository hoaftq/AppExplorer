import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppExplorerService } from 'src/app/services/app-explorer.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoryDto, LanguageDto } from 'src/app/services/dtos';

@Component({
  selector: 'app-update-app',
  templateUrl: './update-app.component.html',
  styleUrls: ['./update-app.component.scss']
})
export class UpdateAppComponent implements OnInit {

  isNew: boolean;

  categories: CategoryDto[];
  languages: LanguageDto[];

  appForm: FormGroup;

  constructor(private route: ActivatedRoute,
    private service: AppExplorerService,
    private builder: FormBuilder) { }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('id');
    this.isNew = !id;

    this.categories = this.service.getCategories();
    this.languages = this.service.getLanguages();

    this.appForm = this.builder.group({
      id: [],
      name: ['', Validators.required],
      shortDescription: ['', Validators.required],
      description: [''],
      category: [],
      languages: this.builder.array(this.languages.map(l => this.builder.control(l.id))),
      level: [10, [Validators.min(1), Validators.max(10)]],
      url: [],
      sourceUrl: []
    });
  }

  onSave() {
    alert("Hello world");
  }
}
