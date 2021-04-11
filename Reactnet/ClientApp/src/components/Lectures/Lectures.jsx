import React from "react";
import Card from "react-bootstrap/Card";
import ListGroup from "react-bootstrap/ListGroup";
import { useEffect, useState } from "react";
import "./Lectures.css";
import Button from "react-bootstrap/Button";
import {Form} from "react-bootstrap";
import adminUser from '../../config';
import axios from 'axios';
import {NotificationContainer, NotificationManager} from 'react-notifications';
import 'react-notifications/lib/notifications.css';
import OpenedLecture from "../OpenedLecture/OpenedLecture";

const Lectures = ({ lectures, postLecture, postSlides, user}) => {

  const [slideDescription, setSlideDescription] = useState("");
  const [slideTitle, setSlideTitle] = useState("");
  const [lectureTitle, setLectureTitle] = useState("")

  const [openedLecture, setOpenedLecture] = useState(-1);
  const [currentSlide, setCurrentSlide] = useState(-1);

  let groups = [];

  useEffect(() => {
    console.log(user);
  }, []);

  const openLecture = (index) => {
    setOpenedLecture(index);
    setCurrentSlide(0);
  };

  const closeLecture = () => {
    setOpenedLecture(-1);
  }

  const submitSlideHandler = (e) => {
    e.preventDefault();
    console.log(lectures[openedLecture].idLecture);
    postSlides(lectures[openedLecture].idLecture, slideTitle, slideDescription);
  }

  const submitLectureHandler = (e) => {
    e.preventDefault();
    postLecture(lectureTitle);
  }

  const deleteLecture = (lectureId) => {
    axios.delete(`/lectures/${lectureId}`)
        .then(res => {
            if(res.status === 200) {
                NotificationManager.success("Successfully Deleted", "Lecture", 2000, () => {}, true)
            }
        })
  }

  function validateForm() {
    return slideDescription.length > 0 && slideTitle.length > 0;
  }

  function validateLectureForm() {
    return lectureTitle.length > 0;
  }

  return (
    <div className="lectures">
    {
      openedLecture === -1 ? (
      <div>
        <div className="all-lectures">
            <Card style={{ width: "18rem" }}>
              <Card.Header>Lectures</Card.Header>
              <ListGroup variant="flush">
                {
                  lectures.map((lecture, index) => (
                    <ListGroup.Item
                      action
                      onClick={() => {
                        setOpenedLecture(index);
                        setCurrentSlide(0);
                        console.log(lecture);
                      }}
                    >
                      {lecture.lectureTitle}
                      {(user.username === adminUser.username && user.password === adminUser.password) ? (
                              <Button variant="outline-danger"
                              onClick={() => {
                                deleteLecture(lecture.idLecture)
                              }}>X</Button>):""}

                    </ListGroup.Item>
                  ))
                }
              </ListGroup>
            </Card>
        </div>
        {
        (user.username === adminUser.username && user.password === adminUser.password) ? (
        <div className="submitLecture"> 
          <Form onSubmit={submitLectureHandler}>
            <Form.Group size="lg" controlId="username">
              <Form.Label>Lecture Title</Form.Label>
              <Form.Control
                  autoFocus
                  type="title"
                  value={lectureTitle}
                  onChange={(e) => setLectureTitle(e.target.value)}
              />
            </Form.Group>

            <Button block size="lg" type="submit" disabled={!validateLectureForm()}>
              Add Lecture
            </Button>
          </Form>
        </div>
        ) : ""
      }
      </div>
      ) : (
        <div className = "lecture-seeing">
            {
              (user.username === adminUser.username && user.password === adminUser.password) ? (
                  <div className="slides-form">
                    <Form onSubmit={submitSlideHandler}>
                      <Form.Group size="lg" controlId="title">
                        <Form.Label>Title</Form.Label>
                        <Form.Control
                            autoFocus
                            type="title"
                            value={slideTitle}
                            onChange={(e) => setSlideTitle(e.target.value)}
                        />
                      </Form.Group>
                      <Form.Group size="lg" controlId="password">
                        <Form.Label>Descriptions</Form.Label>
                        <Form.Control
                            type="description"
                            value={slideDescription}
                            onChange={(e) => setSlideDescription(e.target.value)}
                        />
                      </Form.Group>

                      <Button block size="lg" type="submit" disabled={!validateForm()}>
                        Add Slide
                      </Button>
                    </Form>
                  <OpenedLecture currentLecture = {lectures[openedLecture]} postSlides = {submitSlideHandler}/>
                  <Button onClick={closeLecture}>
                    Go back
                  </Button>
                </div>
                  
              ) : (
                  <div>
                    <OpenedLecture currentLecture = {lectures[openedLecture]} postSlides = {submitSlideHandler}/>
                    <Button onClick={closeLecture}>
                      Go back
                    </Button>
                  </div>
              )
            }
          </div>
      )
    }
    </div>
  );
}

export default Lectures