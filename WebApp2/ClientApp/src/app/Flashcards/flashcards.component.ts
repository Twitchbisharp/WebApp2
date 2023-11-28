import { Component } from '@angular/core';
import { IFlashcard } from './flashcard';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { FlashcardService } from "./flashcards.service";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-flashcards-component',
  templateUrl: './flashcards.component.html',
  styles: ['thead {color: blue;}']
})
export class FlashcardsComponent {
  viewTitle: string = 'Table'
  displayImage: boolean = true;
  flashcards: IFlashcard[] = [];
  flashcardForm: FormGroup; 

  constructor(private _flashcardService: FlashcardService, private _http: HttpClient, private _router: Router, private fb: FormBuilder) {
    this.flashcardForm = this.fb.group({
      name: ["", [
        Validators.required,
        Validators.pattern(/^[0-9a-zA-ZæøåÆØÅ. -]{2,15}$/)
      ]],
      description: ["", [
        Validators.required,
        Validators.maxLength(120),
        Validators.pattern(/^[0-9a-zA-ZæøåÆØÅ. -]{2,15}$/)
      ]],
      deckId: null
    });
    this.flashcardForm.get('name')?.setErrors({ 'incorrect': true, 'message': "The name must be letters between 1 and 20 characters" })
    this.flashcardForm.get('description')?.setErrors({ 'incorrect': true, 'message': "The description must be letters between 1 and 20 characters" })
  
  }

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

    deleteFlashcard(flashcard: IFlashcard): void {
      const confirmDelete = confirm(`Are you sure you want to delete "${flashcard.Name}"?`);
      if (confirmDelete) {
        this._flashcardService.deleteFlashcard(flashcard.FlashcardId)
          .subscribe(
            (response) => {
              if (response.success) {
                console.log(response.message);
                this.filteredFlashcards = this.filteredFlashcards.filter(i => i !== flashcard);
              }
            },
            (error) => {
              console.error('Error deleting flashcard', error);
            });

      }
  }
  /*
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
  ];*/
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
    console.log('ItemsConponent created');
    this.getFlashcards();
  }

}
