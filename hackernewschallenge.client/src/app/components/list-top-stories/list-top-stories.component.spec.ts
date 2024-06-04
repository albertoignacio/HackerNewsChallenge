import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListTopStoriesComponent } from './list-top-stories.component';

describe('ListTopStoriesComponent', () => {
  let component: ListTopStoriesComponent;
  let fixture: ComponentFixture<ListTopStoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListTopStoriesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListTopStoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
