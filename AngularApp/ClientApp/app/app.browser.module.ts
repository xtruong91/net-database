import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';



// The old component
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './layout/app.component';
import { AppRoutingModule } from './app-routing.module';

import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { HeadComponent } from './layout/head.component';
import { LeftPanelComponent } from './layout/left-panel.component';
import { LogoutComponent } from './components/logout/logout.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UsersComponent } from './components/users/users.component';


@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        HeadComponent,
        LeftPanelComponent,
        LogoutComponent,
        LoginComponent,
        DashboardComponent,
        UsersComponent
    ],
    imports: [
        BrowserModule,
        AppModuleShared,
        BrowserAnimationsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatFormFieldModule,
        MatSidenavModule,
        AppRoutingModule,
        HttpClientModule
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
