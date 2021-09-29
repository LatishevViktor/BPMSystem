export class ViewModelEmployee{
  constructor(public id?: number,
              public firstName?: string,
              public lastName?: string,
              public dateOfBirth?: Date,
              public ediData?: Date,
              public workExperience?: number,
              public personNumber?: string,
              public positionId?: number,
              public positionName?: string,
              public departmentId?: number,
              public departmentName?: string) {
  }
}