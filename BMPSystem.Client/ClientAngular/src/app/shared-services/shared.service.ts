import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})

export class SharedService{
  readonly API_URL = 'https://localhost:44338/api'
  constructor(private http: HttpClient) {}
  // Сервис по отправке запросов к отделам
  getDepList():Observable<any[]> {
    return this.http.get<any>(this.API_URL + '/department')
  }

  addDepartment(val: any){
    return this.http.post(this.API_URL + '/department', val)
  }
  
  updateDepartment(val: any){
    return this.http.put(this.API_URL + '/department', val)
  }

  getDep(id: number){
    let test = this.API_URL + '/department/' + id
    return  this.http.get(this.API_URL + '/department/' + id)
  }

  deleteDep(id: number){
    return  this.http.delete(this.API_URL + '/department/' + id)
  }

  // Сервис по отправке запросов сотрудникам
  getEmpList(){
    return this.http.get<any[]>(this.API_URL + '/employee')
  }

  addEmployee(val: any){
    return this.http.post(this.API_URL + '/employee', val)
  }
  
  updateEmployee(val: any){
    return this.http.put(this.API_URL + '/employee', val)
  }

  getEmp(id: number){
    return  this.http.get(this.API_URL + '/employee/' + id)
  }

  deleteEmp(id: number){
    return  this.http.delete(this.API_URL + '/employee/' + id)
  }

  // Сервис по отправке запросов должностям
  getPosList(){
    return this.http.get<any[]>(this.API_URL + '/position')
  }

  addPosition(val: any){
    return this.http.post(this.API_URL + '/position', val)
  }
  
  updatePosition(val: any){
    return this.http.put(this.API_URL + '/position', val)
  }

  getPos(id: number){
    return  this.http.get(this.API_URL + '/position/' + id)
  }

  deletePos(id: number){
    return  this.http.delete(this.API_URL + '/position/' + id)
  }
}