///////////////////////////////////////////////////////////////////// play.component.ts
import { Component, Input, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ActivatedRoute } from "@angular/router";
import { RouterModule } from '@angular/router';
import { FlashcardService } from '../Flashcards/flashcards.service';
import { CollectionFlashcardService } from "../CollectionFlashcard/collectionFlashcards.service";
import { ICollectionFlashcard } from "../CollectionFlashcard/collectionFlashcard";


@Component({
  selector: 'play',
  templateUrl: './play.component.html',
})
export class PlayComponent implements OnInit {
  @Input() flashcards: any[] = [];
  currentIndex: number = 0;
  collectionId: number = 0;
  collectionFlashcards: ICollectionFlashcard[] = [];

  constructor(private flashcardService: FlashcardService, private _collectionFlashcardService: CollectionFlashcardService, private _route: ActivatedRoute) { }

  ngOnInit(): void
  {
    this.loadFlashcards();
    console.log("here is the flashcards after load", this.flashcards);
  }

  loadFlashcards(): void {
    this._route.params.subscribe(params => {
      this.collectionId = params['id']
      this._collectionFlashcardService.getCollectionFlashcard().subscribe(collectionFlashcards => {
        console.log("", collectionFlashcards[0].collectionId)
        for (let cf of collectionFlashcards) {
          if (cf.collectionId == this.collectionId) {
            this.collectionFlashcards.push(cf);
          }
        }
      });
    });

  }

  showPreviousFlashcard(): void {
    if (this.currentIndex > 0) {
      this.currentIndex--;
    }
  }

  showNextFlashcard(): void {
    if (this.currentIndex < this.collectionFlashcards.length - 1) {
      this.currentIndex++;
    }
  }


  //flip(index: number): void {
  //  const content = document.getElementById('term' + index);

  //  if (this.flashcards[index] && this.flashcards[index].flashcard) {
  //    const flashcard = this.flashcards[index].flashcard;
  //    const name = flashcard.name;
  //    const description = flashcard.description;
  //    const imageUrl = flashcard.imageUrl;

  //    console.log('Name:', name);
  //    console.log('Description:', description);
  //    console.log('Image URL:', imageUrl);

  //    if (content) {
  //      if (content.innerHTML === description) {
  //        if (imageUrl) {
  //          content.innerHTML = name + '<br><img src="' + imageUrl + '" alt="Flashcard Image" class="img-fluid">';
  //        } else {
  //          content.innerHTML = name;
  //        }
  //      } else {
  //        content.innerHTML = description;
  //      }
  //    } else {
  //      console.error("Content for index " + index + " not found.");
  //    }
  //  } else {
  //    console.error("Flashcard[" + index + "] or flashcard not found.");
  //  }
  //}

}

