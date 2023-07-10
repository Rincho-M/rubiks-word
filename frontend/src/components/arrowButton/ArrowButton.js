import React from "react";
import { IconButton, SvgIcon } from "@mui/material";

const ArrowButton = ({ style }) => {
  return (
    <IconButton style={style} aria-label='turn'>
      <SvgIcon>
        <path d='M0 12l10-8v6h12v4H10v6z' />
      </SvgIcon>
    </IconButton>
  );
};

export default ArrowButton;
