export class Pagination {
    constructor(public currentPage?: number,

        public itemsPerPage?: number,
    
        public  totalItems?: number,
    
        public totalPages?: number
    ){

    }
}

export class PaginationResult<T> {
    result: T[];
    pagination: Pagination;
}
