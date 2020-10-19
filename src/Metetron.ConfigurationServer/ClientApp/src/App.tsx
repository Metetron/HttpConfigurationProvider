import React, { Suspense } from 'react';
import NavBar from "./components/NavBar/NavBar";
import { Switch, Route } from "react-router-dom";
import Home from "./components/Home/Home";
import { Container } from "@material-ui/core";

function App() {
  return (
    <Suspense fallback="loading...">
      <NavBar />
      <Container component="main">
        <Switch>
          <Route exact path="/" component={Home} />
        </Switch>
      </Container>
    </Suspense>
  );
}

export default App;
