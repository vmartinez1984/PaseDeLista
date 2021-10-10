import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder } from "@angular/forms";
import { Router } from "@angular/router";
import { AreaService } from "../../../services/areaService";

@Component({
  selector: "app-add-area",
  templateUrl: "./add-area.component.html"
})
export class AddAreaComponent implements OnInit {
  formGroup: FormGroup;

  constructor(
    private areaService: AreaService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.formGroup = formBuilder.group({
      id: [0],
      name: [''],
      description: ['']
    });
  }

  ngOnInit(): void { }

  add(): any {
    console.log(this.formGroup.value);
    this.areaService.add(this.formGroup.value).subscribe(data => {
      alert("Datos registrados");
      this.router.navigateByUrl("list-area");
    }, error => {
      console.log("Valio pepino");
      console.log(error);
    });
  }
}
