import { Component, OnInit } from '@angular/core';
import { routes } from 'src/app/core/helpers/routes';

@Component({
  selector: 'app-icon-weather',
  templateUrl: './icon-weather.component.html',
  styleUrls: ['./icon-weather.component.scss'],
})
export class IconWeatherComponent implements OnInit {
  public routes = routes;

  constructor() {}

  ngOnInit(): void {}
}
