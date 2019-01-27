import { Component, OnInit, Input, Output, EventEmitter, TemplateRef } from '@angular/core';
import { Pagination } from 'src/app/core/models/pagination';
import { Pair, TaskType, SubjectType } from 'src/app/core/models';
import { Router } from '@angular/router';

import { PermissionService } from 'src/app/authentication/services/permission.service';
import { Message } from 'src/app/core/models/message.enum';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-grid',
  templateUrl: './app-grid.component.html'
})
export class AppGridComponent implements OnInit {

  deleteConfirmMessage = Message.actionConfirm;
  deletedItem: any;
  modalRef: BsModalRef;
  @Input() items: any[];
  @Input() dictionary: Array<Pair>;
  @Input() subject: string;
  @Input() pagination: Pagination;
  @Input() editable: boolean = false;
  @Input() removable: boolean = false;

  @Output() onSort = new EventEmitter();
  @Output() onPageChanged = new EventEmitter();
  @Output() onEdit = new EventEmitter();
  @Output() onRemove = new EventEmitter();

  showGrid: boolean = false;


  constructor(private router: Router, private permissionService: PermissionService, private modalService: BsModalService) { }

  ngOnInit() {

    this.deletedItem = null;
    this.showGrid = true;
    let _subject = SubjectType[this.subject];

    if (this.permissionService.HasPermission(_subject, TaskType.edit) && this.editable) {

      this.editable = true;

    } 
    else {
      this.editable = false;
    }

    if (this.permissionService.HasPermission(_subject, TaskType.delete) && this.removable) {

      this.removable = true;

    } 
    else {
      this.removable = false;
    }

  }


  pageChanged(event: any): void {
    this.onPageChanged.emit(event);
  }

  getIndex(value: number): number {
    return ((this.pagination.currentPage - 1) * this.pagination.itemsPerPage) + value + 1;
  }

  edit(value: any) {
    this.onEdit.emit(value);

  }

  remove(value: any, template: TemplateRef<any>) {

    this.deletedItem = value;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });

    // if (confirm(Message.actionConfirm)) {

    //   this.onRemove.emit(value);
    //   if ((this.pagination.currentPage - 1) * (this.pagination.itemsPerPage) == this.pagination.totalItems - 1)
    //     this.pagination.currentPage--;
    // }

  }

  confirm(): void {

    this.onRemove.emit(this.deletedItem);
    if ((this.pagination.currentPage - 1) * (this.pagination.itemsPerPage) == this.pagination.totalItems - 1)
      this.pagination.currentPage--;

    this.hideModal();

  }

  hideModal(): void {
    this.deletedItem = null;
    this.modalRef.hide();
  }

  sort(value: any) {


    if (this.pagination.orderBy == value) {

      if (this.pagination.orderByType == "DESC") {
        this.pagination.orderByType = "ASC";
      } else {
        this.pagination.orderByType = "DESC"
      }
    }
    else {
      this.pagination.orderBy = value;
      this.pagination.orderByType = "ASC";
    }
    this.onSort.emit(this.pagination);

  }
}
