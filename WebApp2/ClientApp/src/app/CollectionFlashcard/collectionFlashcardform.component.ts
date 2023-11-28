import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { IFlashcard } from '../Flashcards/flashcard';;
import { ICollection } from '../Collections/collection';
import { ICollectionFlashcard } from './collectionFlashcard';
import { CollectionFlashcardService } from './collectionFlashcards.service';
import { FlashcardService } from '../Flashcards/flashcards.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: "app-collectionsFlashcards-collectionflashcardform",
  templateUrl: "./collectionFlashcardform.component.html"
})

export class CollectionFlashcardFormComponent implements OnInit{
  collectionFlashcardForm: FormGroup;
  collectionFlashcards: ICollectionFlashcard[] = [];
  flashcards: IFlashcard[] = [];
  collectionId: number = 0;

  constructor(
    private _flashcardService: FlashcardService,
    private _collectionFlashcardService: CollectionFlashcardService,
    private _formbuilder: FormBuilder,
    private _router: Router,
    private _route: ActivatedRoute
  ) {
    this.collectionFlashcardForm = _formbuilder.group({
      collectionFlashcards: [''],
      flahscards: [''],
      collectionId: [''],
    })


  //  // Automatic data insertion
  //  forkJoin([
  //    this._flashcardService.getFlashcards(),
  //  ]).subscribe(
  //    ([flashcards]) => {
  //      this.flashcards = flashcards;
  //      console.log("Retrieved flashcards: ", flashcards)
  //      this.collectionFlashcardForm.patchValue({
  //        flashcards: [],
  //      });
  //    },
  //    (error) => {
  //      console.error('Error fetching data:', error);
  //    }
  //  );
  }

  onSubmit() {
    console.log("Selected Flashcard: ", this.collectionFlashcardForm.value);

    const newCollectionFlashcards: ICollectionFlashcard[] = [];

    for (let selectedFlashcard of this.collectionFlashcardForm.value.selectedFlashcards) {
      const collectionFlashcard: ICollectionFlashcard = {
        flashcardId: selectedFlashcard.flashcardId,
        collectionId: this.collectionId
      };

      newCollectionFlashcards.push(collectionFlashcard);

      console.log("Created collectionFlashcard Real ", collectionFlashcard);
    }

    this._collectionFlashcardService.addCollectionFlashcard(newCollectionFlashcards);

    //this._collectionFlashcardService.getCollectionFlashcard().subscribe(
    //  (collectionFlashcards) => {
    //    this.collectionFlashcard = collectionFlashcards;
    //    console.log("Retrieved collectionFlashcards after update: ", this.collectionFlashcard);
    //  }
/*    );*/


    //console.log("Selected Flashcard: ", this.collectionForm.value.selectedFlashcards)
    //for (let i of this.collectionForm.value.selectedFlashcards) {
    //  const collectionFlashcard: ICollectionFlashcard = { flashcardId: i.flashcardId, collectionId: this.collectionId }
    //  this.collectionFlashcardForm.patchValue({
    //    flashcardId: collectionFlashcard.flashcardId,
    //    collectionId: this.collectionId,
    //  })
    //  this._collectionFlashcardService.addCollectionFlashcard(this.collectionFlashcardForm);
    //  console.log("Created collectionFlashcard Real ", collectionFlashcard)
    //}

    //this._collectionFlashcardService.getCollectionFlashcard().subscribe(
    //  (collectionFlashcard) => {
    //    this.collectionFlashcard = collectionFlashcard;
    //    console.log("Retrieved collectionFlashcards after update: ", this.collectionFlashcard)
    //  }
    //)
    

    //const newCollection = this.collectionForm.value;
    //console.log("newCollection: ", newCollection)

    //if (this.isEditMode) {
    //  console.log("sending collection: ", newCollection)
    //  this._collectionService.updateCollection(this.collectionId, newCollection)
    //    .subscribe(response => this.handleResponse(response));
    //} else {
    //  this._collectionService.createCollection(newCollection)
    //    .subscribe(response => this.handleResponse(response));
    //}
  }

  private handleResponse(response: any) {
    if (response.success) {
      console.log(response.message);
      this._router.navigate(['/collections']);
    } else {
      console.log('Collection operation failed');
    }
  }

  backToCollections() {
    this._router.navigate(['/collections']);
  }

  ngOnInit(): void {
    this._route.params.subscribe(params => {
      this.collectionId = +params['id']; // Convert to number
      this._collectionFlashcardService.getCollectionFlashcard().subscribe(cf => {
        this.collectionFlashcards = cf;
      })
      })
  }

  loadCollectionFlashcardsByCollectionId(collectionId: number) {
    this._collectionFlashcardService.getCollectionFlashcardByCollectionId(collectionId)
      .subscribe(
        (collectionFlashcard: any) => {
          console.log('retrieved collectionFlashcard: ', collectionFlashcard)
          this.collectionFlashcardForm.patchValue({
            flashcardId: collectionFlashcard.flashcardId,
            collectionId: collectionFlashcard.collectionId,
          });
        },
        (error: any) => {
          console.error('Error loading collection for edit:', error);
        }
      );
  }
}
