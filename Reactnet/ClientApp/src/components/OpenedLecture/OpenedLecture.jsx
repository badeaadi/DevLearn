import {Form} from "react-bootstrap";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import React, {useEffect, useState} from "react";

const OpenedLecture = ({currentLecture, postSlides}) => {
    const [slideDescription, setSlideDescription] = useState("");
    const [slideTitle, setSlideTitle] = useState("");
    const [currentSlide, setCurrentSlide] = useState(-1);

    useEffect(() => {
        setCurrentSlide(0);
    }, [])

    const validateForm = () => {
        return slideDescription.length > 0 && slideTitle.length > 0;
    }

    const submitSlideHandler = (e) => {
        e.preventDefault();
        postSlides(currentLecture.idLecture, slideTitle, slideDescription);
    }

    return (
        <div className="opened-lecture">
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
            <Card style={{ width: "70rem" }}>
                <Card.Body>
                    <Card.Title>{currentLecture.slides.lectureTitle}</Card.Title>
                    <Card.Text>{currentLecture.slides[currentSlide].description}</Card.Text>
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
                                if (currentSlide < currentLecture.slides.length - 1)
                                    setCurrentSlide(currentSlide + 1);
                            }}
                            disabled={currentSlide === currentLecture.slides - 1}
                        >
                            Next Slide
                        </Button>
                    </Card.Text>
                </Card.Body>
            </Card>
        </div>
    );
}
export default OpenedLecture