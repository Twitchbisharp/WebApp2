import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ICollection } from "./collection";

@Injectable({
  providedIn: "root"
})

export class CollectionService {
  private baseUrl = "api/collection/"; 

  constructor(private _http: HttpClient) { }

  getCollections(): Observable<ICollection[]> {
    return this._http.get<ICollection[]>(this.baseUrl);
  }
  
  createCollection(newCollection: ICollection): Observable<any> {
    console.log("Inside Createcollection with object: ", newCollection)
    const createUrl = "api/collection/create";
    return this._http.post<any>(createUrl, newCollection);
  }  
 

  getCollectionById(collectionId: number): Observable<any> {
    const url = `${this.baseUrl}/${collectionId}`;
    return this._http.get(url)
  }
 
  updateCollection(collectionId: number, newCollection: any): Observable<any> {
    const url = `${this.baseUrl}update/${collectionId}`;

    console.log("url: ", url) // is this initialized? no
    console.log("new collection: ", newCollection)
    newCollection.collectionId = collectionId;
    return this._http.put<any>(url, newCollection);
  }

  toCollectionFlashcardId(collectionId: number) {
    const url = `api/collectionFlashcard/${collectionId}`
    return this._http.get(url);
  }

  deleteCollection(collectionId: number): Observable<any> {
    const url = `${this.baseUrl}/delete/${collectionId}`;
    return this._http.delete(url);
  }
}
