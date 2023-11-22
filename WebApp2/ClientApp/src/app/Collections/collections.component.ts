import { Component, OnInit } from '@angular/core';
import { ICollection } from './collection';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { CollectionService } from "./collections.service";

@Component({
  selector: 'app-collections-component',
  templateUrl: './collections.component.html',
  styles: ['thead {color: blue;}']
})
  export class CollectionsComponent implements OnInit {
    viewTitle: string = 'Table'
    displayImage: boolean = true;
    collections: ICollection[] = [];

  constructor(private _collectionService: CollectionService, private _http: HttpClient, private _router: Router) { }

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

  ngOnInit(): void {
    console.log('CollectionConponent created');
    this.getCollections();
  }

}
