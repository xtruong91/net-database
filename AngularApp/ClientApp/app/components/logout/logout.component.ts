import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Helpers } from '../../helpers/helpers';

@Component({
    selector: 'app-logout',
    templateUrl: './logout.component.html',
    template: '<ng-content></ng-content>',
    styleUrls: ['./logout.component.scss'],
})
export class LogoutComponent implements OnInit {

    constructor(private router: Router, private helpers: Helpers) { }

    ngOnInit() {
        this.helpers.logout();

        this.router.navigate(['/login']);
    }

}