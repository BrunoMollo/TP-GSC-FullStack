import { TestBed } from '@angular/core/testing';
import { MockUserApiService } from '../services/usersApi/mock-user-api.service';
import { UserApiService } from '../services/usersApi/user-api.service';

import { IsLoggedInGuard } from './is-logged-in.guard';

describe('IsLoggedInGuard', () => {
  let guard: IsLoggedInGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers:[
        { provide:UserApiService, useValue: MockUserApiService }
      ]
    });
    guard = TestBed.inject(IsLoggedInGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
