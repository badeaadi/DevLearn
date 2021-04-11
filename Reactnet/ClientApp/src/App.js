import "./App.css";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import { LinkContainer } from "react-router-bootstrap";
import {NotificationContainer, NotificationManager} from 'react-notifications';
import 'react-notifications/lib/notifications.css';
import { useEffect, useState } from "react";
import Routes from "./Routes";
import { FaGithub } from "react-icons/fa";
import axios from "axios";

function App() {
  const [accountLogged, setAccountLogged] = useState(-1);
  const [problems, setProblems] = useState([]);
  const [user, setUser] = useState({username: "", password: ""})
  const [lectures, setLectures] = useState([]);
  const tabs = ["Problems", "Lectures"];



  useEffect(async () => {

    axios
      .get("/lectures")
      .then((res) => {
        setLectures(res.data);
        //console.log(res.data);
        //console.log(lectures);
      });
      axios
      .get("/problems")
      .then((res) => {
        setProblems(res.data);
        //console.log(res.data);
        //console.log(problems);
      });
  }, []);

  const handleLogIn = (username, password) => {
      axios.get(`/pupils/${username}`)
          .then(res => {
              console.log(res.data);
              if (res.data.password === password) {
                setAccountLogged(res.data.idPupil);
                console.log("Logged in");
                NotificationManager.success("Logged in successfully ", "OK", 2000, () => {}, true);
                setUser(username = res.data.username, password = res.data.password);
              }  
              else {
                console.log("Username or password not found");
              }
          })    
  }

  const postSlide = (lectureIdLecture, title, description) => {
    axios.post(`/slides`, {
        LectureId : lectureIdLecture,
        title : title,
        description : description
    })
        .then(res => {
            if(res.status === 200) {
                NotificationManager.success("Created successfully ", "OK", 2000, () => {}, true)
            }
        })
  }

  const postLecture = (title) => {
      axios.post(`/lectures`, {
          LectureTitle : title
        })
          .then(res => {
              if(res.status === 200) {
                  NotificationManager.success("Created successfully ", "OK", 2000, () => {}, true)
              }
          })
    }

    const handleRegister = (username, password) => {
      let st;
      axios.get(`/pupils/${username}`)
          .then(res => {
              if(res.status !== 200) {
                  ;
              } else {
                  NotificationManager.error("User already in db", "Nasol", 2000, () => {}, true)
              }
          })
          .catch(err => {
            console.log(err);
            console.log("aici");
            axios.post(`/pupils`, {
              Username : username,
              Password : password
            })
              .then(resp => {
                  if(resp.status === 200) {    
                    NotificationManager.success("New User ", "Houray", 2000, () => {}, true)
                    axios.get(`/pupils/${username}`)
                      .then(res => {
                        setAccountLogged(res.data.idPupil);
                        setUser(username = res.data.username, password = res.data.password);
                      })
                  }
              })
            })
    }

    const putRating = (problemId, newRating, link) => {
      console.log(problemId);
      axios.put(`/problems/${problemId}`, {
          ProblemLink: link,
          ProblemDifficulty: newRating
      })
      .then(res => {
        if(res.status === 200) {
          NotificationManager.success("Difficulty updated", "Success", 2000, () => {}, true)
        }
        else {
          NotificationManager.error("Error occured", "Nasol", 2000, () => {}, true)
        }
      })
  }

  const postProblem = (link, diff) => {
    axios.post('/problems', {
      ProblemLink: link,
      ProblemDifficulty: diff
    })
    .then(res => {
      if(res.status === 200) {
        NotificationManager.success("Problem Added", "Success", 2000, () => {}, true)
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
            {accountLogged !== -1 ? (
              <Navbar.Collapse className="justify-content-end">
                <LinkContainer to="/login">
                  <Nav.Link
                    onClick={() => {
                      setAccountLogged(-1);
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
      <Routes lectures={lectures} user = {user} handleLogin = {handleLogIn}  problems = {problems} putRating = {putRating} postProblem = {postProblem} postSlides = {postSlide} postLecture = {postLecture} handleRegister={handleRegister}/>
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
