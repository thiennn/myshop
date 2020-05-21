import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { AppThunk, RootState } from "./store";

import authService from "../services/auth-service";

interface IUser {
  name: string;
}

interface IAuthState {
  user?: IUser;
}

const initialState: IAuthState = {
  user: undefined,
};

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    loginSuccess: (state, { payload }: PayloadAction<IUser>) => {
      state.user = payload;
    },
    logoutSuccess: (state) => {
      state.user = undefined;
    },
  },
});

export const { loginSuccess, logoutSuccess } = authSlice.actions;

export const loginAsync = (): AppThunk => async (dispatch) => {
  await authService.loginAsync();
};

export const completeLoginAsync = (): AppThunk => async (dispatch) => {
  await authService.completeLoginAsync(window.location.href);
  const user = await authService.getUserAsync();
  dispatch(loginSuccess({ name: user?.profile.name } as IUser));
};

export const logoutAsync = (): AppThunk => async (dispatch) => {
  await authService.logoutAsync();
  dispatch(logoutSuccess());
};

export const completeLogoutAsync = (): AppThunk => async (dispatch) => {
  await authService.completeLogoutAsync(window.location.href);
};

export const selectIsAuthenticated = (state: RootState) => !!state.auth.user;
export const selectUser = (state: RootState) => state.auth.user;

export default authSlice.reducer;
