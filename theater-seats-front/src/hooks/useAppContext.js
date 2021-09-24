import { useContext } from 'react';

import { AppContext } from '../context/AppContextProvider';

export default () => {
  const value = useContext(AppContext);

  return value;
};
