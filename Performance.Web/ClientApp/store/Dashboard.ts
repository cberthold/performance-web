import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';
import auth from '../utils/auth';
import fetchapi from '../utils/fetchapi';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface DashboardOverviewState {
    isLoading: boolean;
    dashboard: Dashboard;
}

export interface Dashboard {
    allowedTenants: AllowedTenant[];
    topSales: TopSalesByTenantAndState[];
    lastSales: LastTenTenantInvoices[];
    lastOrders: LastTenTenantOrders[];
}

export interface TopSalesByTenantAndState
{
    id: string;
    tenant: AllowedTenant;
    billingState: string;
    totalSales: number;
}

export interface LastTenTenantInvoices
{
    invoiceId: number;
    invoiceDate: string;
    lastedEditedBy: string;
    accountPerson: string;
    customerName: string;
    tenant: AllowedTenant;
}

export interface LastTenTenantOrders
{
    orderId: number;
    orderDate: string;
    salesPerson: string;
    customerName: string;
    tenant: AllowedTenant;
}

export interface AllowedTenant {
    id: string;
    name: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestDashboardOverviewAction {
    type: 'REQUEST_DASHBOARD_OVERVIEW';
}

interface ReceiveDashboardOverviewAction {
    type: 'RECEIVE_DASHBOARD_OVERVIEW';
    dashboard: Dashboard;
}

interface ErrorDashboardOverviewAction {
    type: 'ERROR_DASHBOARD_OVERVIEW';
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestDashboardOverviewAction | ReceiveDashboardOverviewAction | ErrorDashboardOverviewAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestDashboardOverview: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        if (!getState().dashboard.isLoading) {
            let fetchTask = fetchapi(`api/Dashboard/Overview`)
            .catch((reason) => dispatch({ type: 'ERROR_DASHBOARD_OVERVIEW'}))
                .then(response => response.json() as Promise<Dashboard>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_DASHBOARD_OVERVIEW', dashboard: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_DASHBOARD_OVERVIEW'});
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: DashboardOverviewState = { 
    dashboard: { 
        allowedTenants: [],
        topSales: [],
        lastSales: [],
        lastOrders: [],
    }, 
    isLoading: false };

export const reducer: Reducer<DashboardOverviewState> = (state: DashboardOverviewState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_DASHBOARD_OVERVIEW':
            return {
                dashboard: state.dashboard,
                isLoading: true
            };
        case 'RECEIVE_DASHBOARD_OVERVIEW':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
             return {
                    dashboard: action.dashboard,
                    isLoading: false
                };
        case 'ERROR_DASHBOARD_OVERVIEW':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {
                    dashboard: state.dashboard,
                    isLoading: false
                };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
