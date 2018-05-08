import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { Kundeservice } from './kundeservice.component';
import { FilterPipe } from './pipe';
import { OrderByPipe } from './orderby.pipe';

@NgModule({
    imports: [BrowserModule, FormsModule, ReactiveFormsModule, HttpModule, JsonpModule],
    declarations: [Kundeservice, FilterPipe, OrderByPipe],
    bootstrap: [Kundeservice]
})
export class AppModule { }

