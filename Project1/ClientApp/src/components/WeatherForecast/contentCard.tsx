import * as React from "react";
import { WeatherForecast } from "../../store/WeatherForecasts";
import "./card.css";
export interface IProps {
  item: WeatherForecast | null;
}

export default class Card extends React.Component<IProps> {
  public render() {
    const { item } = this.props;
    if (item)
      return (
        <React.Fragment>
          <div className="text-center">
            <h4>{`Aktuelle Wetterlage in ${item.cityName},DE`}</h4>
          </div>
          <div className="container-fluid">
            <div className="row">
              <div className="col-6">
                <div className="card-item">
                  <span>
                    <b>Temperatur:</b>
                  </span>
                  <span className="card-item-value">
                    {Math.round(item.temperature)}&#8451;
                  </span>
                </div>
                <div className="card-item">
                  <span>
                    <b>Luftdruck:</b>
                  </span>
                  <span className="card-item-value">
                    {Math.round(item.airPressure)}hPa
                  </span>
                </div>
                <div className="card-item">
                  <span>
                    <b>Feuchtigkeit:</b>
                  </span>
                  <span className="card-item-value">
                    {Math.round(item.humidity)}%
                  </span>
                </div>
                <div className="card-item">
                  <span>
                    <b>geringste Temperatur:</b>
                  </span>
                  <span className="card-item-value">
                    {Math.round(item.minTemperature)}&#8451;
                  </span>
                </div>
                <div className="card-item">
                  <span>
                    <b>höhsteTemperatur:</b>
                  </span>
                  <span className="card-item-value">
                    {Math.round(item.maxTemperature)}&#8451;
                  </span>
                </div>
                <div className="card-item">
                  <span>
                    <b>Windgeschwindigkeit:</b>
                  </span>
                  <span className="card-item-value">
                    {Math.round(item.windSpeed)}m/s
                  </span>
                </div>
                <div className="card-item">
                  <span>
                    <b>Windrichtung:</b>
                  </span>
                  <span className="card-item-value">
                    {Math.round(item.windDirection)}&deg;
                  </span>
                </div>
              </div>
              <div className="col-6">{item.cloudCoverCondition}</div>
            </div>
          </div>
        </React.Fragment>
      );
    else return null;
  }
}
