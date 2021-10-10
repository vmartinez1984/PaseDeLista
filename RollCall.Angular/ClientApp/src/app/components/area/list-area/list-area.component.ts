import { Component, OnInit } from "@angular/core";
import { AreaService } from "../../../services/areaService";

@Component({
  selector: "app-list-area",
  templateUrl: "./list-area.component.html"
})
export class ListAreaComponent {
  Areas: any;

  constructor(private areaService: AreaService) {
    this.areaService.getAll().subscribe(response => {
      console.log(response);
      this.Areas = response;
    }, error => {
      console.log(error);
    });
  }

  delete(id: number, index: number): void {
    console.log(id);
    if (window.confirm("¿Desea borrar la area ?")) {
      this.areaService.delete(id).subscribe(response => {
        this.Areas.splice(index);
      }, error => {
        console.log(error);
      });
    }
  }
}
