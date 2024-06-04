import { Time } from "@angular/common";

export interface Item {
  id: number,
  type: string,
  by: string,
  time: Time,
  text: string,
  parent: string,
  poll?: number,
  url: string,
  score?: number,
  title: string
}
