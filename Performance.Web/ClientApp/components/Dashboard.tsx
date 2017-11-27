import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as DashboardsState from '../store/Dashboard';

// At runtime, Redux will merge together...
type DashboardProps =
    DashboardsState.DashboardOverviewState        // ... state we've requested from the Redux store
    & typeof DashboardsState.actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{}>;

interface IDashboardState {
    location: string;
}

class Dashboard extends React.Component<DashboardProps, IDashboardState> {

    constructor(props: any) {
        super(props);
        this.state = {
            location: "",
        };
    }

    componentWillMount() {
        this.props.requestDashboardOverview();
    }

    componentWillReceiveProps(nextProps: DashboardProps) {
        if (nextProps.location.hash !== this.state.location) {
            this.setState({
                location: nextProps.location.hash
            });
            this.props.requestDashboardOverview();
        }
    }

    public render() {

        let { dashboard } = this.props;
        let { allowedTenants, topSales, lastSales, lastOrders } = dashboard;

        return <div>
            <h1>Dashboard Overview</h1>
            <div className='row'>
                <div className='col-sm-4'>
                    {this.renderTopSalesByTenantAndStateTable(topSales)}
                </div>
                <div className='col-sm-8'>
                    {this.renderLastTenTenantInvoicesTable(lastSales)}
                </div>
            </div>
            <div className='row'>
                <div className='col-sm-9'>
                    {this.renderLastTenTenantOrdersTable(lastOrders)}
                </div>
                <div className='col-sm-3'>
                {this.renderAllowedTenantsTable(allowedTenants)}
                </div>
            </div>
        </div>;
    }

    private renderAllowedTenantsTable(allowedTenants: DashboardsState.AllowedTenant[]) {
        return <div className="panel panel-primary">
            <div className="panel-heading">
                <h3 className="panel-title">My Allowed Tenants</h3>
            </div>
            <div className={`panel-body ${this.props.isLoading ? 'loading' : ''}`}>
                <table className='table'>
                    <thead>
                        <tr>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {allowedTenants.map(tenant =>
                            <tr key={tenant.id}>
                                <td>{tenant.name}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </div>;
    }

    private renderTopSalesByTenantAndStateTable(topSales: DashboardsState.TopSalesByTenantAndState[]) {
        return <div className="panel panel-primary">
            <div className="panel-heading">
                <h3 className="panel-title">Top Sales By Tenant and State</h3>
            </div>
            <div className={`panel-body ${this.props.isLoading ? 'loading' : ''}`}>
                <table className='table'>
                    <thead>
                        <tr>
                            <th>Tenant</th>
                            <th>State</th>
                            <th>Total Sales</th>
                        </tr>
                    </thead>
                    <tbody>
                        {topSales.map(sale =>
                            <tr key={sale.id}>
                                <td>{sale.tenant.name}</td>
                                <td>{sale.billingState}</td>
                                <td>{sale.totalSales}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </div>;
    }

    private renderLastTenTenantInvoicesTable(lastSales: DashboardsState.LastTenTenantInvoices[]) {
        return <div className="panel panel-primary">
            <div className="panel-heading">
                <h3 className="panel-title">Last 10 Invoices By Tenant</h3>
            </div>
            <div className={`panel-body ${this.props.isLoading ? 'loading' : ''}`}>
                <table className='table'>
                    <thead>
                        <tr>
                            <th>Tenant</th>
                            <th>Invoice #</th>
                            <th>Customer</th>
                            <th>Invoice Date</th>
                            <th>Account Mgr</th>
                        </tr>
                    </thead>
                    <tbody>
                        {lastSales.map(sale =>
                            <tr key={sale.invoiceId}>
                                <td>{sale.tenant.name}</td>
                                <td>{sale.invoiceId}</td>
                                <td>{sale.customerName}</td>
                                <td>{this.getDateString(sale.invoiceDate)}</td>
                                <td>{sale.accountPerson}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </div>;
    }

    private renderLastTenTenantOrdersTable(lastOrders: DashboardsState.LastTenTenantOrders[]) {
        return <div className="panel panel-primary">
            <div className="panel-heading">
                <h3 className="panel-title">Last 10 Orders By Tenant</h3>
            </div>
            <div className={`panel-body ${this.props.isLoading ? 'loading' : ''}`}>
                <table className='table'>
                    <thead>
                        <tr>
                            <th>Tenant</th>
                            <th>Order #</th>
                            <th>Customer</th>
                            <th>Order Date</th>
                            <th>Sales Mgr</th>
                        </tr>
                    </thead>
                    <tbody>
                        {lastOrders.map(sale =>
                            <tr key={sale.orderId}>
                                <td>{sale.tenant.name}</td>
                                <td>{sale.orderId}</td>
                                <td>{sale.customerName}</td>
                                <td>{this.getDateString(sale.orderDate)}</td>
                                <td>{sale.salesPerson}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </div>;
    }

    private getDateString(dateString: string) : string
    {
        var inputDate = new Date(dateString);
        var date = inputDate.getDate();
        var month = inputDate.getMonth(); 
        var year = inputDate.getFullYear();
        var monthDateYear  = (month+1) + "/" + date + "/" + year;

        return monthDateYear;
    }


}

export default connect(
    (state: ApplicationState) => state.dashboard, // Selects which state properties are merged into the component's props
    DashboardsState.actionCreators                 // Selects which action creators are merged into the component's props
)(Dashboard) as typeof Dashboard;
