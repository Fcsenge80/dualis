import { createBrowserRouter } from "react-router";
import App from "../App";
import { LoginForm } from "../components/LoginFrom/LoginForm";
import { Layout } from "../components/layout/Layout";
import { AuthenticatedLayout } from "../components/layout/AuthenticatedLayout";
import { AdminLayout } from "../components/layout/AdminLayout";
import { Products } from "../components/Product/Products";

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
        element: <Products />,
        path: "/products",
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
      {
        element: <AdminLayout />,
        children: [
          {
            element: <div>Product-admin</div>,
            path: "/product-admin",
          },
        ],
      },
    ],
  },
]);
