import React from "react";
import { AppBar, Toolbar, Typography } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import { useTranslation } from "react-i18next";
import LanguageSelector from "../LanguageSelector/LanguageSelector";

const useStyles = makeStyles(theme => ({
    container: {
        width: "100%",
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
        flexDirection: "row"
    }
}))

function NavBar() {
    const { t } = useTranslation(["navBar"]);
    const classes = useStyles();

    return (
        <AppBar position="sticky">
            <Toolbar>
                <Typography variant="h5">{t("navBar:Title")}</Typography>
                <div className={classes.container}>
                    <div>

                    </div>
                    <LanguageSelector />
                </div>
            </Toolbar>
        </AppBar>
    )
}

export default NavBar;