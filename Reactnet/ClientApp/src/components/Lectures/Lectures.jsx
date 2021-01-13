import React from "react";
import Card from "react-bootstrap/Card";
import ListGroup from "react-bootstrap/ListGroup";
import { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import "./Lectures.css";

export default function Lectures() {
  const [data, setData] = useState([]);
  const history = useHistory();
  const [openedLecture, setOpenedLecture] = useState(-1);

  useEffect(() => {
    fetch("https://jsonplaceholder.typicode.com/users")
      .then((response) => response.json())
      .then((json) => {
        setData(json);
        // console.log(json);
      });
  }, []);

  const openLecture = (id) => {};

  return (
    <div className="lectures">
      {openedLecture === -1
        ? data.map((user, idx) => (
            <Card style={{ width: "18rem" }} key={idx}>
              <Card.Header>{user.name}</Card.Header>
              <ListGroup variant="flush">
                <ListGroup.Item
                  action
                  onClick={() => {
                    openLecture(idx);
                  }}
                >
                  Cras justo odio
                </ListGroup.Item>
                <ListGroup.Item>Dapibus ac facilisis in</ListGroup.Item>
                <ListGroup.Item>Vestibulum at eros</ListGroup.Item>
              </ListGroup>
            </Card>
          ))
        : ""}
    </div>
  );
}
