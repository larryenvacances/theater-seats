import React, { createContext, useState } from 'react';
import PropTypes from 'prop-types';

export const AppContext = createContext({});

export default function AppContextProvider(props) {
  const { children } = props;
  const [userName, setUserName] = useState('');
  const [date, setDate] = useState(new Date());
  const [selectedTimeSlot, setSelectedTimeSlot] = useState('');

  const value = {
    userName,
    setUserName,
    date,
    setDate,
    selectedTimeSlot,
    setSelectedTimeSlot,
  };

  return <AppContext.Provider value={value}>{children}</AppContext.Provider>;
}

AppContextProvider.propTypes = {
  children: PropTypes.element.isRequired,
};
