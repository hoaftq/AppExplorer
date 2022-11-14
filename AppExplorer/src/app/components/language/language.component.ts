import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { AppExplorerService } from '../../services/app-explorer.service';

@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.scss']
})
export class LanguageComponent implements OnInit {

  private languagesChangeSubject = new BehaviorSubject(true);
  languagesChange$ = this.languagesChangeSubject.asObservable();

  languages$ = this.languagesChange$.pipe(
    switchMap(_ => this.service.languages$),
  );

  constructor(private service: AppExplorerService) { }

  ngOnInit(): void {
  }

  addLanguage(name: string) {
    this.service.addLanguage(name).subscribe(() => {
      this.languagesChangeSubject.next(true);
    });
  }

  updateLanguage(id: number, name: string) {
    this.service.updateLanguage({ id, name }).subscribe(() => {
      this.languagesChangeSubject.next(true);
    })
  }

  deleteLanguage(id: number) {
    this.service.deleteLanguage(id).subscribe(() => {
      this.languagesChangeSubject.next(true);
    });
  }
}
