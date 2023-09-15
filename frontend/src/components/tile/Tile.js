import React from "react";
import { Grid, Paper } from "@mui/material";
import SingleCharacterInput from "../singleCharacterInput/SingleCharacterInput";

const Tile = ({ point }) => {
  console.log(point);
  console.log(point.letters);
  const gridItems = point.letters.map((value, index) => {
    return value.map((value, index) => {
      return (
        <Grid item xs={3} key={index}>
          <SingleCharacterInput value={value} />
        </Grid>
      );
    });
  });
  return (
    <Grid container className='tile'>
      {gridItems}
    </Grid>
  );
};

export default Tile;
