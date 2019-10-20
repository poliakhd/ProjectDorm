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
    this.updatePages();
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

  updatePages() {
    const pages = new Array<number>();
    const limit = this.currentPage + 10 <= this.pageCount ? this.currentPage + 10 : this.pageCount;
    const current = this.currentPage - 5 >= 0 ? 5 : this.currentPage;

    for (let i = this.currentPage - current + 1; i < this.currentPage; i++) {
      pages.push(i);
    }

    for (let i = this.currentPage; i <= limit - current; i++) {
      pages.push(i);
    }

    this.pages = pages;
  }
}
