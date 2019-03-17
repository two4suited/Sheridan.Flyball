import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-club-list',
  templateUrl: './club-list.component.html'
})
export class ClubListComponent {
  public clubs: Clubs[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Clubs[]>(baseUrl + 'api/Club').subscribe(result => {
      this.clubs = result;
    }, error => console.error(error));
  }
}

interface Clubs {
  id : number;
  nafaClubNumber: number;
  name: string;  
}
