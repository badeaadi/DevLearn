import "./App.css";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import { LinkContainer } from "react-router-bootstrap";
import {NotificationContainer, NotificationManager} from 'react-notifications';
import 'react-notifications/lib/notifications.css';
import { useEffect, useState } from "react";
import Routes from "./Routes";
import { FaGithub } from "react-icons/fa";
import adminUser from './config';
import axios from "axios";

function App() {
  const [accountLogged, setAccountLogged] = useState(-1);
  const [test, setTest] = useState([]);
  const [user, setUser] = useState({username: adminUser.username, password: adminUser.password})
  const [lectures, setLectures] = useState([]);
  const tabs = ["Tests", "Lectures"];



  useEffect(async () => {
    axios
      .get("/lectures")
      .then((res) => {
        setLectures(res.data);
        console.log(res.data);
        console.log(lectures);
      });
  }, []);

  const handleLogIn = (username, password) => {
      axios.get(`/pupils/${username}`)
          .then(res => {
              console.log(res.data);
              if (res.data.password === password) {
                setAccountLogged(res.data.idPupil);
                console.log("Logged in");
                setUser({username: username, password: password});
              }  
              else {
                console.log("Username or password not found");
              }
          })    
  }

  const postSlide = (lectureIdLecture, title, description) => {
    axios.post(`/slides`, {
        lectureIdLecture,
        title,
        description
    })
        .then(res => {
            if(res.status === 200) {
                NotificationManager.success("Created successfully ", "OK", 2000, () => {}, true)
            }
        })
  }

  const postLecture = (title) => {
      axios.post(`/lectures`, {
          title
        })
          .then(res => {
              if(res.status === 200) {
                  NotificationManager.success("Created successfully ", "OK", 2000, () => {}, true)
              }
          })
    }

    const handleRegister = (username, password) => {
      axios.get(`/pupils/${username}`)
          .then(res => {
              if(res.status !== 200) {
                  axios.post(`/pupils`, {
                      username,
                      password
                  })
                      .then(resp => {
                          if(resp.status === 200) {
                              NotificationManager.success("New User ", "Houray", 2000, () => {}, true)
                          }
                      })
              } else {
                  NotificationManager.error("User already in db", "Nasol", 2000, () => {}, true)
              }
          })
    }

    const deleteLecture = (lectureId) => {
      axios.delete(`/lectures/${lectureId}`)
          .then(res => {
              if(res.status === 200) {
                  NotificationManager.success("Successfully Deleted", "Lecture", 2000, () => {}, true)
              }
          })
    }

    const deleteSlide = (lectureId, slideId) => {
        axios.delete(``)
            .then(res => {
                if(res.status === 200) {
                    NotificationManager.success("Successfully Deleted", "Slide", 2000, () => {}, true)
                }
            })
    }

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
                <LinkContainer to="/logout">
                  <Nav.Link
                    onClick={() => {
                      setAccountLogged(1);
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
                <LinkContainer to="/register">
                  <Nav.Link>Register</Nav.Link>
                </LinkContainer>
                <LinkContainer to="/login">
                  <Nav.Link>Login</Nav.Link>
                </LinkContainer>
              </Navbar.Collapse>
            )}
          </Nav>
        </Navbar.Collapse>
      </Navbar>
      <Routes
          lectures = {lectures}
          user = {user}
          handleLogin = {handleLogIn}
          tests
          postSlides = {postSlide}
          postLecture = {postLecture}
          handleRegister = {handleRegister}
          deleteLecture = {deleteLecture}
          deleteSlide = {deleteSlide}/>
      <Navbar bg="dark" variant="dark" sticky="bottom">
        <Navbar.Brand href="https://github.com/badeaadi">
          <FaGithub /> Adrian Catalin Badea
        </Navbar.Brand>
      </Navbar>
        <NotificationContainer/>
    </div>
  );
}

export default App;
