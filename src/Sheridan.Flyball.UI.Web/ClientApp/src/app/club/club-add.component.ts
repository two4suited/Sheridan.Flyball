import { Component } from '@angular/core';
import {Club} from './Club';
import {ClubService} from './club.service';

@Component({
  selector: 'app-club-add',
  templateUrl: './club-add.component.html'
})
export class ClubAddComponent {
  public club: Club = new Club();

  addClub() {
      if (this.club) {
        this.clubService.addClub(this.club).subscribe();
      }
  }

  constructor(private clubService: ClubService) {
  }
}


