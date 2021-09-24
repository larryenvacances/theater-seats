import * as React from 'react';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemText from '@mui/material/ListItemText';
import useAppContext from '../../hooks/useAppContext';

import './MoviesList.css';
import { Link } from 'react-router-dom';

export default function MoviesList() {
  const [selectedIndex, setSelectedIndex] = React.useState(0);
  const { userName } = useAppContext();

  const handleListItemClick = (event, index) => {
    setSelectedIndex(index);
  };

  const movies = ['Silence of the Lamb', 'Hereditary', 'Dune', 'Arrival'];

  return (
    <div className="MoviesList">
      <h1>{userName}</h1>
      <List>
        {movies.map((value, index) => (
          <ListItemButton
            selected={selectedIndex === index}
            onClick={(event) => handleListItemClick(event, index)}
            key={value}
          >
            <ListItemText className="ListItemText" primary={value} />
          </ListItemButton>
        ))}
      </List>
      <Link to="/Theater" className="btn btn-primary">
        Submit
      </Link>
    </div>
  );
}
