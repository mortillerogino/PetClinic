import { Component, OnInit } from '@angular/core';
import { PatientService } from '../shared/patient.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../shared/user.service';

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
  pageIndex: number = 1;
  pageSize: number = 5;
  hasNextPage: boolean;
  hasPrevPage: boolean;
  lastSort: string;

  constructor(private service: PatientService, private toastr: ToastrService, private userService: UserService) { }

  private isVet;

  ngOnInit() {
    this.sort("", "");
    this.isVet = this.userService.roleMatch(['Veterinarian']);
  }

  onDetailsClick(event, id) {
    if (!this.isDelete) {
      this.service.getPatient(id);
    }
    
    this.isDelete = false;
  }

  sort(search: string, sort: string) {
    this.service.searchPatient(search, sort, this.pageIndex, this.pageSize)
      .toPromise()
      .then((data: any) => {
        this.patients = data.patients;
        this.hasNextPage = data.hasNextPage;
        this.hasPrevPage = data.hasPreviousPage;
        if (sort === "") {
          this.nameAsc = true;
        }
        this.lastSort = sort;
      },
        err => {
          this.toastr.error(err.error.Message, "Cannot get Patients")
        });
  }

  onPageChange(step: number) {
    this.pageIndex += step;

    let search = "";
    if (this.searchString) {
      search = this.searchString;
    }

    let sort = "";
    if (this.lastSort) {
      sort = this.lastSort;
    }

    this.sort(search, sort);
  }

  onSearch(search: string) {
    this.pageIndex = 1;
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

    this.pageIndex = 1;
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

    this.pageIndex = 1;
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
          this.toastr.error(err.error.Message, "Process Failed.");
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
