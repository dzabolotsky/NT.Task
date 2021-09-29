import { Action, Reducer } from "redux";
import { AppThunkAction } from "./";

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface WeatherForecastsState {
  isLoading: boolean;
  forecast: WeatherForecast | null;
  error: string | null | undefined;
  name: string | null | undefined;
}

export interface WeatherForecast {
  temperature: number;
  minTemperature: number;
  maxTemperature: number;
  airPressure: number;
  windSpeed: number;
  windDirection: number;
  cloudCoverCondition: number;
  humidity: number;
  cityName: string;
  date: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestWeatherForecastsAction {
  type: "REQUEST_WEATHER_FORECASTS";
  name: string | null | undefined;
}

interface ReceiveWeatherForecastsAction {
  type: "RECEIVE_WEATHER_FORECASTS";
  forecast: WeatherForecast;
}

interface ErrorWeatherForecastsAction {
  type: "ERROR_WEATHER_FORECASTS";
  error: string | null;
}

interface SetForecastsSearchAction {
  type: "SET_FORECAST_SEARCH";
  name: string | null | undefined;
}

interface ClearForecastsSearchAction {
  type: "CLEAR_FORECAST_SEARCH";
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction =
  | RequestWeatherForecastsAction
  | ReceiveWeatherForecastsAction
  | SetForecastsSearchAction
  | ErrorWeatherForecastsAction
  | ClearForecastsSearchAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
  requestWeatherForecasts:
    (name?: string | null | undefined): AppThunkAction<KnownAction> =>
    (dispatch, getState) => {
      // Only load data if it's something we don't already have (and are not already loading)
      const appState = getState();
      const url = name ? `weatherforecast?name=${name}` : `weatherforecast`;

      fetch(url)
        .then((response) => response.json() as Promise<WeatherForecast>)
        .then((data) => {
          dispatch({ type: "RECEIVE_WEATHER_FORECASTS", forecast: data });
        })
        .catch((error) =>
          dispatch({
            type: "ERROR_WEATHER_FORECASTS",
            error: error.message as string,
          })
        );

      dispatch({ type: "REQUEST_WEATHER_FORECASTS", name });
    },
  setSearch:
    (name: string | null | undefined): AppThunkAction<KnownAction> =>
    (dispatch, getState) => {
      // Only load data if it's something we don't already have (and are not already loading)

      dispatch({ type: "SET_FORECAST_SEARCH", name });
    },
  ClearForecast: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
    // Only load data if it's something we don't already have (and are not already loading)

    dispatch({ type: "CLEAR_FORECAST_SEARCH" });
  },
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: WeatherForecastsState = {
  forecast: null,
  isLoading: false,
  error: null,
  name: null,
};

export const reducer: Reducer<WeatherForecastsState> = (
  state: WeatherForecastsState | undefined,
  incomingAction: Action
): WeatherForecastsState => {
  if (state === undefined) {
    return unloadedState;
  }

  const action = incomingAction as KnownAction;
  switch (action.type) {
    case "REQUEST_WEATHER_FORECASTS":
      return {
        ...state,
        isLoading: true,
      };
    case "RECEIVE_WEATHER_FORECASTS":
      // Only accept the incoming data if it matches the most recent request. This ensures we correctly
      // handle out-of-order responses.

      return {
        ...state,
        forecast: action.forecast,
        isLoading: false,
      };

      break;
    case "ERROR_WEATHER_FORECASTS":
      // Only accept the incoming data if it matches the most recent request. This ensures we correctly
      // handle out-of-order responses.

      return {
        ...state,
        error: action.error,
        isLoading: false,
      };

      break;
    case "SET_FORECAST_SEARCH":
      // Only accept the incoming data if it matches the most recent request. This ensures we correctly
      // handle out-of-order responses.

      return {
        ...state,
        name: action.name,
      };

      break;
    case "CLEAR_FORECAST_SEARCH":
      // Only accept the incoming data if it matches the most recent request. This ensures we correctly
      // handle out-of-order responses.

      return {
        ...state,
        name: null,
        forecast: null,
      };

      break;
  }

  return state;
};
