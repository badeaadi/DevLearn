import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import React, {useState} from "react";
import './Register.css';

export default function Register({ handleRegister }) {

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    function validateForm() {
        return username.length > 0 && password.length > 0;
    }

    const submitHandler = (e) => {
        e.preventDefault();
        handleRegister(username, password);
    }
    return (
        <div className="Register">
            <Form onSubmit={submitHandler}>
                <Form.Group size="lg" controlId="username">
                    <Form.Label>Username</Form.Label>
                    <Form.Control
                        autoFocus
                        type="username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </Form.Group>
                <Form.Group size="lg" controlId="password">
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </Form.Group>

                <Button block size="lg" type="submit" disabled={!validateForm()}>
                    Register
                </Button>
            </Form>
        </div>
    );
}