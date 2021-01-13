import React from "react";
import Jumbotron from "react-bootstrap/Jumbotron";
import "./NotFound.css";

export default function NotFound() {
  return (
    <div className="NotFound text-center">
      <Jumbotron>
        <h3>Sorry, page not found!</h3>
      </Jumbotron>
    </div>
  );
}
