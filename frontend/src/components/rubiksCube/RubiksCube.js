import { React, useState, useEffect } from "react";
import { Grid } from "@mui/material";
import Tile from "../tile/Tile";
import ArrowButton from "../arrowButton/ArrowButton";
import { cubeApi, cubeApiWs, cubeHub } from "../../api/cube/api";

// CSS
import "../../css/index.css";

const RubiksCube = () => {
  const [values, setValues] = useState({
    cubeId: 0,
    cubeName: "default",
    points: [
      [
        {
          id: 0,
          position: "1",
          orientation: "1",
          letters: [
            ["1", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
          ],
          color: "red",
        },
        {
          id: 1,
          position: "1",
          orientation: "1",
          letters: [
            ["2", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
          ],
          color: "red",
        },
        {
          id: 2,
          position: "1",
          orientation: "1",
          letters: [
            ["3", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
          ],
          color: "red",
        },
      ],
      [
        {
          id: 3,
          position: "1",
          orientation: "1",
          letters: [
            ["4", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
          ],
          color: "red",
        },
        {
          id: 4,
          position: "1",
          orientation: "1",
          letters: [
            ["5", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
          ],
          color: "red",
        },
        {
          id: 5,
          position: "1",
          orientation: "1",
          letters: [
            ["6", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
          ],
          color: "red",
        },
      ],
      [
        {
          id: 6,
          position: "1",
          orientation: "1",
          letters: [
            ["7", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
          ],
          color: "red",
        },
        {
          id: 7,
          position: "1",
          orientation: "1",
          letters: [
            ["8", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
          ],
          color: "red",
        },
        {
          id: 8,
          position: "1",
          orientation: "1",
          letters: [
            ["9", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
            ["-", "-", "-", "-"],
          ],
          color: "red",
        },
      ],
    ],
  });

  useEffect(() => {
    const wrapper = async () => {
      await cubeHub.start();
      await cubeHub.invoke("WriteLetter", 1, { X: 1, Y: 1, Z: 1 }, "r");
      console.log("itshappened");

      //const cubeData = await cubeApi.getCube("test");
      //console.log(cubeData.data);
      //setValues(cubeData.data);
    };
    wrapper();
  }, []);

  const gridItems = values.points.map((row) => {
    return row.map((tile) => {
      return (
        <Grid item xs={4} key={tile.id}>
          <Tile point={tile}></Tile>
        </Grid>
      );
    });
  });

  return (
    <div className='rubiks-cube-container'>
      <div className='flex-center-horizontal' style={{ gridArea: "tt4" }}>
        <ArrowButton style={{ rotate: "90deg" }} />
      </div>
      <div className='flex-center-horizontal' style={{ gridArea: "t3" }}>
        <ArrowButton style={{ rotate: "90deg" }} />
      </div>
      <div className='flex-center-horizontal' style={{ gridArea: "t4" }}>
        <ArrowButton style={{ rotate: "90deg" }} />
      </div>
      <div className='flex-center-horizontal' style={{ gridArea: "t5" }}>
        <ArrowButton style={{ rotate: "90deg" }} />
      </div>

      <ArrowButton style={{ gridArea: "m1" }} />
      <ArrowButton style={{ gridArea: "tm2" }} />
      <ArrowButton style={{ gridArea: "m2" }} />
      <ArrowButton style={{ gridArea: "bm2" }} />

      <div className='flex-center-horizontal' style={{ gridArea: "bb4" }}>
        <ArrowButton style={{ rotate: "270deg" }} />
      </div>
      <div className='flex-center-horizontal' style={{ gridArea: "b3" }}>
        <ArrowButton style={{ rotate: "270deg" }} />
      </div>
      <div className='flex-center-horizontal' style={{ gridArea: "b4" }}>
        <ArrowButton style={{ rotate: "270deg" }} />
      </div>
      <div className='flex-center-horizontal' style={{ gridArea: "b5" }}>
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
