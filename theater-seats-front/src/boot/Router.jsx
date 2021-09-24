import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Home from '../pages/Home';
import Calendar from '../pages/Calendar';
import Layout from './Layout';
import MoviesList from '../pages/MoviesList/MoviesList';
import Theater from '../pages/Theater';

export default function Router() {
  return (
    <BrowserRouter>
      <Layout>
        <Switch>
          <Route exact path="/">
            <Home />
          </Route>
          <Route exact path="/calendar">
            <Calendar />
          </Route>
          <Route exact path="/moviesList">
            <MoviesList />
          </Route>
          <Route exact path="/theater">
            <Theater />
          </Route>
        </Switch>
      </Layout>
    </BrowserRouter>
  );
}
