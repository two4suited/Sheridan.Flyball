import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import {Club } from './Club';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({ providedIn: 'root' })
  export class ClubService {
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {    }

    addClub(club: Club): Observable<Club> {
        return this.http.post<Club>(this.baseUrl + 'api/club', club, httpOptions).pipe(
            tap((newClub: Club) => this.log(`Added Club with Id = ${newClub.id} `)),
            catchError(this.handleError<Club>('addClub'))
        );
    }

    getClubs(): Observable<Club[]> {
        return this.http.get<Club[]>(this.baseUrl + 'api/club').pipe(
            tap(_ => this.log('Fetched Clubs')),
            catchError(this.handleError<Club[]>('getClubs', []))
        );
    }



    private handleError<T> (operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

          console.error(error);
          this.log(`${operation} failed: ${error.message}`);
          return of(result as T);
        };
      }

      private log(message: string) {
        console.log(`ClubService: ${message}`);
      }
  }

