import { jwtDecode } from "jwt-decode";
import { useAccessToken } from "./useAccessToken";
import { getRolesFromJwt } from "../utils";
import type { JwtData } from "../Types";

export function useAccount() {
  const { accessToken } = useAccessToken(false);

  const data = accessToken ? jwtDecode<JwtData>(accessToken) : null;
  const roles = getRolesFromJwt(data);
  const isAdmin = roles.includes("Admin");

  return {
    data,
    roles,
    isAdmin,
  };
}
