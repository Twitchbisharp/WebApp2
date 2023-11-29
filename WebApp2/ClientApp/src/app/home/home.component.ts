import { Component, OnInit } from '@angular/core';
import { CollectionService } from "../Collections/collections.service";
import { ICollection } from '../Collections/collection';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['../../styles.css']
})
export class HomeComponent implements OnInit {
  collections: ICollection[] = [];
  images: string[] = [
    'assets/images/Florida.png',
    'assets/images/Ohio.png',
    'assets/images/Colorado.png',
  ];




  constructor(private _collectionService: CollectionService, private _http: HttpClient, private _router: Router) { }




  getCollections(): void {
    this._collectionService.getCollections().subscribe((data: ICollection[]) => {
      console.log('All', JSON.stringify(data));
      console.log()
      this.collections = data;
    })
  }

  navigateToPlay(collectionId: number): void {
    this._router.navigate(['/play/', collectionId]);
    console.log("Navigated to collectionFlashcard")
  }

  ngOnInit(): void {
    console.log('CollectionConponent created');
    this.getCollections();

  }
}
