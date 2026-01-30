import { createBrowserRouter } from "react-router";
import App from "../App";
import { LoginForm } from "../components/LoginFrom/LoginForm";
import { Layout } from "../components/layout/Layout";
import { AuthenticatedLayout } from "../components/layout/AuthenticatedLayout";

export const router = createBrowserRouter([
  {
    element: <Layout />,
    children: [
      {
        element: <div>Home</div>,
        path: "/",
      },
      {
        element: <LoginForm />,
        path: "/login",
      },
      {
        element: <AuthenticatedLayout />,
        children: [
          {
            element: <App />,
            path: "/weather-forecasts",
          },
        ],
      },
    ],
  },
]);
