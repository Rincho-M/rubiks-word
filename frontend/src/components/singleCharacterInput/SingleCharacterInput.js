import { React, useState } from "react";

// CSS
import "../../css/index.css";

const SingleCharacterInput = () => {
  const [value, setValue] = useState("1");

  const handleChange = (event) => {
    const inputValue = event.target.value;
    const newValue = inputValue.slice(0, 1); // Get the first character
    setValue(newValue);
  };

  return (
    <input
      class='single-character-input'
      type='text'
      value={value}
      onChange={handleChange}
    />
  );
};

export default SingleCharacterInput;
