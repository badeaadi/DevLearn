import React from "react";
import { Route, Switch } from "react-router-dom";
import { Home, LogIn, Lectures, NotFound } from "./components";

export default function Routes() {
  return (
    <Switch>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/login">
        <LogIn />
      </Route>
      <Route exact path="/lectures">
        <Lectures />
      </Route>
      <Route>
        <NotFound />
      </Route>
    </Switch>
  );
}
