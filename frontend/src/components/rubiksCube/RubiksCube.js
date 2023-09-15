import { React, useState, useEffect } from "react";
import { Grid } from "@mui/material";
import Tile from "../tile/Tile";
import ArrowButton from "../arrowButton/ArrowButton";
import { cubeApi } from "../../api/cube/api";

// CSS
import "../../css/index.css";

const RubiksCube = () => {
  const [values, setValues] = useState([
    {
      id: 0,
      position: "1",
      orientation: "1",
      letters: [
        ["-", "-", "-", "-"],
        ["-", "-", "-", "-"],
        ["-", "-", "-", "-"],
        ["-", "-", "-", "-"],
      ],
      color: "default",
    },
  ]);
  useEffect(() => {
    const wrapper = async () => {
      const cubeData = await cubeApi.getCube("test");
      setValues(cubeData.data.points);
    };
    wrapper();
  }, []);
  const gridItems = values.map((value) => {
    return (
      <Grid item xs={4} key={value.id}>
        <Tile point={value}></Tile>
      </Grid>
    );
  });
  return (
    <div class='rubiks-cube-container'>
      <div class='flex-center-horizontal' style={{ gridArea: "tt4" }}>
        <ArrowButton style={{ rotate: "90deg" }} />
      </div>
      <div class='flex-center-horizontal' style={{ gridArea: "t3" }}>
        <ArrowButton style={{ rotate: "90deg" }} />
      </div>
      <div class='flex-center-horizontal' style={{ gridArea: "t4" }}>
        <ArrowButton style={{ rotate: "90deg" }} />
      </div>
      <div class='flex-center-horizontal' style={{ gridArea: "t5" }}>
        <ArrowButton style={{ rotate: "90deg" }} />
      </div>

      <ArrowButton style={{ gridArea: "m1" }} />
      <ArrowButton style={{ gridArea: "tm2" }} />
      <ArrowButton style={{ gridArea: "m2" }} />
      <ArrowButton style={{ gridArea: "bm2" }} />

      <div class='flex-center-horizontal' style={{ gridArea: "bb4" }}>
        <ArrowButton style={{ rotate: "270deg" }} />
      </div>
      <div class='flex-center-horizontal' style={{ gridArea: "b3" }}>
        <ArrowButton style={{ rotate: "270deg" }} />
      </div>
      <div class='flex-center-horizontal' style={{ gridArea: "b4" }}>
        <ArrowButton style={{ rotate: "270deg" }} />
      </div>
      <div class='flex-center-horizontal' style={{ gridArea: "b5" }}>
        <ArrowButton style={{ rotate: "270deg" }} />
      </div>

      <ArrowButton style={{ gridArea: "m7", rotate: "180deg" }} />
      <ArrowButton style={{ gridArea: "tm6", rotate: "180deg" }} />
      <ArrowButton style={{ gridArea: "m6", rotate: "180deg" }} />
      <ArrowButton style={{ gridArea: "bm6", rotate: "180deg" }} />

      <Grid
        container
        spacing={0.4}
        className='rubiks-cube'
        style={{ gridArea: "m" }}
      >
        {gridItems}
      </Grid>
    </div>
  );
};

export default RubiksCube;
