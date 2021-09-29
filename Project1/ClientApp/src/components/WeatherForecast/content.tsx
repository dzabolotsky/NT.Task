import * as React from "react";
import { connect } from "react-redux";
import { RouteComponentProps } from "react-router";
import { Link } from "react-router-dom";
import { ApplicationState } from "../../store";
import * as WeatherForecastsStore from "../../store/WeatherForecasts";
import * as CitiesStore from "../../store/City";
import Card from "./contentCard";
import { Input } from "antd";
import ContentSearch from "./contentSearch";
const { Search } = Input;
// At runtime, Redux will merge together...
type WeatherForecastProps = WeatherForecastsStore.WeatherForecastsState & // ... state we've requested from the Redux store
  typeof WeatherForecastsStore.actionCreators & // ... plus action creators we've requested
  RouteComponentProps<{ startDateIndex: string }>; // ... plus incoming routing parameters

class FetchData extends React.PureComponent<WeatherForecastProps> {
  // This method is called when the component is first added to the document
  public componentDidMount() {
    this.ensureDataFetched();
  }

  // This method is called when the route parameters change
  public componentDidUpdate(prev: WeatherForecastProps) {
    const { name } = this.props;
    const { name: prevName } = prev;
    //if (name && name != prevName) this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
        <ContentSearch
          onSearch={this.onSearch}
          onChange={this.onChange}
          onClear={this.onClear}
        />

        <Card item={this.props.forecast} />
      </React.Fragment>
    );
  }

  ensureDataFetched = (name?: string) =>
    this.props.requestWeatherForecasts(name ? name : this.props.name);
  onClear = async () => {
    this.props.ClearForecast();
  };
  onSearch = async (name?: string) => {
    this.ensureDataFetched(name);
  };
  onChange = async (name: string) => {
    debugger;
    this.props.setSearch(name);
    // this.ensureDataFetched();
  };
}

export default connect(
  (state: ApplicationState) => state.weatherForecasts, // Selects which state properties are merged into the component's props
  WeatherForecastsStore.actionCreators

  // Selects which action creators are merged into the component's props
)(FetchData as any); // eslint-disable-line @typescript-eslint/no-explicit-any
