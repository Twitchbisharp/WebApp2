import { Component } from '@angular/core';
import { IFlashcard } from './flashcard';
import { Router } from "@angular/router";
import { FlashcardService } from "./flashcards.service";

@Component({
  selector: 'app-flashcards-component',
  templateUrl: './flashcards.component.html',
  styles: ['thead {color: blue;}']
})
export class FlashcardsComponent {
  viewTitle: string = 'Table'
  displayImage: boolean = true;
  // listFilter: string = '';
  flashcards: IFlashcard[] = [];

  constructor(private _flashcardService: FlashcardService, private _router: Router) { }

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
      this.flashcards = data;
      this.filteredFlashcards = this.flashcards;
    })
  }

  filteredFlashcards: IFlashcard[] = this.flashcards;

  performFilter(filterBy: string): IFlashcard[] {
    filterBy = filterBy.toLowerCase();
    return this.flashcards.filter((flashcards: IFlashcard) =>
      flashcards.Name.toLowerCase().includes(filterBy));
  }

  toggleImage(): void {
    this.displayImage = !this.displayImage;
  }

  navigateToFlashcardform() {
    this._router.navigate(['/flashcardform'])
  }

  ngOnInit(): void {
    console.log('FlashcardsConponent created');
  }


}
