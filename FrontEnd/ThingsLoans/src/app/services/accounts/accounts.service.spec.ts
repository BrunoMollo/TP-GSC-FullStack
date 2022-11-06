import { TestBed } from '@angular/core/testing';
import { MockUserApiService } from '../usersApi/mock-user-api.service';
import { UserApiService } from '../usersApi/user-api.service';

import { AccountsService } from './accounts.service';

describe('AccountsService', () => {
  let service: AccountsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers:[
        { provide:UserApiService, useValue: MockUserApiService }
      ]
    });
    service = TestBed.inject(AccountsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
