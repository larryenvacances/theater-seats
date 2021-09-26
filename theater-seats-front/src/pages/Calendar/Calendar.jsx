import React from 'react';
import { DatePicker } from '@mui/lab';
import { TextField } from '@mui/material';
import { Link } from 'react-router-dom';
import useAppContext from '../../hooks/useAppContext';

export default function Calendar() {
  const { userName, date, setDate } = useAppContext();

  return (
    <div className="App">
      <h1>{userName}</h1>
      <DatePicker
        label="Basic example"
        value={date}
        onChange={(newValue) => {
          setDate(newValue);
        }}
        renderInput={(params) => <TextField {...params} />}
      />
      <div>
        <Link to="/MoviesList">Submit</Link>
      </div>
    </div>
  );
}
