import { Component, OnInit } from '@angular/core';
import { IContributer } from './contributer';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { ContributerService } from "./contributers.service"; 

@Component({
  selector: 'app-contributers-component',
  templateUrl: './contributers.component.html',
  styles: ['thead {color: blue;}']
})
  export class ContributersComponent implements OnInit {
    viewTitle: string = 'Table'
    displayImage: boolean = true;
    contributers: IContributer[] = [];

  constructor(private _contributerService: ContributerService, private _http: HttpClient, private _router: Router) { }

    private _listFilter: string = '';
    get listFilter(): string {
      return this._listFilter;
    }
    set listFilter(value: string) {
      this._listFilter = value;
      console.log('In setter:', value)
      this.filteredContributers = this.performFilter(value);
    }

  getContributers(): void {
    this._contributerService.getContributers().subscribe(data => {
      console.log('All', JSON.stringify(data));
      console.log()
      this.contributers = data;
      this.filteredContributers = this.contributers;
      })
    }

    deleteContributer(contributer: IContributer): void {
      const confirmDelete = confirm(`Are you sure you want to delete "${contributer.name}"?`);
      if (confirmDelete) {
        this._contributerService.deleteContributer(contributer.contributerId)
          .subscribe(
            (response) => {
              if (response.success) {
                console.log(response.message);
                this.filteredContributers = this.filteredContributers.filter(i => i !== contributer);
                // Update contributers
                this.getContributers();
              }
            },
            (error) => {
              console.error('Error deleting contributer', error);
            });

      }
  }
  filteredContributers: IContributer[] = this.contributers;

  performFilter(filterBy: string): IContributer[] {
    filterBy = filterBy.toLowerCase();
    console.log("Performing filter on ", this.filteredContributers)
    return this.contributers.filter((contributers: IContributer) =>
      contributers.name.toLowerCase().includes(filterBy));
  }

  toggleImage(): void {
    this.displayImage = !this.displayImage;
  }

  navigateToContributerform() {
    this._router.navigate(['/contributerform'])
  }

  ngOnInit(): void {
    console.log('ContributerConponent created');
    this.getContributers();
  }

}
