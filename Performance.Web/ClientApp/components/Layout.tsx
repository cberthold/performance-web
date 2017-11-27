import * as React from 'react';
import { NavMenu } from './NavMenu';
import { Login } from './Login';

export interface IAuthenticated
{
    isAuthenticated: boolean;
}

export class Layout extends React.Component<{}, IAuthenticated> {

    constructor(props:any)
    {
        super(props);
        this.state = { isAuthenticated: false };
    }


    public render() {
        if(this.state.isAuthenticated)
        {
             return <div className='container-fluid'> { this.renderLayout() } </div>;
        }
        else
        {
            return <div className='container-fluid'><Login onAuthenticated={()=>this.setState({ isAuthenticated: true })} /></div>;
        }
    }

    public renderLayout()
    {
        return <div className='row'>
                <div className='col-sm-2'>
                    <NavMenu />
                </div>
                <div className='col-sm-10'>
                    { this.props.children }
                </div>
            </div>;
    }
}
