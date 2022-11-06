import { TestBed } from '@angular/core/testing';
import { MockUserApiService } from '../services/usersApi/mock-user-api.service';
import { UserApiService } from '../services/usersApi/user-api.service';

import { AddJwtToRequestInterceptor } from './add-jwt-to-request.interceptor';

describe('AddJwtToRequestInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers:[
      AddJwtToRequestInterceptor,
      { provide:UserApiService, useValue: MockUserApiService }
    ]
  }));

  it('should be created', () => {
    const interceptor: AddJwtToRequestInterceptor = TestBed.inject(AddJwtToRequestInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
