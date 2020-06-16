import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  public get IsAuthorized(): boolean {
    return true;
  }

  constructor() { }
}
