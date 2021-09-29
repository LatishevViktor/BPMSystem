import { ViewModelEmployee } from './../Employee/ViewModelEmployee';
export class ViewModelDepartment{
  constructor(public id?: number,
              public name?: string, 
              public extensionNumber?: number,
              public employees?: ViewModelEmployee[]) {
  }
}