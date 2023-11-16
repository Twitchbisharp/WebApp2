import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FlashcardsComponent } from './Flashcards/flashcards.component';
import { ConvertToCurrency } from './shared/convert-to-currency.pipe';
import { FlashcardformComponent } from "./Flashcards/flashcardform.component";



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FlashcardsComponent,
    ConvertToCurrency,
    FlashcardformComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'flashcards', component: FlashcardsComponent },
      { path: 'flashcardform', component: FlashcardformComponent },
      { path: 'flashcardform/:mode/:id', component: FlashcardformComponent },
      { path: "**", redirectTo: "", pathMatch: "full"} // This must be the last one in this list
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
