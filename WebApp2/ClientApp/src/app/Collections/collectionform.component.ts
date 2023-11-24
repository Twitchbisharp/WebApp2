import { Component } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CollectionService } from './collections.service';
import { IFlashcard } from '../Flashcards/flashcard';
import { FlashcardService } from '../Flashcards/flashcards.service';

@Component({
  selector: "app-collections-collectionform",
  templateUrl: "./collectionform.component.html"
})

export class CollectionformComponent {
  collectionForm: FormGroup;
  isEditMode: boolean = false;
  collectionId: number = -1;
  flashcards: IFlashcard[] = [];
  selected: IFlashcard[] = [];


  constructor(private _collectionService: CollectionService, private _flashcardService: FlashcardService, private _formbuilder: FormBuilder, private _router: Router, private _route: ActivatedRoute) {
    this.collectionForm = _formbuilder.group({
      collectionName: ['', Validators.required],
      collectionDate: [''],
      totalFlashcards: [''],
      flashcards: [''],
      //collectionFlashcard: [''],
      //contributerId: [''],
      //contributers: [''],
    });

    // Automatic data insertion
    this.collectionForm.patchValue({
      collectionDate: new Date().getDate() + "." + (new Date().getMonth() + 1) + "." + new Date().getFullYear(),
      totalFlashcards: this.selected.length,
      flashcards: this._flashcardService.getFlashcards().subscribe(data => {
        console.log('All', data);
        this.flashcards = data;
        console.log("selected flashcards:", this.selected);
      }),

    })
  }

  onChange(value: any) {
    console.log("OnChange value: ", value);
  }

  onSubmit() {
    console.log("CollectionCreate form submitted:");
    console.log("CollectionForm" + this.collectionForm);
    console.log("The collection " + this.collectionForm.value.collectionName + " is created.");
    console.log("Touched? " + this.collectionForm.touched);
    console.log("Selected" + this.selected)
    const newCollection = this.collectionForm.value;



    if (this.isEditMode) {
      this._collectionService.updateCollection(this.collectionId, newCollection)
        .subscribe(response => {
          if (response.success) {
            console.log(response.message);
            this._router.navigate(['/collections']);
          }
          else {
            console.log('Collection update failed');
          }
        });
    }
    else {
      this._collectionService.createCollection(newCollection)
        .subscribe(response => {
          if (response.success) {
            console.log(response.message);
            this._router.navigate(['/collections']);
          }
          else {
            console.log('Collections creation failed');
          }
        });
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
    this._collectionService.getCollectionById(this.collectionId)
      .subscribe(
        (collection: any) => {
          console.log('retrived collection: ', collection);
          this.collectionForm.patchValue({
            collectionName: collection.collectionName,
            collectionDate: collection.collectionDate,
            contributer: collection.contributer,
            totalFlashcards: collection.totalFlashcards
          });
        },
        (error: any) => {
          console.error('Error loading collection for edit:', error);
        }
      );
  }
}
