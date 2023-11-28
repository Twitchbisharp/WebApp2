import { Component } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CollectionService } from './collections.service';
import { ICollectionFlashcard } from "../CollectionFlashcard/collectionFlashcard";
import { ICollection } from "./collection";
import { IContributer } from "../Contributers/contributer";

@Component({
  selector: "app-collections-collectionform",
  templateUrl: "./collectionform.component.html"
})

export class CollectionformComponent {
  collectionForm: FormGroup;
  isEditMode: boolean = false;
  collectionId: number = -1;
  newCollection: ICollection[] = [];
  collectionFlashcard: ICollectionFlashcard[] = [];
  contributers: IContributer[] = [];

  constructor(private _collectionService: CollectionService, private _formbuilder: FormBuilder, private _router: Router, private _route: ActivatedRoute) {
    this.collectionForm = _formbuilder.group({
      collectionDate: [''],
      collectionId: [''],
      collectionName: ['', Validators.required],
/*      collectionFlashcard: [''],*/
      totalFlashcards: [0],
      contributerId: [''],
/*      contributers: [''],*/
    });
  }

  onSubmit() {
    console.log("CollectionCreate form submitted:");
    console.log(this.collectionForm);
    console.log("The collection " + this.collectionForm.value.collectionName + " is created.");
    console.log(this.collectionForm.touched);
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
    this._collectionService.getCollectionById(collectionId)
      .subscribe(
        (collection: any) => {
          console.log('retrived collection: ', collection);
          this.collectionForm.patchValue({
            collectionName: collection.collectionName,
            collectionDate: new Date().getDate().toString() + "." + (new Date().getMonth() + 1).toString() + "." + new Date().getFullYear(), 
/*            collectionFlashcard: collection.collectionFlashcard,*/
            totalFlashcards: collection.totalFlashcard,
            contributerId: collection.contributerId,
/*            contributers: collection.contributers,*/
          });
        },
        (error: any) => {
          console.error('Error loading collection for edit:', error);
        }
      );
  }
}
