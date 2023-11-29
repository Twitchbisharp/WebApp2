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

  dynamicProperties: { showBack: boolean }[] = [];

  ngOnInit(): void {
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
            const dynamicProperty = { showBack: false };
            this.dynamicProperties.push(dynamicProperty);

            // Merging dynamic properties into collectionFlashcard
            cf = { ...cf, ...dynamicProperty };

            this.collectionFlashcards.push(cf);
          }
        }
      });
    });
  }

  showPreviousFlashcard(): void {
    if (this.currentIndex > 0) {
      this.currentIndex--;
      this.resetCardSide();
    }
  }

  showNextFlashcard(): void {
    if (this.currentIndex < this.collectionFlashcards.length - 1) {
      this.currentIndex++;
      this.resetCardSide();
    }
  }

  flipCard(): void {
    this.dynamicProperties[this.currentIndex].showBack = !this.dynamicProperties[this.currentIndex].showBack;
  }

  resetCardSide(): void {
    this.dynamicProperties.forEach(dp => dp.showBack = false);
  }

}

