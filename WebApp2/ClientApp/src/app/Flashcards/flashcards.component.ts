import { Component } from '@angular/core';
import { IFlashcard } from './flashcard';

@Component({
  selector: 'app-flashcards-component',
  templateUrl: './flashcards.component.html',
  styles: ['thead {color: blue;}']
})
export class FlashcardsComponent {
  viewTitle: string = 'Table'
  displayImage: boolean = true;
  // listFilter: string = '';

  private _listFilter: string = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    console.log('In setter:', value)
    this.filteredFlashcards = this.performFilter(value);
  }


  flashcards: IFlashcard[] = [
    {
      "FlashcardId": 1,
      "Name": "Hus",
      "Price":150,
      "Description": "House",
      "ImageUrl": "assets/images/test.jpg"
    },
    {
      "FlashcardId": 2,
      "Name": "Bil",
      "Price": 20,
      "Description": "Car",
      "ImageUrl": "assets/images/test.jpg"
     //Missing image icon shows when an image is linked with no matching image
    }
  ];
  filteredFlashcards: IFlashcard[] = this.flashcards;

  performFilter(filterBy: string): IFlashcard[] {
    filterBy = filterBy.toLowerCase();
    return this.flashcards.filter((flashcards: IFlashcard) =>
      flashcards.Name.toLowerCase().includes(filterBy));
  }

  toggleImage(): void {
    this.displayImage = !this.displayImage;
  }

  ngOnInit(): void {
    console.log('ItemsConponent created');
  }


}
