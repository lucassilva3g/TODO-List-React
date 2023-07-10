import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import { TodoProvider } from "./Contexts/TodoContext";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <TodoProvider>
      <App />
    </TodoProvider>
  </React.StrictMode>
);
