import React, { useEffect } from "react";
import { BrowserRouter, Switch, Route, Link, useHistory } from "react-router-dom";
import Home from "../components/Home";
import About from "../components/About";
import { AuthService } from "../services/auth-service";
import NavMenu from "./NavMenu";

class App extends React.Component<any, any> {
  public authService: AuthService;
  private shouldCancel: boolean;

  constructor(props: any) {
    super(props);

    this.authService = new AuthService();
    this.state = { user: {}, api: {} };
    this.shouldCancel = false;
  }

  public componentDidMount() {
    this.getUser();
  }

  public login = () => {
    this.authService.login();
  };

  public componentWillUnmount() {
    this.shouldCancel = true;
  }

  public renewToken = () => {
    this.authService
      .renewToken()
      .then((user) => {
        console.log("Token has been sucessfully renewed. :-)");
        this.getUser();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  public logout = () => {
    this.authService.logout();
  };

  public getUser = () => {
    this.authService.getUser().then((user) => {
      if (user) {
        console.log("User has been successfully loaded from store.", user);
      } else {
        console.log("You are not logged in.");
      }

      if (!this.shouldCancel) {
        this.setState({ user });
      }
    });
  };

  public render() {
    return (
      <BrowserRouter basename={"/"}>
        <NavMenu />
        <Buttons
          login={this.login}
          logout={this.logout}
          renewToken={this.renewToken}
          getUser={this.getUser}
        />
        <div className="container">
          <div>
            <Link to="/">Home</Link> <Link to="/about">About</Link>
          </div>
          <Switch>
            <Route
              exact={true}
              path="/authentication/login-callback"
              component={LoginCallBack}
            />
            {/* <Route exact={true} path="/logout" component={Logout} />
            <Route
              exact={true}
              path="/authentication/logout-callback"
              component={LogoutCallback}
            /> */}
            <Route path="/about" component={About} />
            <Route path="/" component={Home} />
          </Switch>
        </div>
      </BrowserRouter>
    );
  }
}

const LoginCallBack = () => {
  const history = useHistory();
  const authService = new AuthService();

  useEffect(() => {
    authService.signinRedirectCallback().then(() => {
      console.log("Login successfully");
      history.push("/");
    });
  }, [authService, history]);

  return <div>Loading</div>;
};

interface IButtonsProps {
  login: () => void;
  getUser: () => void;
  renewToken: () => void;
  logout: () => void;
}

const Buttons: React.FunctionComponent<IButtonsProps> = (props) => {
  return (
    <div className="row">
      <div className="col-md-12 text-center" style={{ marginTop: "30px" }}>
        <button
          className="btn btn-primary btn-login"
          style={{ margin: "10px" }}
          onClick={props.login}
        >
          Login
        </button>
        <button
          className="btn btn-secondary btn-getuser"
          style={{ margin: "10px" }}
          onClick={props.getUser}
        >
          Get User info
        </button>
        <button
          className="btn btn-success btn-renewtoken"
          style={{ margin: "10px" }}
          onClick={props.renewToken}
        >
          Renew Token
        </button>
        <button
          className="btn btn-dark btn-logout"
          style={{ margin: "10px" }}
          onClick={props.logout}
        >
          Logout
        </button>
      </div>
    </div>
  );
};

export default App;
