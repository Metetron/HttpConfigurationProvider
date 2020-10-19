import { red } from "@material-ui/core/colors";
import { createMuiTheme } from "@material-ui/core/styles";

const theme = createMuiTheme(
    {
        "palette": {
            "common": {
                "black": "#000",
                "white": "#fff"
            },
            "background": {
                "paper": "rgba(155, 155, 155, 1)",
                "default": "rgba(74, 74, 74, 1)"
            },
            "primary": {
                "light": "rgba(65, 129, 234, 1)",
                "main": "rgba(0, 70, 173, 1)",
                "dark": "rgba(0, 54, 137, 1)",
                "contrastText": "rgba(255, 255, 255, 1)"
            },
            "secondary": {
                "light": "rgba(255, 203, 121, 1)",
                "main": "rgba(242, 164, 33, 1)",
                "dark": "rgba(234, 146, 0, 1)",
                "contrastText": "rgba(0, 0, 0, 1)"
            },
            "error": {
                "light": "#e57373",
                "main": "rgba(237, 0, 29, 1)",
                "dark": "rgba(190, 41, 41, 1)",
                "contrastText": "#fff"
            },
            "text": {
                "primary": "rgba(255, 255, 255, 1)",
                "secondary": "rgba(255, 255, 255, 0.54)",
                "disabled": "rgba(255, 255, 255, 0.38)",
                "hint": "rgba(255, 255, 255, 0.38)"
            }
        }
    }
);

export default theme;