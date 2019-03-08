import { Injectable } from '@angular/core';
import { TaskType, SubjectType, Permission, RoleType } from 'src/app/core/models';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {


  public userPermissions :Array<Permission>;
  public hasPermission:boolean =false;
  public role :RoleType;

  constructor() {
    this.userPermissions = new Array<Permission>();
  }


   GetPermissions(value:string){

    this.role = RoleType[value];
    this.userPermissions.push(new Permission(SubjectType.educationyear, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.educationyear, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.educationyear, TaskType.edit));

    this.userPermissions.push(new Permission(SubjectType.educationlevel, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.educationlevel, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.educationlevel, TaskType.edit));

    this.userPermissions.push(new Permission(SubjectType.educationcourse, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.educationcourse, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.educationcourse, TaskType.edit));

    this.userPermissions.push(new Permission(SubjectType.educationsubcourse, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.educationsubcourse, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.educationsubcourse, TaskType.edit));

    this.userPermissions.push(new Permission(SubjectType.major, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.major, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.major, TaskType.edit));

    this.userPermissions.push(new Permission(SubjectType.schooltype, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.schooltype, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.schooltype, TaskType.edit));

    this.userPermissions.push(new Permission(SubjectType.schoolsubtype, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.schoolsubtype, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.schoolsubtype, TaskType.edit));

    this.userPermissions.push(new Permission(SubjectType.schoollist, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.schoollist, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.schoollist, TaskType.edit));

    this.userPermissions.push(new Permission(SubjectType.classroom, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.classroom, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.classroom, TaskType.edit));
   }

   HasPermission(subject:SubjectType,task:TaskType):boolean{
  
    this.GetPermissions('Admin');
    let subPermission :boolean =false;
    let taskPermission :boolean =false;
    

    if(subject){
         this.userPermissions.forEach(sub => { if(sub.subject==subject){ subPermission = true}} )
    }else{
     subPermission =true;

    }

    if(task){
      this.userPermissions.forEach(sub => { if(sub.subject==subject && sub.task == task){ taskPermission = true}} )

    }else{
      taskPermission=true;
    }

    return subPermission && taskPermission;

  }

  //  this._task = TaskType[this.task];
  //  this._subject = SubjectType[this.subject];
   
  //    if(!this._subject){
  //    if(this.router.snapshot.data.permission)
  //             {
  //    if(this.router.snapshot.data.permission.subject)
  //    {

  //    this.subject = this.router.snapshot.data.permission.subject;
  //    this._subject = SubjectType[this.subject];
  //    }
  //    }
    
}
