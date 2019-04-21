import { Component, OnInit, Input, EventEmitter, Output, OnChanges } from '@angular/core';

@Component({
  selector: 'app-paging',
  templateUrl: './paging.component.html',
  styleUrls: ['./paging.component.less']
})
export class PagingComponent implements OnInit, OnChanges {

  pages: Array<number>;

  @Input() pageCount: number;
  @Input() currentPage: number;

  @Output() previous: EventEmitter<number> = new EventEmitter();
  @Output() next: EventEmitter<number> = new EventEmitter();
  @Output() page: EventEmitter<number> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges() {
    console.log('entered');
    console.log(this.pageCount);
    this.pages = Array.from({length: this.pageCount}, (v, k) => k + 1);
  }

  previousPage() {
    if (this.currentPage - 1 > 0) {
      this.previous.emit(this.currentPage - 1);
    }
  }

  nextPage() {
    if (this.currentPage + 1 <= this.pageCount) {
      this.next.emit(this.currentPage + 1);
    }
  }

  openPage(page: number) {
    this.page.emit(page);
  }

  pageActive(index: number) {
    return {
      'active': index === this.currentPage
    };
  }

  pagePreviousDisabled() {
    return {
      'disabled': this.currentPage - 1 <= 0
    };
  }

  pageNextDisabled() {
    return {
      'disabled': this.currentPage + 1 > this.pageCount
    };
  }
}
