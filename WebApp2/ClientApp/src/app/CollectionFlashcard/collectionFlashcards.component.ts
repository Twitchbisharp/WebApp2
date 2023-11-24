import { Component, OnInit } from '@angular/core';
import { ICollectionFlashcard } from './collectionFlashcard';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { CollectionFlashcardService } from "./collectionFlashcards.service";

@Component({
  selector: 'app-collectionFlashcards-component',
  templateUrl: './collectionFlashcards.component.html',
  styles: ['thead {color: blue;}']
})
  export class CollectionFlashcardComponent implements OnInit {
    viewTitle: string = 'Table'
    displayImage: boolean = true;
    collectionFlashcards: ICollectionFlashcard[] = [];

  constructor(private _collectionFlashcardService: CollectionFlashcardService, private _http: HttpClient, private _router: Router) { }

    private _listFilter: string = '';
    get listFilter(): string {
      return this._listFilter;
    }
    set listFilter(value: string) {
      this._listFilter = value;
      console.log('In setter:', value)
      this.filteredCollectionFlashcards = this.performFilter(value);
    }

  getCollections(): void {
    this._collectionFlashcardService.getCollectionFlashcard().subscribe(data => {
      console.log('All', JSON.stringify(data));
      console.log(data)
      this.collectionFlashcards = data;
      this.filteredCollectionFlashcards = this.collectionFlashcards;
      })
    }

  //  deleteCollection(collection: ICollectionFlashcard): void {
  //    const confirmDelete = confirm(`Are you sure you want to delete "${collection.collectionName}"?`);
  //    if (confirmDelete) {
  //      this._collectionService.deleteCollection(collection.collectionId)
  //        .subscribe(
  //          (response) => {
  //            if (response.success) {
  //              console.log(response.message);
  //              this.filteredCollections = this.filteredCollections.filter(i => i !== collection);
  //              // Update collections
  //              this.getCollections();
  //            }
  //          },
  //          (error) => {
  //            console.error('Error deleting collection', error);
  //          });

  //    }
  //}
  filteredCollectionFlashcards: ICollectionFlashcard[] = this.collectionFlashcards;

  performFilter(filterBy: string): ICollectionFlashcard[] {
    filterBy = filterBy.toLowerCase();
    console.log("Performing filter on ", this.filteredCollectionFlashcards)
    return this.collectionFlashcards.filter((collectionFlashcards: ICollectionFlashcard) =>
      collectionFlashcards.flashcard.name.toLowerCase().includes(filterBy));
  }

  toggleImage(): void {
    this.displayImage = !this.displayImage;
  }

  navigateToCollectionform() {
    this._router.navigate(['/collectionform'])
  }

  ngOnInit(): void {
    console.log('CollectionConponent created');
    this.getCollections();
  }

}
