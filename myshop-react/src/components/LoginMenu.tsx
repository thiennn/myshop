import React from "react";

interface Props {
  isAuthenticated: boolean;
}

const LoginMenu = ({ isAuthenticated }: Props) => {
  return isAuthenticated ? <AuthenticatedMenu /> : <UnAuthenticatedMenu />;
};

const AuthenticatedMenu = () => (
  <ul className="navbar-nav">
    <li className="nav-item">
      <a className="nav-link text-dark" title="Manage" href="/">
        Hello aa
      </a>
    </li>
    <li className="nav-item">
      <a className="nav-link text-dark" title="Logout" href="/">
        Logout
      </a>
    </li>
  </ul>
);

const UnAuthenticatedMenu = () => (
  <ul className="navbar-nav">
    <li className="nav-item">
      <a className="nav-link text-dark" href="/">
        Register
      </a>
    </li>
    <li className="nav-item">
      <a className="nav-link text-dark" href="/">
        Login
      </a>
    </li>
  </ul>
);

export default LoginMenu;
