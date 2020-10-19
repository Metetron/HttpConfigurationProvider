import React from 'react';
import ReactDOM from 'react-dom';
import "fontsource-roboto/300.css";
import "fontsource-roboto/400.css";
import "fontsource-roboto/500.css";
import "fontsource-roboto/700.css";
import { ThemeProvider } from "@material-ui/core/styles";
import CssBaseline from "@material-ui/core/CssBaseline";
import theme from "./theme/theme";
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import "./i18n/i18n";
import { BrowserRouter } from "react-router-dom";

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <App />
      </ThemeProvider>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
