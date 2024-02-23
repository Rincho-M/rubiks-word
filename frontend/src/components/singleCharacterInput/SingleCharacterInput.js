import { React, useState } from "react";

// CSS
import "../../css/index.css";

const SingleCharacterInput = (props) => {
  const [value, setValue] = useState(props.value);

  const updateValue = (event) => {
    const inputValue = event.target.value;
    const newValue = inputValue.slice(0, 1);
    setValue(newValue);
  };

  return (
    <input
      className='single-character-input'
      type='text'
      value={value}
      onChange={updateValue}
    />
  );
};

export default SingleCharacterInput;
