import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { IFlashcard } from "../Flashcards/flashcard";
import { ICollectionFlashcard } from "../CollectionFlashcard/collectionFlashcard";

@Injectable({
  providedIn: "root"
})
export class FlashcardService {
  private baseUrl = "api/flashcard";

  constructor(private http: HttpClient) { }

  getFlashcards(): Observable<IFlashcard[]> {
    return this.http.get<IFlashcard[]>(this.baseUrl);
  }
}
