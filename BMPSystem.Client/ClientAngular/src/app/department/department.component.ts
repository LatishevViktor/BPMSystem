import { ViewModelEmployee } from './../../ViewModels/Employee/ViewModelEmployee';
import { ViewModelDepartment } from './../../ViewModels/Departments/ViewModelDepartments';
import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared-services/shared.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  constructor(private readonly service: SharedService) { }
  department: ViewModelDepartment = new ViewModelDepartment()
  departments: any = [];

   ngOnInit(): void {
     this.refreshDepList()
  }

  refreshDepList(){
    this.service.getDepList().subscribe(data => {
      this.departments = data
    })
  }
}

