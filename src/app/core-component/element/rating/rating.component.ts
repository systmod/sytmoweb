import { Component, OnInit } from '@angular/core';
import { routes } from 'src/app/core/helpers/routes';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent implements OnInit {
  public routes = routes;

  basicStar: Array<any> = [
    { show: false },
    { show: false },
    { show: false },
    { show: false },
    { show: false },
  ];
  savedStar: Array<any> = [
    { show: true },
    { show: true },
    { show: true },
    { show: false },
    { show: false },
  ];
  maxStar: Array<any> = [
    { show: false },
    { show: false },
    { show: false },
    { show: false },
    { show: false },
    { show: false },
    { show: false },
    { show: false },
  ];
  readOnlyStar: Array<any> = [
    { show: true },
    { show: true },
    { show: true },
    { show: false },
    { show: false },
  ];
  halfRatingStar: Array<any> = [
    { show: true, half: false },
    { show: true, half: false },
    { show: false, half: true },
    { show: false, half: false },
    { show: false, half: false },
  ];
  heartIcon: Array<any> = [
    { show: false },
    { show: false },
    { show: false },
    { show: false },
    { show: false },
  ];
  constructor() {}

  clickBasicStar(item: any, i: any, array: Array<any>): void {
    if (item.show == false) {
      array.map((res: any, index: any) => {
        if (index <= i) {
          res.show = true;
        }
      });
    } else {
      array.map((res: any, index: any) => {
        if (index >= i && index != 0) {
          res.show = false;
        }
      });
    }
    if (array == this.halfRatingStar) {
      array.map((res: any) => {
        res.half = false;
      });
    }
  }
  ngOnInit(): void {}


}
