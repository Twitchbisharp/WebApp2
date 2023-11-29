import { Component, OnInit } from '@angular/core';
import { IFlashcard } from './flashcard';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { FlashcardService } from "./flashcards.service";

@Component({
  selector: 'app-flashcards-component',
  templateUrl: './flashcards.component.html',
  styles: ['thead {color: black;}']
})
export class FlashcardsComponent implements OnInit {
    viewTitle: string = 'Table'
    displayImage: boolean = true;
    flashcards: IFlashcard[] = [];

  constructor(private _flashcardService: FlashcardService, private _http: HttpClient, private _router: Router) { }

    private _listFilter: string = '';
    get listFilter(): string {
      return this._listFilter;
    }
    set listFilter(value: string) {
      this._listFilter = value;
      console.log('In setter:', value)
      this.filteredFlashcards = this.performFilter(value);
    }

  getFlashcards(): void {
    this._flashcardService.getFlashcards().subscribe(data => {
        console.log('All', JSON.stringify(data));
        console.log(data);
        this.flashcards = data;
        this.filteredFlashcards = this.flashcards;
      })
    }

    deleteFlashcard(flashcard: IFlashcard): void {
      const confirmDelete = confirm(`Are you sure you want to delete "${flashcard.name}"?`);
      if (confirmDelete) {
        this._flashcardService.deleteFlashcard(flashcard.flashcardId)
          .subscribe(
            (response) => {
              if (response.success) {
                console.log(response.message);
                this.filteredFlashcards = this.filteredFlashcards.filter(i => i !== flashcard);
                // update flashcards
                this.getFlashcards();
              }
            },
            (error) => {
              console.error('Error deleting flashcard', error);
            });

      }
    }

    filteredFlashcards: IFlashcard[] = this.flashcards;

    performFilter(filterBy: string): IFlashcard[] {
      filterBy = filterBy.toLowerCase();
      console.log("Performing filter on ", this.filteredFlashcards)
      return this.flashcards.filter((flashcard: IFlashcard) =>
        flashcard.name.toLowerCase().includes(filterBy)); 
    }

    toggleImage(): void {
      this.displayImage = !this.displayImage;
    }

    navigateToFlashcardform() {
      this._router.navigate(['/flashcardform'])
    }

    ngOnInit(): void {
      console.log('FlashcardConponent created');
      this.getFlashcards();
    }
  }

