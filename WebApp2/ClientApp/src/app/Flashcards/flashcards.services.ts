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
}
