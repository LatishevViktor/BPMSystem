import { ViewModelEmployee } from './../../ViewModels/Employee/ViewModelEmployee';
import { SharedService } from './../shared-services/shared.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private readonly service: SharedService) { }
  employee: ViewModelEmployee = new ViewModelEmployee()
  employees: any[] = []

  ngOnInit(): void {
    this.refreshDepList()
  }

  getEmployee(id: number){
    this.service.getEmp(id).subscribe(data => {
      this.employee = data
    })
  }

  deleteEmployees(id: number){
    this.service.deleteEmp(id).subscribe(data => data)
  }

  refreshDepList(){
    this.service.getEmpList().subscribe(data => {
      this.employees = data
    })
  }

}
