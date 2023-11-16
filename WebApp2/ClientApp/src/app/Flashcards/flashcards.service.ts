import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { IFlashcard } from "./flashcard";

@Injectable({
  providedIn: "root"
})

export class FlashcardService {
  private baseUrl = "api/flashcard/"; // maybe typo with Flashcard/flashcard

  constructor(private _http: HttpClient) { }

  getFlashcards(): Observable<IFlashcard[]> {
    return this._http.get<IFlashcard[]>(this.baseUrl);
  }

  createFlashcard(newFlashcard: IFlashcard): Observable<any> {
    const createUrl = "api/flashcard/create";
    return this._http.post<any>(createUrl, newFlashcard);
  }

  getFlashcardById(flashcardId: number): Observable<any> {
    const url = `${this.baseUrl}/${flashcardId}`;
    return this._http.get(url)
  }
 
  updateFlashcard(flashcardId: number, newFlashcard: any): Observable<any> {
    const url = `${this.baseUrl}/update/${flashcardId}`;
    newFlashcard.flashcardId = flashcardId;
    return this._http.put<any>(url, newFlashcard);
  }

  deleteFlashcard(flashcardId: number): Observable<any> {
    const url = `${this.baseUrl}/delete/${flashcardId}`;
    return this._http.delete(url);
  }
}
