import authReducer, { loginSuccess, logoutSuccess } from "../../store/auth-slice";

describe("auth reducer", () => {
  it("should return the initial state", () => {
    expect(authReducer(undefined, {} as any)).toEqual({
      user: undefined,
    });
  });
  it("should handle login success", () => {
    expect(authReducer(undefined, loginSuccess({ name: "bob" }))).toEqual({
      user: { name: "bob" },
    });
  });

  it("should handle logout success", () => {
    expect(authReducer(undefined, logoutSuccess())).toEqual({
      user: undefined,
    });
  });
});
