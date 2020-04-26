import React from "react";
import LoginMenu from "./LoginMenu";

const NavMenu = () => {
  return (
    <header>
      <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
        <div className="container">
          <a className="navbar-brand" href="/">ReactSpa</a>
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
            <LoginMenu isAuthenticated={false} />
          </div>
        </div>
      </nav>
    </header>
  );
};

export default NavMenu;
