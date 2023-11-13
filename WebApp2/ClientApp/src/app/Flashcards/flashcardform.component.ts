import { Component } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
  selector: "app-flashcards-flashcardform",
  templateUrl: "./flashcardform.component.html"
})

export class FlashcardformComponent {
  flashcardForm: FormGroup;

  constructor(private _formbuilder: FormBuilder, private _router: Router) {
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
    console.log("The flaschard " + this.flashcardForm.value.name + " is created.");
    console.log(this.flashcardForm.touched);
  }

  backToFlashcards() {
    this._router.navigate(['/flashcards']);
  }
}
