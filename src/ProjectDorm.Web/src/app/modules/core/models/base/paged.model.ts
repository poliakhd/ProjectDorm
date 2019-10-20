export class Paged<T> {
    currentPage: number;
    pageCount: number;
    pageSize: number;
    rowCount: number;
    result: Array<T>;
}
