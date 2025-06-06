import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { catchError, map, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(
    private http: HttpClient,
  ) { }

  getEmployees(): Observable<any> {
    return this.http
      .get<any>('http://localhost:5097/api/Employees').
      pipe(
        map((response) => {
          return response
        }),
        catchError((error) => {
          return throwError(() => new Error(error || "Erro no servidor!"));
        })
      )
  }

  getEmployeeById(id: number): Observable<any> {
    return this.http
      .get<any>(`http://localhost:5097/api/Employees/${id}`)
      .pipe(
        map((response) => {
          return response;
        }),
        catchError((error) => {
          return throwError(() => new Error(error || 'Erro no servidor!'))
        })
      )
  }

  register(employee: any): Observable<any> {
    return this.http
      .post<any>('http://localhost:5097/api/Employees', employee)
      .pipe(
        map((response) => {
          return response;
        }),
        catchError((err) => {
          return throwError(() => new Error(err));
        })
      );
  }

  update(data: any): Observable<any> {
    return this.http
      .put('http://localhost:5097/api/Employees', data)
      .pipe(
        map((response) => {
          return response;
        }),
        catchError((err) => {
          return throwError(() => new Error(err));
        })
      )
  }

  delete(id: number): Observable<any> {
    return this.http
      .delete<any>(`http://localhost:5097/api/Employees?id=${id}`)
      .pipe(
        map((response) => {
          return response;
        }),
        catchError((err) => {
          return throwError(() => new Error(err));
        })
      );
  }
}
