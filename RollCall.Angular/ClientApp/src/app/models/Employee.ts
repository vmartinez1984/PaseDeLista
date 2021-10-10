import { Area } from "./Area";
import { Schedule } from "./Schedule";

export class Employee {
  id: number;
  EmployeeNumber: string;
  Name: string;
  LastName: string;
  PhotoInBase64: string;
  Registrationdate: Date;
  AreaId: number;
  Area: Area;
  ScheduleId: number;
  Schedule: Schedule;
}
