import { Component, OnInit } from '@angular/core';
import {Club} from './Club';
import {ClubService} from './club.service';

@Component({
  selector: 'app-club-list',
  templateUrl: './club-list.component.html'
})
export class ClubListComponent implements OnInit {
  public clubs: Club[];

  constructor(private clubService: ClubService) {  }
  ngOnInit() {
    this.clubService.getClubs().subscribe(clubs => this.clubs = clubs);
  }
}

