import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Observable } from 'rxjs';
import { Stories } from '../../interfaces/stories';
import { MatSort } from '@angular/material/sort';
import { StoriesService } from '../../services/stories.service';

@Component({
  selector: 'app-list-top-stories',
  templateUrl: './list-top-stories.component.html',
  styleUrl: './list-top-stories.component.css'
})
export class ListTopStoriesComponent {
  displayedColumns: string[] = ['id', 'title', 'url', 'actions'];
  dataSource = new MatTableDataSource<Stories>();
  loading: boolean = false;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _storiesServices: StoriesService) { }

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this._storiesServices.getListStories().subscribe(data => {
      this.dataSource.data = data;
    })
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
