import { Component } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { FlashcardService } from './flashcards.service';

@Component({
  selector: "app-flashcards-flashcardform",
  templateUrl: "./flashcardform.component.html"
})

export class FlashcardformComponent {
  flashcardForm: FormGroup;
  isEditMode: boolean = false;
  flashcardId: number = -1;

  constructor(private _flashcardService: FlashcardService, private _formbuilder: FormBuilder, private _router: Router, private _route: ActivatedRoute) {
    this.flashcardForm = _formbuilder.group({
      name: ['', Validators.required],
      description: [''],
      imageUrl: ['']
    });
  }

  onSubmit() {
    console.log("FlashcardCreate form submitted:");
    console.log(this.flashcardForm);
    console.log("The flaschard " + this.flashcardForm.value + " is created.");
    console.log(this.flashcardForm.touched);
    const newFlashcard = this.flashcardForm.value;

    if (this.isEditMode) {
      this._flashcardService.updateFlashcard(this.flashcardId, newFlashcard)
        .subscribe(response => {
          if (response.success) {
            console.log(response.message);
            this._router.navigate(['/flashcards']);
          }
          else {
            console.log('Flashcard update failed');
          }
        });
    }
    else {
      this._flashcardService.createFlashcard(newFlashcard)
        .subscribe(response => {
          if (response.success) {
            console.log(response.message);
            this._router.navigate(['/flashcards']);
          }
          else {
            console.log('Flashcards creation failed');
          }
        });
    }
  }

  backToFlashcards() {
    this._router.navigate(['/flashcards']);
  }

  ngOnInit(): void {
    this._route.params.subscribe(params => {
      if (params['mode'] === 'create') {
        this.isEditMode = false; // Create mode
      } else if (params['mode'] === 'edit') {
        this.isEditMode = true; // Edit mode
        this.flashcardId = +params['id']; // Convert to number
        this.loadFlashcardForEdit(this.flashcardId);
      }
    });
  }

  loadFlashcardForEdit(flashcardId: number) {
    this._flashcardService.getFlashcardById(this.flashcardId)
      .subscribe(
        (flashcard: any) => {
          console.log('retrived flashcard: ', flashcard);
          this.flashcardForm.patchValue({
            name: flashcard.name,
            description: flashcard.description,
            imageUrl: flashcard.imageUrl
          });
        },
        (error: any) => {
          console.error('Error loading flashcard for edit:', error);
        }
      );
  }
}
