import React from "react";
import Card from "react-bootstrap/Card";
import ListGroup from "react-bootstrap/ListGroup";
import { useEffect, useState } from "react";
import "./Lectures.css";
import Button from "react-bootstrap/Button";

export default function Lectures() {
  const [data, setData] = useState([]);
  const [openedLecture, setOpenedLecture] = useState(-1);
  const [currentSlide, setCurrentSlide] = useState(-1);

  const arr = ["IT", "Mathematics"];
  const it = data.slice(0, 7);
  const mathematics = data.slice(8);

  useEffect(() => {
    fetch("https://jsonplaceholder.typicode.com/users")
      .then((response) => response.json())
      .then((json) => {
        setData(json);
        // console.log(json);
      });
  }, []);

  const openLecture = (id) => {
    setOpenedLecture(id);
    setCurrentSlide(0);
  };

  return (
    <div className="lectures">
      {openedLecture === -1 ? (
        <div className="lectures">
          {arr.map((item, idx) => (
            <Card style={{ width: "18rem" }} key={idx}>
              <Card.Header>{item}</Card.Header>
              <ListGroup variant="flush">
                {item === "IT"
                  ? it.map((dom) => (
                      <ListGroup.Item
                        action
                        onClick={() => {
                          openLecture(idx);
                        }}
                      >
                        {dom.name}
                      </ListGroup.Item>
                    ))
                  : item === "Mathematics"
                  ? mathematics.map((dom) => (
                      <ListGroup.Item
                        action
                        onClick={() => {
                          openLecture(idx);
                        }}
                      >
                        {dom.name}
                      </ListGroup.Item>
                    ))
                  : ""}
              </ListGroup>
            </Card>
          ))}
        </div>
      ) : (
        <div className="opened-lecture">
          <Card style={{ width: "70rem" }}>
            <Card.Body>
              <Card.Title>{data[currentSlide].name}</Card.Title>
              <Card.Text>{data[currentSlide].company.catchPhrase}</Card.Text>
              <Card.Text>
                <Button
                  variant="outline-secondary"
                  onClick={() => {
                    if (currentSlide > 0) setCurrentSlide(currentSlide - 1);
                  }}
                  disabled={currentSlide === 0}
                >
                  Previous Slide
                </Button>
                {`     ${currentSlide + 1}     `}
                <Button
                  variant="outline-secondary"
                  onClick={() => {
                    if (currentSlide < data.length - 1)
                      setCurrentSlide(currentSlide + 1);
                  }}
                  disabled={currentSlide === data.length - 1}
                >
                  Next Slide
                </Button>
              </Card.Text>
            </Card.Body>
          </Card>
        </div>
      )}
    </div>
  );
}
