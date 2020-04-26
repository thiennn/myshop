import { Log, User, UserManager } from "oidc-client";

const oidcSettings = {
  authority: "https://localhost:44349",
  client_id: "react_code_client",
  redirect_uri: "http://localhost:3000/authentication/login-callback",
  post_logout_redirect_uri: "http://localhost:3000/authentication/logout-callback",
  response_type: "code",
  scope: "api.myshop openid profile",
  automaticSilentRenew: true,
  includeIdTokenInSilentRenew: true,
};

export class AuthService {
  public userManager: UserManager;

  constructor() {
    this.userManager = new UserManager(oidcSettings);

    Log.logger = console;
    Log.level = Log.DEBUG;
  }

  public getUser(): Promise<User | null> {
    return this.userManager.getUser();
  }

  public login(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  public renewToken(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public logout(): Promise<void> {
    return this.userManager.signoutRedirect();
  }

  public signinRedirectCallback(): Promise<User> {
    return this.userManager.signinRedirectCallback();
  }
}
