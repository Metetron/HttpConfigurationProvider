import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import { TextField, MenuItem, InputAdornment } from "@material-ui/core";
import Translate from "@material-ui/icons/Translate";
import { useTranslation } from "react-i18next";

const useStyles = makeStyles((theme) => ({
    root: {
        color: "white"
    }
}));

function LanguageSelector() {
    const [language, setLanguage] = useState("de");
    const { i18n } = useTranslation("navBar");
    const classes = useStyles();

    const languages = [
        {
            name: "English", code: "en"
        },
        {
            name: "Deutsch", code: "de"
        }
    ];

    function handleChange(language: string) {
        setLanguage(language);
        i18n.changeLanguage(language);
    }

    return (
        <TextField
            id="language"
            select
            value={language}
            color="primary"
            onChange={e => handleChange(e.target.value)}
            InputProps={{
                classes: { root: classes.root },
                startAdornment: (
                    <InputAdornment position="start">
                        <Translate />
                    </InputAdornment>
                )
            }}
        >
            {languages.map(l => <MenuItem key={l.code} value={l.code}>{l.name}</MenuItem>)}
        </TextField>
    )
}

export default LanguageSelector;