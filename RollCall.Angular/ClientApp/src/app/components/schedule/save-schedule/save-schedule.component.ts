import { Component } from "@angular/core";
import { FormGroup, FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ScheduleService } from "../../../services/scheduleService";

@Component({
  selector: "app-save-schedule",
  templateUrl: "./save-schedule.component.html"
})
export class SaveScheduleComponent {
  formGroup: FormGroup;
  id: any;
  label: string = "Guardar";

  constructor(
    private activeRoute: ActivatedRoute,
    private scheduleService: ScheduleService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.id = this.activeRoute.snapshot.paramMap.get("id");
    console.log(this.id);
    if (this.id != 0) {
      this.label = "Editar";
      this.scheduleService.get(this.id).subscribe(data => {
        this.formGroup.setValue({
          id: data["id"],
          startTime: data["startTime"],
          stopTime: data["stopTime"]
        }), error => {
          console.log(error);
        }
      });
    }
    this.formGroup = formBuilder.group({
      id: this.id,
      startTime: [''],
      stopTime: ['']
    });
  }

  save() {
    console.log(this.formGroup.value);
    var now = new Date();
    //console.log(this.formGroup.value["startTime"] = new Date(now.getFullYear(), now.getMonth(), now.getDay(), this.formGroup.value["startTime"].);
    if (this.id == 0) {
      this.scheduleService.add(this.formGroup.value).subscribe(data => {
        alert("Datos registrados");
      }, error => { console.log(error); });
    } else {
      this.scheduleService.update(this.formGroup.value).subscribe(data => {
        alert("Datos registrados");
      }, error => { console.log(error); });
    }
  }
}
