import {Form} from "react-bootstrap";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import React, {useEffect, useState} from "react";

const OpenedLecture = ({currentLecture, postSlides}) => {
    const [slideDescription, setSlideDescription] = useState("");
    const [slideTitle, setSlideTitle] = useState("");
    const [currentSlide, setCurrentSlide] = useState(0);

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
        <div className="opened-lecture-to-read">
            <Card style={{ width: "70rem" }}>
                <Card.Body>
                    <Card.Title>{currentLecture.slides[currentSlide].title}</Card.Title>
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