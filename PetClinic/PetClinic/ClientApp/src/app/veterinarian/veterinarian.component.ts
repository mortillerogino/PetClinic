import { Component, OnInit } from '@angular/core';
import { VeterinarianService } from '../shared/veterinarian.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-veterinarian',
  templateUrl: './veterinarian.component.html',
  styles: []
})
export class VeterinarianComponent implements OnInit {

  veterinarians: any = [];

  constructor(private service: VeterinarianService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getVets().subscribe(
      (res: any) => {
        this.veterinarians = res;
      },
      err => {
        this.toastr.error(err, "Cannot Get Veterinarians");
      }
    )
  }

}
