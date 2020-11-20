import EventsExpressService from '../services/EventsExpressService';
import { setAlert } from './alert';
import {createBrowserHistory} from 'history';

export const SET_CANCEL_ALL_EVENT_SUCCESS = "SET_CANCEL_ALL_EVENT_SUCCESS";
export const SET_CANCEL_ALL_EVENT_PENDING = "SET_CANCEL_ALL_EVENT_PENDING";
export const SET_CANCEL_ALL_EVENT_ERROR = "SET_CANCEL_ALL_EVENT_ERROR";
export const EVENT_CANCEL_ALL_WAS_CREATED = "EVENT_CANCEL_ALL_WAS_CREATED";

const api_serv = new EventsExpressService();
const history = createBrowserHistory({forceRefresh:true});

export default function cancel_all_occurenceEvent(eventId) {

    return dispatch => {
      dispatch(setCancelAllOccurenceEventsPending(true));
  
      const res = api_serv.setOccurenceEventsCancel(eventId);
      res.then(response => {
        if(response.error == null){
            dispatch(setCancelAllOccurenceEventsSuccess(true));
            response.text().then(x => { dispatch(cancelAllOccurenceEventsWasCreated(x));
            dispatch(setAlert({ variant: 'success', message: 'Your events was canceled!'}));
            dispatch(history.push(`/occurenceEvents`));} );
          }else{
            dispatch(setCancelAllOccurenceEventsError(response.error));
          }
        });
    }
  }

function cancelAllOccurenceEventsWasCreated(eventId){
  return{
    type: EVENT_CANCEL_ALL_WAS_CREATED,
    payload: eventId
  }
}

  export function setCancelAllOccurenceEventsSuccess(eventId) {
    return {
      type: SET_CANCEL_ALL_EVENT_SUCCESS,
      payload: eventId
    };
  }

export function setCancelAllOccurenceEventsPending(eventId) {
  return {
    type: SET_CANCEL_ALL_EVENT_PENDING,
    payload: eventId
  };
}

export function setCancelAllOccurenceEventsError(eventId) {
  return {
    type: SET_CANCEL_ALL_EVENT_ERROR,
    payload: eventId
  };
}
