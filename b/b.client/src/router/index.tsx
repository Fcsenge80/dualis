import { createBrowserRouter } from "react-router";
import App from "../App";
import { LoginForm } from "../components/LoginFrom/LoginForm";

export const router = createBrowserRouter([
  {
    element: <App />,
    path: "/",
  },
  {
    element: <LoginForm />,
    path: "/login",
  },
]);
