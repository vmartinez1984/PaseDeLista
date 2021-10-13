import { Area } from "./Area";
import { Schedule } from "./Schedule";
import { SecurityQuestion } from "./SecurtyQuestion";

export class Employee {
  id: number;
  employeeNumber: string;
  name: string;
  lastName: string;
  photoInBase64: string;
  registrationdate: Date;
  areaId: number;
  area: Area;
  scheduleId: number;
  schedule: Schedule;
  listSecurityQuestions: SecurityQuestion[];
}
