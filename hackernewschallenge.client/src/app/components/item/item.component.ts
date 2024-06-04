import { Component } from '@angular/core';
import { StoriesService } from '../../services/stories.service';
import { ActivatedRoute } from '@angular/router';
import { Item } from '../../interfaces/item';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrl: './item.component.css'
})
export class ItemComponent {
  id: number;
  item!: Item;

  constructor(private _storiesServices: StoriesService,
    private aRoute: ActivatedRoute) {
    this.id = +this.aRoute.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.getItem();
  }

  getItem() {
    this._storiesServices.getItem(this.id).subscribe(data => {
      this.item = data;
    })
  }
}
