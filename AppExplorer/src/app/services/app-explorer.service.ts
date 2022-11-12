import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppDetailsDto, AppDto, CategoryDto, LanguageDto } from '../dtos/app-dtos';
import { flatMap, map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AppExplorerService {

  baseUrl = "https://localhost:44370/api";

  constructor(private http: HttpClient) { }

  getCategories(): CategoryDto[] {
    return [
      { id: 1, name: 'Game' },
      { id: 2, name: "Tool" }
    ];
  }

  getLanguages(): LanguageDto[] {
    return [
      { id: 1, name: "Java" },
      { id: 2, name: "C#" },
      { id: 3, name: "Typescript" }];
  }

  languages$ = this.http.get<LanguageDto>(`${this.baseUrl}/language`);

  categories$ = this.http.get<CategoryDto>(`${this.baseUrl}/category`);

  apps$ = this.http.get<AppDto[]>(`${this.baseUrl}/app`);

  recentApps$ = this.apps$.pipe(
    map(apps => apps.slice(0, 4))
  );

  getAppDetails(id: number) {
    return this.http.get<AppDetailsDto>(`${this.baseUrl}/app/${id}`);
  }
}
