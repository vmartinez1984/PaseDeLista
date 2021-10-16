import { Component } from "@angular/core";
import { FormGroup, FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { SecurityQuestionService } from "../../services/SecurityQuestionService";

@Component({
  selector: "app-security-question",
  templateUrl: "./security-question.component.html"
}) export class SecurityQuestionComponent {
  formGorup: FormGroup;
  employeeId: any;
  listSecurityQuestions: any;

  constructor(
    private activateRoute: ActivatedRoute,
    private service: SecurityQuestionService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.employeeId = this.activateRoute.snapshot.paramMap.get('employeeId');
    this.getAll();
  }

  getAll(): any {
    this.service.getAll(this.employeeId).subscribe(data => {
      console.log(data);
    });
  }
}
