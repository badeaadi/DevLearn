import React from "react";
import Card from "react-bootstrap/Card";
import ListGroup from "react-bootstrap/ListGroup";
import { useEffect, useState } from "react";
import "./Lectures.css";
import Button from "react-bootstrap/Button";
import { Form } from "react-bootstrap";
import adminUser from '../../config';
import OpenedLecture from '../OpenedLecture/OpenedLecture'

const Lectures = ({ lectures, postLecture, postSlides, user, deleteLecture, deleteSlide }) => {

  const [slideDescription, setSlideDescription] = useState("");
  const [slideTitle, setSlideTitle] = useState("");
  const [lectureTitle, setLectureTitle] = useState("")

  const [openedLecture, setOpenedLecture] = useState(-1);
  const [currentSlide, setCurrentSlide] = useState(-1);

  let groups = [];

  useEffect(() => {
    for(let i = 0; i < lectures.length; i+=5) {
      groups.push(lectures.slice(i, i + 5));
    }
    console.log(groups)
    console.log(lectures)
  }, []);

  const openLecture = (id) => {
    setOpenedLecture(id);
    setCurrentSlide(0);
  };

  const closeLecture = () => {
    setOpenedLecture(-1);
  }

  const submitSlideHandler = (e) => {
    e.preventDefault();
    postSlides(lectures[openedLecture].idLecture, slideTitle, slideDescription);
  }

  const submitLectureHandler = (e) => {
    e.preventDefault();
    postLecture(lectureTitle);
  }

  const validateForm = () => {
    return slideDescription.length > 0 && slideTitle.length > 0;
  }

  const submitDeleteLecture = (lectureId) => {
    deleteLecture(lectureId)
  }

  return (
    <div className="lectures">
      {openedLecture === -1 ? (
          <div className="all-lectures">
            <Card style={{ width: "18rem" }}>
              <Card.Header>Lectures</Card.Header>
              <ListGroup variant="flush">
                {
                  lectures.map((lecture, index) => (
                      <ListGroup.Item
                          action
                          onClick={() => {
                            openLecture(index);
                          }}
                      >
                        {lecture.lectureTitle}
                        {
                          (user.username === adminUser.username && user.password === adminUser.password) ? (
                              <Button variant="outline-danger"
                              onClick={() => {
                                submitDeleteLecture(lecture.idLecture)
                              }}>X</Button>
                          ) : ""
                        }
                      </ListGroup.Item>
                  ))
                }
              </ListGroup>
            </Card>
          </div>,
        (user.username === adminUser.username && user.password === adminUser.password) ? (
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

              <Button block size="lg" type="submit" disabled={!validateForm()}>
                Add Lecture
              </Button>
            </Form>
        ) : ""
      ) : (
          lectures[openedLecture].slides.length !== 0 ? (
            <div>
              <OpenedLecture currentLecture = {lectures[openedLecture]} postSlides={postSlides} />
              <Button onClick={closeLecture}>
                Go back
              </Button>
            </div>
          ) : (
            <div>
              <Form onSubmit={submitSlideHandler}>
                <Form.Group size="lg" controlId="username">
                  <Form.Label>Title</Form.Label>
                  <Form.Control
                      autoFocus
                      type="title"
                      value={slideTitle}
                      onChange={(e) => setSlideTitle(e.target.value)}
                  />
                </Form.Group>
                <Form.Group size="lg" controlId="password">
                  <Form.Label>Description</Form.Label>
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
            </div>
          )
      )}
    </div>
  );
}

export default Lectures
