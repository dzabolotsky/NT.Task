import React from "react";
import { compose } from "redux";
import "./weatherForecast.css";
import Content from "../WeatherForecast/content";

interface IProps {}

export const WeatherForecast: React.FC<IProps> = () => (
  <>
    <h1 className="text-center">Aktuelle Informationen</h1>
    <h3 className="page-description text-center">Stadtnamen eingeben</h3>
    <Content />
  </>
);

export default WeatherForecast;
