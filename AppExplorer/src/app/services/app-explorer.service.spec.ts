import { TestBed } from '@angular/core/testing';

import { AppExplorerService } from './app-explorer.service';

describe('AppExplorerService', () => {
  let service: AppExplorerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppExplorerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
