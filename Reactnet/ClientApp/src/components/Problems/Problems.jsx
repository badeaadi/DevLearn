import { ListGroup } from "react-bootstrap";
import {useEffect, useState} from "react"
import Rating from "@material-ui/lab/Rating"
import axios from "axios";
import Button from "react-bootstrap/Button";
import {Form} from "react-bootstrap";
import adminUser from '../../config';

const Problems = ({ user, problems, putRating, postProblem }) => {

    const [link, setLink] = useState("");
    const [diff, setDiff] = useState(1);

    useEffect(() =>{
        console.log(problems);
    }, [])

    const submitProblemHandler = (e) => {
        e.preventDefault();
        postProblem(link, diff);
    }

    function validateForm() {
        return link.length > 0;
    }

    return(
        <div className = "problems">
            <ListGroup variant="flush">
            {
                problems.map((problem, index) => (
                    <div>
                    <ListGroup.Item key={index} action onClick={() => {
                        window.open(`${problem.link}`);
                    }}>
                        {problem.link.slice(problem.link.lastIndexOf("/") + 1)}
                    </ListGroup.Item>
                    <Rating
                    value={problem.dificultate}
                    onChange={(event, newRating) => {
                        console.log(problem.idProblem);
                      putRating(problem.idProblem, newRating, problem.link);
                    }}
                  />
                  </div>
                ))
            }
            </ListGroup>
            {
            (user.username === adminUser.username && user.password === adminUser.password) ? (
            <div className="submitLecture"> 
            <Form onSubmit={submitProblemHandler}>
                <Form.Group size="lg" controlId="username">
                    <Form.Label>Problem Link</Form.Label>
                    <Form.Control
                        autoFocus
                        type="title"
                        value={link}
                        onChange={(e) => setLink(e.target.value)}
                    />
                    <Rating
                    value={diff}
                    onChange={(event, newRating) => {
                        setDiff(newRating);
                    }}
                  />
                </Form.Group>
                <Button block size="lg" type="submit" disabled={!validateForm()}>
                Add Problem
                </Button>
          </Form>
        </div>
        ) : ""
            }
        </div>
    );
}

export default Problems;