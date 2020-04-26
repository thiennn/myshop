import React from "react";
import { BrowserRouter, Switch, Route, Link } from "react-router-dom";
import Home from "../components/Home";
import About from "../components/About";
import NavMenu from "./NavMenu";
import Login from "./Login";

const App = () => {
  return (
    <BrowserRouter basename={"/"}>
      <NavMenu />
      <div className="container">
        <div>
          <Link to="/">Home</Link> <Link to="/about">About</Link>
        </div>
        <Switch>
          <Route path="/authentication" component={Login} />
          <Route path="/about" component={About} />
          <Route path="/" component={Home} />
        </Switch>
      </div>
    </BrowserRouter>
  );
};

export default App;
