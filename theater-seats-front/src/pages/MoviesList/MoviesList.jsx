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
  const { userName, setSelectedTimeSlot, setSelectedTheater, date } =
    useAppContext();

  const handleListItemClick = (event, index) => {
    setSelectedIndex(index);
  };

  const handleSubListItemClick = (event, index, subIndex) => {
    setSelectedTimeSlot(movies[index].timeSlots[subIndex].id);
    setSelectedSubIndex(subIndex);
    setSelectedTheater(movies[index].timeSlots[subIndex].theater);
  };

  useEffect(() => {
    const params = {
      dateTime: date,
    };

    axios.get('https://localhost:5001/api/Movies', { params }).then((res) => {
      setMovies(res.data);
    });
  }, []);

  return (
    <div className="MoviesList">
      <h1>{userName}</h1>
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
                  <ListItemText
                    primary={'Representation: ' + timeSlot.displayHour + ':00'}
                  />
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
