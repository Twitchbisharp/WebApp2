import { Component } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http'

@Component({
  selector: "app-flashcards-flashcardform",
  templateUrl: "./flashcardform.component.html"
})

export class FlashcardformComponent {
  flashcardForm: FormGroup;

  constructor(private _formbuilder: FormBuilder, private _router: Router, private _http: HttpClient) {
    this.flashcardForm = _formbuilder.group({
      name: ['', Validators.required],
      price: [0, Validators.required],
      description: [''],
      imageUrl: ['']
    });
  }

  onSubmit() {
    console.log("FlashcardCreate form submitted:");
    console.log(this.flashcardForm);
    const newFlashcard = this.flashcardForm.value;
    const createUrl = "api/flashcard/create"
    this._http.post<any>(createUrl, newFlashcard).subscribe(response => {
      if (response.success) {
        console.log(response.message);
        this._router.navigate(['/flashcard']);
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
