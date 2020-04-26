import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { AppThunk, RootState } from "./store";

import { AuthService } from "../services/auth-service";

const authService = new AuthService();

interface User {
  name: string
}

interface AuthState {
  user?: User;
}

const initialState: AuthState = {
  user: undefined,
};

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    loginSuccess: (state, { payload }: PayloadAction<User>) => {
      state.user = payload;
    },
  },
});

export const { loginSuccess } = authSlice.actions;

export const loginAsync = (): AppThunk => async (dispatch) => {
  await authService.login();
};

export const selectIsAuthenticated = (state: RootState) => !!state.auth.user;

export default authSlice.reducer;
