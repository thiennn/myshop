import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { Switch, Route, useHistory, useRouteMatch } from "react-router-dom";
import { loginCallBackAsync } from "../store/auth-slice";

const Login = () => {
  let { path } = useRouteMatch();

  return (
    <div>
      <Switch>
        <Route path={`${path}/login-callback`} component={LoginCallBack} />
      </Switch>
    </div>
  );
};

const LoginCallBack = () => {
  const history = useHistory();
  const dispatch = useDispatch();

  useEffect(() => {
    const url = window.location.href;
    dispatch(loginCallBackAsync(url));
    history.push("/");
  }, [history, dispatch]);

  return <div>Loading</div>;
};

export default Login;
