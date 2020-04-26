import React from "react";

interface IProps {
  isAuthenticated: boolean;
  onLogin: () => void;
  userName?: string;
}

const LoginMenu = ({ isAuthenticated, onLogin, userName }: IProps) => {
  if (isAuthenticated) {
    return (
      <ul className="navbar-nav">
        <li className="nav-item">
          <a className="nav-link text-dark" title="Manage" href="/">
            Hello {userName}
          </a>
        </li>
        <li className="nav-item">
          <a className="nav-link text-dark" title="Logout" href="/">
            Logout
          </a>
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
        <a
          className="nav-link text-dark"
          onClick={(e) => {
            e.preventDefault();
            onLogin();
          }}
          href="##"
        >
          Login
        </a>
      </li>
    </ul>
  );
};

export default LoginMenu;
