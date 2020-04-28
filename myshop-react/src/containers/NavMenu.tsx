import React from "react";
import { useSelector } from "react-redux";
import { Link } from "react-router-dom";

import LoginMenu from "../components/LoginMenu";
import { selectIsAuthenticated, selectUser } from "../store/auth-slice";

const NavMenu = () => {
  const isAuthenticated = useSelector(selectIsAuthenticated);
  const userName = useSelector(selectUser)?.name;

  return (
    <header>
      <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
        <div className="container">
          <Link to="/" className="navbar-brand">
            ReactSpa
          </Link>
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
            <LoginMenu isAuthenticated={isAuthenticated} userName={userName} />
          </div>
        </div>
      </nav>
    </header>
  );
};

export default NavMenu;
