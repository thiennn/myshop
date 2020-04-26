import React from "react";
import { useSelector, useDispatch } from "react-redux";
import LoginMenu from "../components/LoginMenu";

import { selectIsAuthenticated, selectUser, loginAsync } from "../store/auth-slice";

const NavMenu = () => {
  const isAuthenticated = useSelector(selectIsAuthenticated);
  const userName = useSelector(selectUser)?.name;
  const dispatch = useDispatch();

  return (
    <header>
      <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
        <div className="container">
          <a className="navbar-brand" href="/">
            ReactSpa
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target=".navbar-collapse"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
            <LoginMenu isAuthenticated={isAuthenticated} onLogin={() => dispatch(loginAsync())} userName={userName} />
          </div>
        </div>
      </nav>
    </header>
  );
};

export default NavMenu;
