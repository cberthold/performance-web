import * as React from 'react';
import { Form, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';
import { NavMenu } from './NavMenu';
import Auth from '../utils/auth';
import { unstable_renderSubtreeIntoContainer } from 'react-dom';

export interface IHandleAutentication
{
  onAuthenticated():void;
}
export interface LoginState {
  user: string;
  password: string;
  error: string;
}
export class Login extends React.Component<IHandleAutentication, LoginState> {
  constructor(props:any) {
    super(props);
    this.state = { user: 'guest', password: 'guest', error: '' };
  }

  private handleLogin(event : React.FormEvent<Form>) : void {
    event.preventDefault();
    let { user, password, error } = this.state;
    const { onAuthenticated } = this.props;

    this.setState(Object.assign(this.state, { error: null}));
    Auth.signIn(user, password)
    .then(_ => onAuthenticated())
    .catch(error => {
      if (error.message == "400")
        this.setState({ error: "Invalid password" });
      else
        this.setState({ error: error.message });
    });
  }

  private handleOnChange(event: any, name: string) : void {
    this.setState(Object.assign(this.state, { [name]: event.target.value }));
  }
    public render() {
      
      let { user, password, error } = this.state;
      const { onAuthenticated } = this.props;
  

        return <div className='row'>
                <div className="col-sm-2">
                </div>
                <div className='col-sm-8'>

        <Form onSubmit={(event) => this.handleLogin(event)}>
          <FormGroup controlId="username" bsSize="large">
            <ControlLabel>Username</ControlLabel>
            <FormControl
              autoFocus
              type="text"
              value={user}
              onChange={event => this.handleOnChange(event, 'user')}  
            />
          </FormGroup>
          <FormGroup controlId="password" bsSize="large">
            <ControlLabel>Password</ControlLabel>
            <FormControl
              value={password}
              onChange={event => this.handleOnChange(event, 'password')}
              type="password"
            />
          </FormGroup>
          <Button
            block
            bsSize="large"
            type="submit"
          >
            Login
          </Button>
        </Form>
                
                </div>
                <div className="col-sm-2">
                </div>
            </div>;
    }
}
