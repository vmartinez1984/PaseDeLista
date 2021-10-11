import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AreaService } from "../../../services/areaService";

@Component({
  selector: "app-edit-area",
  templateUrl: "./edit-area.component.html"
})
export class EditAreaComponent implements OnInit {
  formGroup: FormGroup;
  id: any;

  constructor(
    private activateRoute: ActivatedRoute,
    private areaService: AreaService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.id = this.activateRoute.snapshot.paramMap.get('id');

    this.areaService.get(this.id).subscribe(data => {
      console.log(data);
      this.formGroup.setValue({
        id: data["id"],
        name: data["name"],
        description: data["description"]
      });
    }, error => {
      console.log(error);
    });

    this.formGroup = formBuilder.group({
      id: [''],
      name: [''],
      description: ['']
    });
  }

  ngOnInit(): void { }

  update(): any {
    this.areaService.update(this.formGroup.value).subscribe(data => {
      alert("Datos registrados");
      this.router.navigateByUrl("list-area");
    }, error => {
      console.log(error);
    });
  }
}
