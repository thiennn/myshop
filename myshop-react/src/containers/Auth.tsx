import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useHistory, useParams } from "react-router-dom";
import { loginAsync, logoutAsync, completeLoginAsync, completeLogoutAsync } from "../store/auth-slice";

const Auth = () => {
  const history = useHistory();
  const dispatch = useDispatch();
  const { action } = useParams<{ action: string }>();

  useEffect(() => {
    switch (action) {
      case "login":
        dispatch(loginAsync());
        break;
      case "login-callback":
        dispatch(completeLoginAsync());
        history.push("/");
        break;
      case "logout":
        dispatch(logoutAsync());
        break;
      case "logout-callback":
        dispatch(completeLogoutAsync());
        history.push("/");
        break;
      default:
        break;
    }
  }, [dispatch, history, action]);

  return <div>Loading</div>;
};

export default Auth;
