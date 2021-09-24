import React from 'react';
import { Link } from 'react-router-dom';

import useAppContext from '../../hooks/useAppContext';

export default function Home() {
  const { userName, setUserName } = useAppContext();

  return (
    <div className="App">
      <header className="App-header">
        <p>Please provide a name</p>
        <input value={userName} onInput={(e) => setUserName(e.target.value)} />
      </header>
      <Link to="/Calendar" className="btn btn-primary">
        Submit
      </Link>
    </div>
  );
}
