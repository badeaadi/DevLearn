import "./App.css";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import { LinkContainer } from "react-router-bootstrap";
import { useEffect, useState } from "react";
import Routes from "./Routes";
import { FaGithub } from "react-icons/fa";
import axios from "axios";

function App() {
  const [accountLogged, setAccountLogged] = useState(-1);
  const [lectures, setLectures] = useState([]);
  const tabs = ["Tests", "Lectures"];
  useEffect(async () => {
    axios
      .get("/lectures")
      .then((res) => res.json())
      .then((data) => {
        setLectures(data);
        console.log(data);
        console.log(lectures);
      });
  }, []);

  return (
    <div className="App container py-3">
      <Navbar collapseOnSelect bg="light" expand="md" className="mb-3">
        <LinkContainer to="/">
          <Navbar.Brand className="font-weight-bold text-muted">
            Home
          </Navbar.Brand>
        </LinkContainer>
        <Navbar.Toggle />
        <Navbar.Collapse className="justify-content-end">
          <Nav activeKey={window.location.pathname}>
            {accountLogged === -1 ? (
              <Navbar.Collapse className="justify-content-end">
                <LinkContainer to="/login">
                  <Nav.Link
                    onClick={() => {
                      setAccountLogged(1);
                      console.log("aaa");
                    }}
                  >
                    Log out
                  </Nav.Link>
                </LinkContainer>
                <LinkContainer to={"/" + tabs[0]}>
                  <Nav.Link>{tabs[0]}</Nav.Link>
                </LinkContainer>
                <LinkContainer to={"/" + tabs[1]}>
                  <Nav.Link>{tabs[1]}</Nav.Link>
                </LinkContainer>
              </Navbar.Collapse>
            ) : (
              <Navbar.Collapse className="justify-content-end">
                <LinkContainer to="/signup">
                  <Nav.Link>Signup</Nav.Link>
                </LinkContainer>
                <LinkContainer to="/login">
                  <Nav.Link>Login</Nav.Link>
                </LinkContainer>
              </Navbar.Collapse>
            )}
          </Nav>
        </Navbar.Collapse>
      </Navbar>
      <Routes />
      <Navbar bg="dark" variant="dark" sticky="bottom">
        <Navbar.Brand href="https://github.com/badeaadi">
          <FaGithub /> Adrian Catalin Badea
        </Navbar.Brand>
      </Navbar>
    </div>
  );
}

export default App;
