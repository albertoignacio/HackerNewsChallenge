import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListTopStoriesComponent } from './components/list-top-stories/list-top-stories.component';
import { ItemComponent } from './components/item/item.component';

const routes: Routes = [
  { path: '', redirectTo: 'listTopStories', pathMatch: 'full' },
  { path: 'listTopStories', component: ListTopStoriesComponent },
  { path: 'verItem/:id', component: ItemComponent },
  { path: '*/*', redirectTo: 'listTopStories', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
