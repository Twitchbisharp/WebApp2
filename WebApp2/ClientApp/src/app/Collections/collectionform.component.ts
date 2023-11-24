import { Component } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CollectionService } from './collections.service';
import { IFlashcard } from '../Flashcards/flashcard';
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

  constructor(
    private _collectionService: CollectionService,
    private _flashcardService: FlashcardService,
    private _formbuilder: FormBuilder,
    private _router: Router,
    private _route: ActivatedRoute
  ) {
    this.collectionForm = _formbuilder.group({
      collectionName: ['', Validators.required],
      flashcards: [[]],
    });

    // Automatic data insertion
    forkJoin([
      this._flashcardService.getFlashcards(),
    ]).subscribe(
      ([flashcards]) => {
        this.flashcards = flashcards;
        this.collectionForm.patchValue({
          collectionDate: new Date().getDate() + "." + (new Date().getMonth() + 1) + "." + new Date().getFullYear(),
          flashcards: [],
        });
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

  onSubmit() {
    console.log("CollectionCreate form submitted:");
    console.log("The collection " + this.collectionForm.value.collectionName + " is created.");
    console.log("Touched? " + this.collectionForm.touched);
    console.log("Selected", this.collectionForm.value.flashcards);

    const newCollection = this.collectionForm.value;

    if (this.isEditMode) {
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
          console.log('retrieved collection: ', collection);
          this.collectionForm.patchValue({
            collectionName: collection.collectionName,
            flashcards: collection.flashcards, // Assuming 'flashcards' is the property name in your collection model
          });
        },
        (error: any) => {
          console.error('Error loading collection for edit:', error);
        }
      );
  }
}
