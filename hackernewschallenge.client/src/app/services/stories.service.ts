import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Stories } from '../interfaces/stories';
import { Injectable } from '@angular/core';
import { Item } from '../interfaces/item';

@Injectable({
  providedIn: 'root'
})
export class StoriesService {
  myAppUrl: string = 'https://localhost:7127/';
  listTopStoriesUrl: string = 'getlisttopstories?page=1&pageSize=20';
  itemUrl: string = 'getitem?id=';
  constructor(private http: HttpClient) { }

  getListStories(): Observable<Stories[]> {
    return this.http.get<Stories[]>(this.myAppUrl + this.listTopStoriesUrl);
  }

  getItem(id: number): Observable<Item> {
    return this.http.get<Item>(this.myAppUrl + this.itemUrl + id);
  }
}
