import { Component } from "@angular/core";
import { FormGroup, FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { EmployeeService } from "../../services/EmployeeService";
import { AreaService } from "../../services/areaService";
import { ScheduleService } from "../../services/scheduleService";
import { error } from "@angular/compiler/src/util";

@Component({
  selector: "app-save.employee",
  templateUrl: "save-employee.component.html"
}) export class SaveEmployeeComponent {
  formGroup: FormGroup;
  areas: any;
  schedules: any;
  id: any;
  label: string;

  constructor(
    private activateRoute: ActivatedRoute,
    private employeeService: EmployeeService,
    private areaService: AreaService,
    private scheduleService: ScheduleService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.id = this.activateRoute.snapshot.paramMap.get("id");
    this.getAreas();
    this.getSchedules();
    this.initForm();
    if (this.id == "0") {
      this.label = "Guardar";
    } else {
      this.label = "Editar";
      this.getEmployee();
    }
  }

  initForm() {
    this.formGroup = this.formBuilder.group({
      id: this.id,
      employeeNumber: [""],
      name: [""],
      lastName: [""],
      photoInBase64: [""],
      //registrationDate: [""],
      areaId: [""],
      scheduleId: [""],
      listSecurityQuestions: []
    });
  }

  getAreas(): any {
    this.areaService.getAll().subscribe(data => {
      console.log(data);
      this.areas = data;
    });
  }

  getSchedules(): any {
    this.scheduleService.getAll().subscribe(data => {
      this.schedules = data;
    });
  }

  getEmployee(): void {
    this.employeeService.get(this.id).subscribe(data => {
      console.log(data);
      this.formGroup.setValue({
        id: data['id'],
        employeeNumber: data["employeeNumber"],
        name: data["name"],
        lastName: data["lastName"],
        photoInBase64: data["photoInBase64"],
        //registrationDate: data["registrationDate"],
        areaId: data["areaId"],
        scheduleId: data["scheduleId"],
        listSecurityQuestions: data["listSecurityQuestions"]
      });
    })
  }

  save(): void {
    console.log(this.formGroup.value);
    if (this.id == "0") {
      this.employeeService.add(this.formGroup.value).subscribe(data => {
        console.log(data);
        alert("Datos registrados");
      }, error => {
        console.log(error);
      });
    } else {
      this.employeeService.update(this.formGroup.value).subscribe(data => {
        console.log(data);
        alert("Datos registrados");
      }, error => {
        console.log(error);
      });
    }
  }
}
