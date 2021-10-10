import { Component } from "@angular/core";
import { ScheduleService } from "../../../services/scheduleService";

@Component({
  selector: "app-list-area",
  templateUrl: "./list-schedule.component.html"
})
export class ListSchedulesComponent {
  Schedules: any;

  constructor(private scheduleService: ScheduleService) {
    this.scheduleService.getAll().subscribe(data => {
      console.log(data);
      this.Schedules = data;
    }, error => {
      console.log(error);
    });
  }

  delete(id: number, index: number): void {
    console.log(id);
    if (window.confirm("¿Desea borrar el horario ?")) {
      this.scheduleService.delete(id).subscribe(response => {
        this.Schedules.splice(index);
      }, error => {
        console.log(error);
      });
    }
  }
}
