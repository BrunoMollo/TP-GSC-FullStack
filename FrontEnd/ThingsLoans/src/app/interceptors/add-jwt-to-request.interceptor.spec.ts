import { TestBed } from '@angular/core/testing';

import { AddJwtToRequestInterceptor } from './add-jwt-to-request.interceptor';

describe('AddJwtToRequestInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      AddJwtToRequestInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: AddJwtToRequestInterceptor = TestBed.inject(AddJwtToRequestInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
