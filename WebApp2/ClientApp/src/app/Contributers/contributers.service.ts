import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { IContributer } from "./contributer";

@Injectable({
  providedIn: "root"
})

export class ContributerService {
  private baseUrl = "api/contributer/"; 

  constructor(private _http: HttpClient) { }

  getContributers(): Observable<IContributer[]> {
    return this._http.get<IContributer[]>(this.baseUrl);
  }

  createContributer(newContributer: IContributer): Observable<any> {
    const createUrl = "api/contributer/create";
    return this._http.post<any>(createUrl, newContributer);
  }

  getContributerById(contributerId: number): Observable<any> {
    const url = `${this.baseUrl}/${contributerId}`;
    return this._http.get(url)
  }
 
  updateContributer(contributerId: number, newContributer: any): Observable<any> {
    const url = `${this.baseUrl}update/${contributerId}`;
    newContributer.contributerId = contributerId;
    return this._http.put<any>(url, newContributer);
  }

  deleteContributer(contributerId: number): Observable<any> {
    const url = `${this.baseUrl}/delete/${contributerId}`;
    return this._http.delete(url);
  }
}
