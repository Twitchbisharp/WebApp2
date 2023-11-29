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
  selectedFlashcardForm: FormGroup;
  collectionFlashcards: ICollectionFlashcard[] = [];
  flashcards: IFlashcard[] = [];
  collectionId: number = 0;
  dummyCollection: ICollection[] = [];
  dummyFlashcards: IFlashcard[] = [];

  constructor(
    private _flashcardService: FlashcardService,
    private _collectionFlashcardService: CollectionFlashcardService,
    private _formbuilder: FormBuilder,
    private _router: Router,
    private _route: ActivatedRoute
  ) {
    this.collectionFlashcardForm = _formbuilder.group({
      flashcards: [''],

    })
    this.selectedFlashcardForm = _formbuilder.group({
      collection: this.dummyCollection,
      collectionId: this.collectionId,
      flashcard: this.dummyFlashcards,
      flashcardId: [0],
    })


    /*
    Using forkJoin to combine multiple observable streams into a single stream
    In this case, it's used to make multiple HTTP requests concurrently
    */
    forkJoin([
      this._flashcardService.getFlashcards(),
    ]).subscribe(
      ([flashcards]) => {
        this.flashcards = flashcards;

        console.log("Retrieved flashcards: ", flashcards);

        // Setting its value to an empty array with patch
        this.collectionFlashcardForm.patchValue({
          flashcards: [],
        });
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );

  }

  onSubmit() {
    console.log("Selected Flashcard: ", this.collectionFlashcardForm.value);


    for (let selectedFlashcard of this.collectionFlashcardForm.value.flashcards) {
      this.selectedFlashcardForm.patchValue({
        flashcardId: selectedFlashcard.flashcardId,
        collectionId: this.collectionId,
      })
      this._collectionFlashcardService.addCollectionFlashcard(this.selectedFlashcardForm.value)
        .subscribe(response => {
          this.handleResponse(response)
        });
      console.log("Created collectionFlashcard ", this.selectedFlashcardForm.value);
      };
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
