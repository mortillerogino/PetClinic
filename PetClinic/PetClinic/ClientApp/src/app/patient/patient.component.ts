import { Component, OnInit } from '@angular/core';
import { PatientService } from '../shared/patient.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styles: []
})
export class PatientComponent implements OnInit {

  patients:any = [];
  isDelete: boolean = false;
  searchString: string;
  nameAsc: boolean;
  dateAsc: boolean;

  constructor(private service: PatientService, private toastr: ToastrService) { }

  ngOnInit() {
    this.sort("", "");
  }

  onDetailsClick(event, id) {
    if (!this.isDelete) {
      this.service.getPatient(id);
    }
    
    this.isDelete = false;
  }

  sort(search: string, sort: string) {
    this.service.searchPatient(search, sort)
      .toPromise()
      .then((data: any) => {
        this.patients = data;
        if (sort === "") {
          this.nameAsc = true;
        }
      },
        err => {
          console.error(err)
        });
  }

  onSearch(search: string) {
    this.sort(search, "");
  }

  onSortName() {
    let sort = "patient_desc";
    if (this.nameAsc === true) {
      this.nameAsc = false;
    }
    else {
      sort = ""
      this.nameAsc = true;
    }

    let search = "";
    if (this.searchString) {
      search = this.searchString;
    }

    this.sort(search, sort);
  }

  onSortDate() {
    let sort = "date_desc";
    if (this.dateAsc === true) {
      this.dateAsc = false;
    }
    else {
      sort = "date_asc"
      this.dateAsc = true;
    }

    let search = "";
    if (this.searchString) {
      search = this.searchString;
    }

    this.sort(search, sort);
  }

  onDelete(id, name) {
    this.isDelete = true;
    if (confirm("Are you sure to delete " + name)) {
      this.service.delete(id).subscribe(
        (res: any) => {
          var index = this.patients.indexOf(res);
          this.deletePatientFromUI(id);
          this.toastr.success("Patient " + res.name + ' Deleted', 'Process Successful.');
        },
        err => {
          this.toastr.error(err, "Process Failed.");
        }
      );
    }
  }

  deletePatientFromUI(id) {
    let index = -1;
    for (var i = 0; i < this.patients.length; i++) {
      if (this.patients[i].id === id) {
        index = i;
      }
    }
    this.patients.splice(index, 1);
  }

}
