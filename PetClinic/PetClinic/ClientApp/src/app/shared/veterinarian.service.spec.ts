import { TestBed, inject } from '@angular/core/testing';

import { VeterinarianService } from './veterinarian.service';

describe('VeterinarianService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VeterinarianService]
    });
  });

  it('should be created', inject([VeterinarianService], (service: VeterinarianService) => {
    expect(service).toBeTruthy();
  }));
});
