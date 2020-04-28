import React from "react";
import { Link } from "react-router-dom";

interface IProps {
  isAuthenticated: boolean;
  userName?: string;
}

const LoginMenu = ({ isAuthenticated, userName }: IProps) => {
  if (isAuthenticated) {
    return (
      <ul className="navbar-nav">
        <li className="nav-item">
          <a className="nav-link text-dark" href="/">
            Hello {userName}
          </a>
        </li>
        <li className="nav-item">
          <Link to="/authentication/logout" className="nav-link text-dark">
            Logout
          </Link>
        </li>
      </ul>
    );
  }

  return (
    <ul className="navbar-nav">
      <li className="nav-item">
        <a className="nav-link text-dark" href="/">
          Register
        </a>
      </li>
      <li className="nav-item">
        <Link to="/authentication/login" className="nav-link text-dark">
          Login
        </Link>
      </li>
    </ul>
  );
};

export default LoginMenu;
