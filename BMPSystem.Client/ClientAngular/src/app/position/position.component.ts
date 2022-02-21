import { ViewModelPosition } from 'src/ViewModels/Position/ViewModelPosition';
import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared-services/shared.service';

@Component({
  selector: 'app-position',
  templateUrl: './position.component.html',
  styleUrls: ['./position.component.css']
})
export class PositionComponent implements OnInit {

  constructor(private readonly service: SharedService) { }
  position: ViewModelPosition = new ViewModelPosition();
  positions: any[] = []

  ngOnInit(): void {
    this.refreshPosiitonList()
  }

  getPositionbyId(id: number){
    return this.service.getPos(id).subscribe(data => {
      this.position = data
    })
  }

  refreshPosiitonList(){
    this.service.getPosList().subscribe(data =>{
      this.positions = data
    })
  }
}
