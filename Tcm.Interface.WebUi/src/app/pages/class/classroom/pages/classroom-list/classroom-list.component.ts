import { Component, OnInit } from '@angular/core';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';
import { ClassRoom } from '../../models/classroom';
import { ClassRoomService } from '../../services/classroom.service';
import { Router, ActivatedRoute } from '@angular/router';
import { EducationLevel } from 'src/app/pages/baseInfo/educationLevel/models';
import { AuthService } from 'src/app/authentication/services';

@Component({
  selector: 'app-classroom-list',
  templateUrl: './classroom-list.component.html',
  styleUrls: ['./classroom-list.component.css']
})
export class ClassRoomListComponent extends CrudComponent<ClassRoom> implements OnInit {
 
  public subject: string = "classroom";

  constructor(private classRoomService: ClassRoomService, private authService: AuthService, route: ActivatedRoute, router: Router) { 

    super(classRoomService,route,router);
    this.dictionary = this.classRoomService.GetDictionary();
    this.items = new Array<ClassRoom>();

  }

  ngOnInit() {

    const schoolId = this.authService.decodedToken().SchoolId;


    this.classRoomService.GetAllBySchoolId(schoolId).subscribe((items: Array<ClassRoom>) => {
      this.items = items;
    })
  
  }
}
