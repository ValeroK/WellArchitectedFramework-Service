import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { CdkTableModule } from '@angular/cdk';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { MdCardModule, MdToolbarModule, MdTableModule } from '@angular/material';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        CdkTableModule,
        MdCardModule, MdToolbarModule, MdTableModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
