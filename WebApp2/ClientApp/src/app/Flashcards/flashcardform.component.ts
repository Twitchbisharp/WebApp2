import { Component } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { Router } from "@angular/router";
import { FlashcardService } from "./flashcards.service";

@Component({
  selector: "app-flashcards-flashcardform",
  templateUrl: "./flashcardform.component.html"
})

export class FlashcardformComponent {
  flashcardForm: FormGroup;

  constructor(private _formbuilder: FormBuilder, private _router: Router, private _flashcardService: FlashcardService) {
    this.flashcardForm = _formbuilder.group({
      name: ['', Validators.required],
      description: [''],
      imageUrl: ['']
    });
  }

  onSubmit() {
    console.log("FlashcardCreate form submitted:");
    console.log(this.flashcardForm);
    const newFlashcard = this.flashcardForm.value;
    const createUrl = "api/flashcard/create"
    this._flashcardService.createFlashcard(newFlashcard).subscribe(response => {
      if (response.success) {
        console.log(response.message);
        this._router.navigate(['/flashcards']);
      }
      else {
        console.log('Flashcard creation failed')
      }
    })
    //console.log("The flaschard " + this.flashcardForm.value.name + " is created.");
    //console.log(this.flashcardForm.touched);
  }

  backToFlashcards() {
    this._router.navigate(['/flashcards']);
  }
}
