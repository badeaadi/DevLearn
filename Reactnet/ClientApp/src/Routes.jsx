import React from "react";
import { Route, Switch } from "react-router-dom";
import { Home, LogIn, Lectures, NotFound } from "./components";
import Register from "./components/Register/Register";

export default function Routes({handleLogin, user, lectures, tests, postSlides, postLecture, handleRegister, deleteLecture, deleteSlide}) {
  return (
    <Switch>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/login">
        <LogIn handleLogIn = {handleLogin} user = {user}/>
      </Route>
      <Route exact path="/lectures">
        <Lectures lectures = {lectures} postSlides = {postSlides} postLecture={postLecture} user={user} deleteLecture = {deleteLecture} deleteSlide = {deleteSlide}/>
      </Route>
        <Route exact path = "/register">
        <Register handleRegister={handleRegister}/>
        </Route>
      <Route>
        <NotFound />
      </Route>
    </Switch>
  );
}
