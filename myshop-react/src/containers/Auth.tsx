import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { Switch, Route, useHistory, useRouteMatch } from "react-router-dom";
import { loginAsync, logoutAsync, completeLoginAsync, completeLogoutAsync } from "../store/auth-slice";

const Auth = () => {
  let { path } = useRouteMatch();

  return (
    <div>
      <Switch>
        <Route path={`${path}/login`} component={Login} />
        <Route path={`${path}/logout`} component={Logout} />
        <Route path={`${path}/login-callback`} component={LoginCallBack} />
        <Route path={`${path}/logout-callback`} component={LogoutCallBack} />
      </Switch>
    </div>
  );
};

const Login = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(loginAsync());
  }, [dispatch]);

  return <div>Loading</div>;
};

const LoginCallBack = () => {
  const history = useHistory();
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(completeLoginAsync());
    history.push("/");
  }, [history, dispatch]);

  return <div>Loading</div>;
};

const Logout = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(logoutAsync());
  }, [dispatch]);

  return <div>Loading</div>;
};

const LogoutCallBack = () => {
  const history = useHistory();
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(completeLogoutAsync());
  }, [history, dispatch]);

  return <div>You successfully logged out!</div>;
};

export default Auth;
