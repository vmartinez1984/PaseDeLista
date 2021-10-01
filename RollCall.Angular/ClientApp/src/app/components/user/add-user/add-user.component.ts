import { Component } from '@angular/core';
import { AreaService } from '../../../services/areaService';

@Component({
  selector: "app-add-user",
  templateUrl: "./add-user.component.html"
})
export class AddUserComponent {
  constructor(areaService: AreaService) {
    areaService.getAll().subscribe(data => {
      console.log(data);
    }, error => {
      console.log(error);
    });
  }
}
