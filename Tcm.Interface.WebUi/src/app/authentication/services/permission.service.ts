import { Injectable } from '@angular/core';
import { AuthService } from 'src/app/authentication/services';
import { TaskType, SubjectType, Permission, RoleType } from 'src/app/core/models';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {


  public userPermissions: Array<Permission>;
  public hasPermission: boolean = false;
  public role: RoleType;
  constructor() {
    this.userPermissions = new Array<Permission>();


  }


  GetPermissions(value: string) {

    this.role = RoleType[value];
    this.userPermissions.push(new Permission(SubjectType.educationlevel, TaskType.add));
    this.userPermissions.push(new Permission(SubjectType.educationlevel, TaskType.delete));
    this.userPermissions.push(new Permission(SubjectType.educationlevel, TaskType.edit));
    // this.userPermissions.push(new Permission(SubjectType.dashboard,TaskType.update));
  }

  HasPermission(subject: SubjectType, task: TaskType): boolean {


    let subPermission: boolean = false;
    let taskPermission: boolean = false;

    this.GetPermissions('Admin');
    if (subject) {
      this.userPermissions.forEach(sub => { if (sub.subject == subject) { subPermission = true } })
    } else {
      subPermission = true;
    }

    if (task) {
      this.userPermissions.forEach(sub => { if (sub.subject == subject && sub.task == task) { taskPermission = true } })

    } else {
      taskPermission = true;
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
