import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ICollectionFlashcard } from "./collectionFlashcard";

@Injectable({
  providedIn: "root"
})

export class CollectionService {
  private baseUrl = "api/collectionFlashcard/"; 

  constructor(private _http: HttpClient) { }

  getCollectionFlashcard(): Observable<ICollectionFlashcard[]> {
    return this._http.get<ICollectionFlashcard[]>(this.baseUrl);
  }
}
