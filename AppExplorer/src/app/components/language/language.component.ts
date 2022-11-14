import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { AppExplorerService } from '../../services/app-explorer.service';
import { Message } from '../shared/messages/message';

@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.scss']
})
export class LanguageComponent implements OnInit {

  private languagesChangeSubject = new BehaviorSubject(true);
  languagesChange$ = this.languagesChangeSubject.asObservable();

  private messagesSubject = new Subject<Message[]>();
  messages$ = this.messagesSubject.asObservable();

  languages$ = this.languagesChange$.pipe(
    switchMap(_ => this.service.languages$),
  );

  constructor(private service: AppExplorerService) { }

  ngOnInit(): void {
  }

  addLanguage(name: string) {
    this.service.addLanguage(name).subscribe(() => {
      this.languagesChangeSubject.next(true);
      this.messagesSubject.next([{ level: 'success', message: 'Added language successfully' }]);
    });
  }

  updateLanguage(id: number, name: string) {
    this.service.updateLanguage({ id, name }).subscribe(() => {
      this.languagesChangeSubject.next(true);
      this.messagesSubject.next([{ level: 'success', message: 'Updated language successfully' }]);
    })
  }

  deleteLanguage(id: number) {
    this.service.deleteLanguage(id).subscribe(() => {
      this.languagesChangeSubject.next(true);
      this.messagesSubject.next([{ level: 'success', message: 'Deleted language successfully' }]);
    });
  }
}
