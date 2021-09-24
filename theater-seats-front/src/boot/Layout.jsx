import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

export default function Layout(props) {
  const { children } = props;

  return (
    <>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
        </ul>
      </nav>

      <main>{children}</main>

      <footer />
    </>
  );
}

Layout.propTypes = {
  children: PropTypes.element.isRequired,
};
