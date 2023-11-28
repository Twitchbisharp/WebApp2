import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ICollectionFlashcard } from "./collectionFlashcard";

@Injectable({
  providedIn: "root"
})

export class CollectionFlashcardService {
  private baseUrl = "api/collectionFlashcard/"; 

  constructor(private _http: HttpClient) { }

  getCollectionFlashcard(): Observable<ICollectionFlashcard[]> {
    console.log("Requesting collectionflashcard GetAll() on url: ", this.baseUrl)
    return this._http.get<ICollectionFlashcard[]>(this.baseUrl);
  }
  getCollectionFlashcardByCollectionId(collectionId: number): Observable<ICollectionFlashcard[]> {
    const createUrl = `${this.baseUrl}/${collectionId}`
    return this._http.get<ICollectionFlashcard[]>(createUrl);
  }

  addCollectionFlashcard(newCollectionFlashcard: any): Observable<any> {
    const createUrl = "api/collectionFlashcard/create";
    return this._http.post<any>(createUrl, newCollectionFlashcard);
  }
}
