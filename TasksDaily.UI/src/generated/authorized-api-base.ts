import { AuthorizationHeaderProvider } from "./authorization-header-provider";

export class AuthorizedApiBase {
  private headerProvider: AuthorizationHeaderProvider;

  constructor() {
    this.headerProvider = new AuthorizationHeaderProvider();
  }

  protected transformOptions = (options: any): Promise<any> => {
    return this.headerProvider.getAuthorizationHeader(options)
  };
}
