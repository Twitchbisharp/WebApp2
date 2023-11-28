import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FlashcardsComponent } from './Flashcards/flashcards.component';
import { CollectionsComponent } from './Collections/collections.component';
import { CollectionFlashcardComponent } from './CollectionFlashcard/collectionFlashcards.component';
import { ContributersComponent } from './Contributers/contributers.component';
import { ConvertToCurrency } from './shared/convert-to-currency.pipe';
import { FlashcardformComponent } from "./Flashcards/flashcardform.component";
import { CollectionformComponent } from "./Collections/collectionform.component";
import { PlayComponent } from "./Play/play.component";
import { CollectionFlashcardForm } from "./CollectionFlashcard/collectionFlashcardform.component";




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FlashcardsComponent,
    CollectionsComponent,
    ContributersComponent,
    FlashcardformComponent,
    CollectionformComponent,
    CollectionFlashcardComponent,
    PlayComponent,
    CollectionFlashcardForm,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },

      // Flashcard URLs
      { path: 'flashcards', component: FlashcardsComponent },
      { path: 'flashcardform', component: FlashcardformComponent },
      { path: 'flashcardform/:mode/:id', component: FlashcardformComponent },

      // Play URLs
      { path: 'play', component: PlayComponent },
      { path: 'play/:id', component: PlayComponent },

      // Collection URLs
      { path: 'collections', component: CollectionsComponent },
      { path: 'collectionform', component: CollectionformComponent },
      { path: 'collectionform/:mode/:id', component: CollectionformComponent },

      // CollectionFlashcard URLs
      { path: 'collectionFlashcard', component: CollectionFlashcardComponent },
      { path: 'collectionFlashcard/:id', component: CollectionFlashcardComponent },
      { path: 'collectionFlashcardform', component: CollectionformComponent },
      { path: 'collectionFlashcardform/:mode/:id', component: CollectionformComponent },

      // Contributer URLs
      { path: 'contributers', component: ContributersComponent},

      // This must be the last one in this list
      { path: "**", redirectTo: "", pathMatch: "full"} 
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
