import React from "react";
import ReactDOM from "react-dom/client";
import Title from "./components/title/Title";
import RubiksCube from "./components/rubiksCube/RubiksCube";
import { Stack } from "@mui/material";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <Stack direction='column' alignItems='center'>
      <Title />
      <RubiksCube />
    </Stack>
  </React.StrictMode>
);
