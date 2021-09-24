import React from 'react';
import AdapterDateFns from '@mui/lab/AdapterDateFns';
import LocalizationProvider from '@mui/lab/LocalizationProvider';

import AppContextProvider from '../context/AppContextProvider';
import Router from './Router';
import './App.css';

export default function App() {
  return (
    <LocalizationProvider dateAdapter={AdapterDateFns}>
      <AppContextProvider>
        <Router />
      </AppContextProvider>
    </LocalizationProvider>
  );
}
