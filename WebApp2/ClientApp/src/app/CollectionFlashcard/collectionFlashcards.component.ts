import { Component, OnInit } from '@angular/core';
import { ICollectionFlashcard } from './collectionFlashcard';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from "@angular/router";
import { CollectionFlashcardService } from "./collectionFlashcards.service";
import { ICollection } from "../Collections/collection";
import { CollectionService } from "../Collections/collections.service"

@Component({
  selector: 'app-collectionFlashcards-component',
  templateUrl: './collectionFlashcards.component.html',
  styles: ['thead {color: blue;}']
})
  export class CollectionFlashcardComponent implements OnInit {
    viewTitle: string = 'Table'
    displayImage: boolean = true;
    collectionFlashcards: ICollectionFlashcard[] = [];
    collectionId: number = -1;
    collections: ICollection[] = [];

  constructor(private _collectionFlashcardService: CollectionFlashcardService, private _collectionService: CollectionService, private _http: HttpClient, private _router: Router, private _route: ActivatedRoute) { }

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
    
    this.loadFlashcards()
    console.log('Collectionflascards loaded: ', this.collectionFlashcards);
  }
  loadFlashcards(): void {
    this._route.params.subscribe(params => {
      this.collectionId = params['id']
      this._collectionService.getCollectionById(this.collectionId).subscribe(collection => { this.collections.push(collection); console.log(this.collections); })
      this._collectionFlashcardService.getCollectionFlashcard().subscribe(collectionFlashcards => {
        console.log("", collectionFlashcards[0].collectionId)
        for (let cf of collectionFlashcards) {
          if (cf.collectionId == this.collectionId) {
            this.collectionFlashcards.push(cf);
          }
        }
        this.filteredCollectionFlashcards = this.collectionFlashcards;
        
      });
    });
  }
}
