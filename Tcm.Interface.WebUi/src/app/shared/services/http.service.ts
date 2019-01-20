import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import {  Response } from '@angular/http';
import { Observable, of, } from 'rxjs';
import {ajax} from 'rxjs/ajax';
import { map, catchError, tap } from 'rxjs/operators';
import { PaginationResult } from 'src/app/core/models/pagination';



@Injectable()
export class HttpService <T> {
 
  public endpoint:string="";
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };
  constructor(private http:HttpClient)
  {
  
  }
 
  private extractData(res: Response):T {
    let body = res;
    return ;
  }

  getAll(): Observable<Array<T>> {
  
    return this.http.get<Array<T>>(this.endpoint);
  }
  
  get(id): Observable<T> {
    return this.http.get<T>(this.endpoint +  id);
  }
  
  add (T): Observable<T> {
    console.log(T);
    return this.http.post<T>(this.endpoint , JSON.stringify(T), this.httpOptions).pipe(
      tap((T) => console.log(`added  w/ `)),
      catchError( this.handleError<any>('add'))
    );
  }
  
  update(id, T): Observable<T> {
    return this.http.put(this.endpoint  + id, JSON.stringify(T), this.httpOptions).pipe(
      tap(_ => console.log(`updated  id=${id}`)),
      catchError(this.handleError<any>('updateCar'))
    );
  }
  
  delete (id): Observable<T> {
    return this.http.delete<any>(this.endpoint  + id, this.httpOptions).pipe(
      tap(_ => console.log(`deleted  id=${id}`)),
      catchError(this.handleError<any>('deleteCar'))
    );
  }


  GetAllForGrid(page?: number, itemsPerPage?: number, userParams?: any): Observable<PaginationResult<T>> {
    const paginatedResult: PaginationResult<T> = new PaginationResult<T>();
    let params = new HttpParams();
    let items = new Array<T>();

    if (page && itemsPerPage) {
        params = params.append('pageNumber', page.toString());
        params = params.append('pageSize', itemsPerPage.toString());
    }

    // Apply the filtering if provided in the userParams
    if (userParams) {
        if (userParams.gender) {
            params = params.append('gender', userParams.gender);
        }
        if (userParams.minAge) {
            params = params.append('minAge', userParams.minAge);
        }
        if (userParams.maxAge) {
            params = params.append('maxAge', userParams.maxAge);
        }
        if (userParams.orderBy) {
            params = params.append('orderBy', userParams.orderBy);
        }
    }

  return   this.http.get<Array<T>>(this.endpoint, {observe: 'response', params}).pipe(map(response=>{
      paginatedResult.result = response.body;
      if (response.headers.get('pagination')) {
        paginatedResult.pagination = JSON.parse(response.headers.get('pagination'));
      
      } 
    
        return paginatedResult;
    }));

    }
      
       
    
      
 
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}