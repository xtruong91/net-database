import { Component, AfterViewInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { startWith } from 'rxjs/operators';
import { Helpers } from '../helpers/helpers';
import { delay } from 'q';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewInit {
    subscription: Subscription;
    authentication: boolean;

    constructor(private helpers: Helpers) {
    }

    ngAfterViewInit() {
        this.subscription = this.helpers.isAuthenticationChanged().pipe(
            startWith(this.helpers.isAuthenticated()),
            delay(0)).subscribe((value) => this.authentication = value);
    }

    title = 'friendly-goggles';

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}