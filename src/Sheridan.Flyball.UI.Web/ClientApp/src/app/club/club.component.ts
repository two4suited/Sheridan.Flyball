import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'club',
    templateUrl: 'club.component.html'
})

export class ClubComponent implements OnInit {
    public add = false;

    constructor() { }

    ngOnInit() { }

    onAdd(): void {
      if(this.add)
        this.add=false
      else
        this.add=true;
    }
}
