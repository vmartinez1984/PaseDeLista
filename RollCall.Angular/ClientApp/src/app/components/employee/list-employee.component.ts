import { Component } from "@angular/core";
import { EmployeeService } from "../../services/EmployeeService";

@Component({
  selector: "app-list-employee",
  templateUrl: "./list-employee.component.html"
})
export class ListEmployeeComponent {
  Employees: any;

  constructor(private employeeService: EmployeeService) {
    this.employeeService.getAll().subscribe(data => {
      console.log(data);
      this.Employees = data;
    }, error => { console.log(error); });
  }
}
