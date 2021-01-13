import React from "react";
import Jumbotron from "react-bootstrap/Jumbotron";
import "./Home.css";

export default function Home() {
  return (
    <div className="Home">
      <Jumbotron>
        <div className="lander">
          <h1>Welcome to DevLearn</h1>
        </div>
        <div>
          <h2>The only good platform for e-learning</h2>
        </div>
      </Jumbotron>
    </div>
  );
}
