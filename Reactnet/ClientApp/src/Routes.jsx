import React from "react";
import { Route, Switch } from "react-router-dom";
import { Home, LogIn, Lectures, NotFound, Register, Problems } from "./components";

export default function Routes({handleLogin, user, lectures, problems, putRating, postProblem, postSlides, postLecture, handleRegister}) {
  return (
    <Switch>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path = "/login">
        <LogIn handleLogIn = {handleLogin} user = {user}/>
      </Route>
      <Route exact path = "/lectures">
        <Lectures lectures = {lectures} postSlides = {postSlides} postLecture={postLecture} user={user}/>  
      </Route>
        <Route exact path = "/register">
        <Register handleRegister = {handleRegister}/>
        </Route>
        <Route exact path = "/problems">
        <Problems user = {user} problems = {problems} putRating = {putRating} postProblem = {postProblem}/>
        </Route>
      <Route>
        <NotFound />
      </Route>
    </Switch>
  );
}
