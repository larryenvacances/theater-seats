import React, { useEffect, useState } from 'react';
import axios from 'axios';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemText from '@mui/material/ListItemText';
import Collapse from '@mui/material/Collapse';
import useAppContext from '../../hooks/useAppContext';

import './MoviesList.css';
import { Link } from 'react-router-dom';
import { convertValueToMeridiem } from '@mui/lab/internal/pickers/time-utils';

export default function MoviesList() {
  const [selectedIndex, setSelectedIndex] = useState(0);
  const [selectedTimeSlot, setSelectedTimeSlot] = useState('');
  const [movies, setMovies] = useState([]);
  const { userName } = useAppContext();

  const handleListItemClick = (event, index) => {
    setSelectedIndex(index);
  };

  const handleSubListItemClick = (event, index, subIndex) => {
    setSelectedTimeSlot(movies[index].timeSlots[subIndex].id);
  };

  useEffect(() => {
    axios.get('https://localhost:5001/api/Movies').then((res) => {
      setMovies(res.data);
      console.log(res.data);
    });
  }, []);

  return (
    <div className="MoviesList">
      <h1>{userName}</h1>
      <h1>{selectedTimeSlot}</h1>
      <List>
        {movies.map((value, index) => (
          <ListItemButton
            selected={selectedIndex === index}
            onClick={(event) => handleListItemClick(event, index)}
            key={value.title}
          >
            <ListItemText className="ListItemText" primary={value.title} />
            <List>
              {movies[index].timeSlots.map((timeSlot, timeSlotIndex) => (
                <ListItemButton
                  onClick={(event) =>
                    handleSubListItemClick(event, index, timeSlotIndex)
                  }
                  key={timeSlotIndex}
                >
                  <ListItemText primary={timeSlot.dateTime} />
                </ListItemButton>
              ))}
            </List>
          </ListItemButton>
        ))}
      </List>
      <Link to="/Theater" className="btn btn-primary">
        Submit
      </Link>
    </div>
  );
}
