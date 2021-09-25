import React, { useEffect, useState } from 'react';
import axios from 'axios';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemText from '@mui/material/ListItemText';
import useAppContext from '../../hooks/useAppContext';

import './MoviesList.css';
import { Link } from 'react-router-dom';

export default function MoviesList() {
  const [selectedIndex, setSelectedIndex] = useState(0);
  const [selectedSubIndex, setSelectedSubIndex] = useState(0);
  const [movies, setMovies] = useState([]);
  const { userName, selectedTimeSlot, setSelectedTimeSlot } = useAppContext();

  const handleListItemClick = (event, index) => {
    setSelectedIndex(index);
  };

  const handleSubListItemClick = (event, index, subIndex) => {
    setSelectedTimeSlot(movies[index].timeSlots[subIndex].id);
    setSelectedSubIndex(subIndex);
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
                  selected={selectedSubIndex === timeSlotIndex}
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
