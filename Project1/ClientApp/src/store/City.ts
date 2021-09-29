import { Action, Reducer } from "redux";
import { AppThunkAction } from "./";

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface CitiesState {
  isLoading: boolean;
  cities: string[];
  error: string | null | undefined;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestCitiesAction {
  type: "REQUEST_CITIES";
}

interface ReceiveCitiesAction {
  type: "RECEIVE_CITIES";
  cities: string[];
}

interface ErrorCitiesAction {
  type: "ERROR_CITIES";
  error: string | null;
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction =
  | RequestCitiesAction
  | ReceiveCitiesAction
  | ErrorCitiesAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
  requestCities: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
    // Only load data if it's something we don't already have (and are not already loading)
    const appState = getState();

    fetch("cities")
      .then((response) => response.json() as Promise<string[]>)
      .then((data) => {
        dispatch({ type: "RECEIVE_CITIES", cities: data });
      })
      .catch((error) =>
        dispatch({
          type: "ERROR_CITIES",
          error: error.message as string,
        })
      );

    dispatch({ type: "REQUEST_CITIES" });
  },
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: CitiesState = {
  cities: [],
  isLoading: false,
  error: null,
};

export const reducer: Reducer<CitiesState> = (
  state: CitiesState | undefined,
  incomingAction: Action
): CitiesState => {
  if (state === undefined) {
    return unloadedState;
  }

  const action = incomingAction as KnownAction;
  switch (action.type) {
    case "REQUEST_CITIES":
      return {
        ...state,
        isLoading: true,
      };
    case "RECEIVE_CITIES":
      // Only accept the incoming data if it matches the most recent request. This ensures we correctly
      // handle out-of-order responses.

      return {
        ...state,
        cities: action.cities,
        isLoading: false,
      };

      break;
    case "ERROR_CITIES":
      // Only accept the incoming data if it matches the most recent request. This ensures we correctly
      // handle out-of-order responses.

      return {
        ...state,
        error: action.error,
        isLoading: false,
      };

      break;
  }

  return state;
};
