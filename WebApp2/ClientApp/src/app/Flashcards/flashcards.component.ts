import { Component } from '@angular/core';

@Component({
  selector: 'app-flashcards-component',
  templateUrl: './flashcards.component.html',
})
export class FlashcardsComponent {
  viewTitle: string = 'Table'
  displayImage: boolean = true;
  flashcards: any[] = [
    {
      "FlashcardId": 1,
      "Name": "Hus",
      "Description": "House",
      "ImageUrl": "assets/images/test.jpg"
    },
    {
      "FlashcardId": 2,
      "Name": "Bil",
      "Description": "Car",
      "ImageUrl": "assets/images/random.jpg" //Missing image icon shows when an image is linked with no matching image
    }
  ];

  toggleImage(): void {
    this.displayImage = !this.displayImage;
  }

}
