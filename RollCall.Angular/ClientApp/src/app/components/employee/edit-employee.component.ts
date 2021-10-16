import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { EmployeeService } from "../../services/EmployeeService";
import { AreaService } from "../../services/areaService";
import { ScheduleService } from "../../services/scheduleService";
import { SecurityQuestionService } from "../../services/SecurityQuestionService";
import Swal from 'sweetalert2'

@Component({
  selector: "app-edit-employee",
  templateUrl: "/edit-employee.component.html"
}) export class EditEmployeeComponent implements OnInit {
  formGroup: FormGroup;
  areas: any;
  schedules: any;
  securityQuestions: any;
  id: any;

  ngOnInit() {
    Swal.fire({
      icon: 'info',
      title: 'Cargando...',
      allowOutsideClick: false,
      showConfirmButton: false
    });
  }

  constructor(
    private activateRoute: ActivatedRoute,
    private employeeService: EmployeeService,
    private scheduleService: ScheduleService,
    private areaService: AreaService,
    private securityQuestionsService: SecurityQuestionService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.id = this.activateRoute.snapshot.paramMap.get("id");
    this.getAreas();
    this.getSchedules();
    this.getEmployee();
    this.getSecurityQuestions();
    this.initForm();
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

  getSecurityQuestions(): any {
    this.securityQuestionsService.getAll(this.id).subscribe(data => {
      console.log(data);
      this.securityQuestions = data;
    });
  }

  getEmployee(): void {
    this.employeeService.get(this.id).subscribe(data => {
      console.log(data);
      Swal.close();
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
    }, error => {
      console.log(error);
      Swal.fire({
        icon: 'error',
        title: 'Ocurrio un error, comuniquese con el administrador'
      });
    });
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
        this.router.navigateByUrl("list-employee");
        alert("Datos registrados");
      }, error => {
        console.log(error);
      });
    }
  }
}
