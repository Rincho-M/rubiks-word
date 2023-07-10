import React from "react";
import { Grid, Paper } from "@mui/material";
import SingleCharacterInput from "../singleCharacterInput/SingleCharacterInput";

const Tile = () => {
  const values = [
    "",
    "",
    "",
    "",
    "",
    "",
    "",
    "",
    "",
    "",
    "",
    "",
    "",
    "",
    "",
    "",
  ];
  const gridItems = values.map((value) => {
    return (
      <Grid item xs={3}>
        <SingleCharacterInput>{value}</SingleCharacterInput>
      </Grid>
    );
  });
  return (
    <Grid container className='tile'>
      {gridItems}
    </Grid>
  );
};

export default Tile;
