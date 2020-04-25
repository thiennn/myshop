import React from "react";
import { BrowserRouter, Switch, Route, Link } from "react-router-dom";
import Home from "./components/Home";
import About from "./components/About";
import Login from "./components/auth/Login";

const App = () => {
  return (
    <BrowserRouter>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/about">About</Link>
            </li>
            <li>
              <Link to="/login">Login</Link>
            </li>
          </ul>
        </nav>

        <Switch>
          <Route path="/about" component={About}></Route>
          <Route path="/login" component={Login}></Route>
          <Route exact path="/" component={Home}></Route>
        </Switch>
      </div>
    </BrowserRouter>
  );
};

export default App;
