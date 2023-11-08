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
      "ImageUrl": "assets/images/random.jpg" //Missing image icon shows when an image is linked with no matching image
    }
  ];

  toggleImage(): void {
    this.displayImage = !this.displayImage;
  }

}
