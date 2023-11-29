import { Component, OnInit } from '@angular/core';
import { ICollection } from './collection';
import { IContributer } from "../Contributers/contributer";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { CollectionService } from "./collections.service";
import { ContributerService } from "../Contributers/contributers.service";
import { CollectionFlashcardService } from "../CollectionFlashcard/collectionFlashcards.service";


@Component({
  selector: 'app-collections-component',
  templateUrl: './collections.component.html',
  styles: ['thead {color: blue;}']
})
  export class CollectionsComponent implements OnInit {
    viewTitle: string = 'Table';
    displayImage: boolean = true;
    collections: ICollection[] = [];
    contributers: IContributer[] = [];

  constructor(private _collectionService: CollectionService, private _collectionFlashcardService: CollectionFlashcardService, private _contributerService: ContributerService, private _http: HttpClient, private _router: Router) { }

    private _listFilter: string = '';
    get listFilter(): string {
      return this._listFilter;
    }
    set listFilter(value: string) {
      this._listFilter = value;
      console.log('In setter:', value)
      this.filteredCollections = this.performFilter(value);
    }

  getCollections(): void {
    this._collectionService.getCollections().subscribe(data => {
      console.log('All', JSON.stringify(data));
      console.log()
      this.collections = data;
      this.filteredCollections = this.collections;
    })
    this._contributerService.getContributers().subscribe(contributer => {
      this.contributers = contributer;
    })
    }

    deleteCollection(collection: ICollection): void {
      const confirmDelete = confirm(`Are you sure you want to delete "${collection.collectionName}"?`);
      if (confirmDelete) {
        this._collectionService.deleteCollection(collection.collectionId)
          .subscribe(
            (response) => {
              if (response.success) {
                console.log(response.message);
                this.filteredCollections = this.filteredCollections.filter(i => i !== collection);
                // Update collections
                this.getCollections();
              }
            },
            (error) => {
              console.error('Error deleting collection', error);
            });

     }  
  }
  filteredCollections: ICollection[] = this.collections;

  performFilter(filterBy: string): ICollection[] {
    filterBy = filterBy.toLowerCase();
    console.log("Performing filter on ", this.filteredCollections)
    return this.collections.filter((collections: ICollection) =>
      collections.collectionName.toLowerCase().includes(filterBy));
  }

  toggleImage(): void {
    this.displayImage = !this.displayImage;
  }

  navigateToCollectionform() {
    this._router.navigate(['/collectionform'])
  }

  navigateToCollectionFlashcard(collectionId: number): void {
    this._router.navigate(['/collectionFlashcard/', collectionId]);
      console.log("Navigated to collectionFlashcard")
  }

  ngOnInit(): void {
    console.log('CollectionComponent created');
    this.getCollections();
    
  }
}
