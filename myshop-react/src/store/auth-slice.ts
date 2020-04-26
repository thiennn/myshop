import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { AppThunk, RootState } from "./store";

import { AuthService } from "../services/auth-service";

const authService = new AuthService();

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
  },
});

const { loginSuccess } = authSlice.actions;

export const loginAsync = (): AppThunk => async (dispatch) => {
  await authService.login();
};

export const loginCallBackAsync = (url: string): AppThunk => async (dispatch) => {
  await authService.loginCallback(url);
  const user = await authService.getUser();
  dispatch(loginSuccess({ name: user?.profile.name } as IUser));
};

export const selectIsAuthenticated = (state: RootState) => !!state.auth.user;
export const selectUser = (state: RootState) => state.auth.user;

export default authSlice.reducer;
