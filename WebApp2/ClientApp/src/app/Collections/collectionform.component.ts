import { Component, ViewChild, ElementRef } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CollectionService } from './collections.service';
import { IFlashcard } from '../Flashcards/flashcard';;
import { ICollection } from './collection';
import { ICollectionFlashcard } from '../CollectionFlashcard/collectionFlashcard';
import { CollectionFlashcardService } from '../CollectionFlashcard/collectionFlashcards.service';
import { FlashcardService } from '../Flashcards/flashcards.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: "app-collections-collectionform",
  templateUrl: "./collectionform.component.html"
})

export class CollectionformComponent {
  collectionForm: FormGroup;
  isEditMode: boolean = false;
  collectionId: number = -1;
  flashcards: IFlashcard[] = [];
  originalCollection: ICollection[] = [];
  collectionFlashcard: ICollectionFlashcard[] = [];

  dropdownOptions: IFlashcard[] = this.flashcards;
  selectedFlashcards: IFlashcard[] = [];

  

  constructor(
    private _collectionService: CollectionService,
    private _flashcardService: FlashcardService,
    private _collectionFlashcardService: CollectionFlashcardService,
    private _formbuilder: FormBuilder,
    private _router: Router,
    private _route: ActivatedRoute
  ) {
    this.collectionForm = _formbuilder.group({
      collectionId: [''],
      collectionDate: new Date().getDate() + "." + (new Date().getMonth() + 1) + "." + new Date().getFullYear(),
      collectionName: [''],
      collectionFlashcard: [''],
      totalFlashcards: [''],
      contributerId: [''],  
      contributers: [''],
      flashcards: [[]],
      selectedFlashcards: [''],
    });



    // Automatic data insertion
    forkJoin([
      this._flashcardService.getFlashcards(),
    ]).subscribe(
      ([flashcards]) => {
        this.flashcards = flashcards;
        console.log("Retrieved flashcards: ", flashcards)
        this.collectionForm.patchValue({
          /*collectionDate: new Date().getDate() + "." + (new Date().getMonth() + 1) + "." + new Date().getFullYear(),*/
          flashcards: [],
        });
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

  onSubmit() {
    console.log("Selected Flashcard: ", this.collectionForm.value.selectedFlashcards, this.flashcards, this.collectionFlashcard, this.collectionForm.value.flashcards)
    for (let i of this.collectionFlashcard) {
      this._collectionFlashcardService.addCollectionFlashcard(i)
      console.log("Created collectionflashcard", i)
    }


    const newCollection = this.collectionForm.value;
    console.log("newCollection: ", newCollection)

    if (this.isEditMode) {
      console.log("sending collection: ", newCollection)
      this._collectionService.updateCollection(this.collectionId, newCollection)
        .subscribe(response => this.handleResponse(response));
    } else {
      this._collectionService.createCollection(newCollection)
        .subscribe(response => this.handleResponse(response));
    }
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
      if (params['mode'] === 'create') {
        this.isEditMode = false; // Create mode
      } else if (params['mode'] === 'edit') {
        this.isEditMode = true; // Edit mode
        this.collectionId = +params['id']; // Convert to number
        this.loadCollectionForEdit(this.collectionId);
      }
    });
  }

  loadCollectionForEdit(collectionId: number) {
    this._collectionService.getCollectionById(collectionId)
      .subscribe(
        (collection: any) => {
          this.originalCollection = collection;
          console.log('retrieved collection: ', collection)
          this.collectionForm.patchValue({
            collectionName: collection.collectionName,
            collectionFlashcard: collection.collectionFlashcard, 
            collectionDate: collection.collectionDate,
            totalFlashcards: collection.totalFlashcards,
            contributerId: collection.contributerId,
            contributers: collection.contributers,
          });
        },
        (error: any) => {
          console.error('Error loading collection for edit:', error);
        }
      );
  }
}
