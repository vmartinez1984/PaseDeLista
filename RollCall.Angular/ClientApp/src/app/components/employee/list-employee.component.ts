import { Component, OnInit } from "@angular/core";
import { EmployeeService } from "../../services/EmployeeService";
import Swal from 'sweetalert2'

@Component({
  selector: "app-list-employee",
  templateUrl: "./list-employee.component.html"
})
export class ListEmployeeComponent implements OnInit {
  Employees: any;

  ngOnInit() {
    Swal.fire({
      icon: 'info',
      title: 'Cargando...',
      allowOutsideClick: false,
      showConfirmButton: false
    });
  }

  constructor(private employeeService: EmployeeService) {
    this.employeeService.getAll().subscribe(data => {
      console.log(data);
      Swal.close();
      this.Employees = data;
    }, error => {
      Swal.fire({
        icon: 'error',
        title: 'Ocurrio un error, comuniquese con el administrador'
      });
      console.log(error);
    });
  }
}
