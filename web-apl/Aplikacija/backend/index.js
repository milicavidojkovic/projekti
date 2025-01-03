// const express = require("express");
// const dotenv = require("dotenv");
// const mongoose = require("mongoose");
// const morgan = require("morgan");

import express from "express";
import dotenv from "dotenv";
import mongoose from "mongoose";
import morgan from "morgan";
import helmet from "helmet";
import cors from "cors";

// const authRoute= require("./routes/auth.js");
// const registrovaniKorisnikRoute= require("./routes/registrovaniKorisnik.js");
// const saradnikRoute= require("./routes/saradnik.js");
// const stanarRoute= require("./routes/stanar.js");
// const upravnikRoute= require("./routes/upravnik.js");
// const direktorRoute= require("./routes/direktor.js");

import authRoute from "./routes/auth.js";
import registrovaniKorisnikRoute from "./routes/registrovaniKorisnik.js";
import saradnikRoute from "./routes/saradnik.js";
import stanarRoute  from "./routes/stanar.js";
import upravnikRoute  from "./routes/upravnik.js";
import direktorRoute from"./routes/direktor.js";
import obavestenjeRoute from "./routes/obavestenje.js";
import kvarRoute from "./routes/kvar.js";
import racunRoute from "./routes/racun.js";
import zgradaRoute from "./routes/zgrada.js";
import anketaRoute from "./routes/anketa.js";
import glasRoute from "./routes/glas.js"

dotenv.config();

const app = express();

app.use(helmet());
app.use(express.json());
app.use(cors());
app.use(morgan("common"));

mongoose.connect(process.env.MONGO_URL, {
    useNewUrlParser: true, useUnifiedTopology: true,
}).then(console.log("connected to mongodb")).catch((err)=> console.log(err));

 
app.use((req, res, next)=>{
    const origin = req.headers.origin;
    res.setHeader('Access-Control-Allow-Origin', 'http://localhost:3000');
    res.setHeader('Access-Control-Allow-Credentials', true);
    return next();
})
app.use("/api/auth", authRoute);
app.use("/api/registrovaniKorisnik", registrovaniKorisnikRoute);
app.use("/api/direktor", direktorRoute);
app.use("/api/stanar", stanarRoute);
app.use("/api/upravnik", upravnikRoute);
app.use("/api/saradnik", saradnikRoute);
app.use("/api/obavestenje", obavestenjeRoute);
app.use("/api/kvar", kvarRoute);
app.use("/api/racun", racunRoute);
app.use("/api/zgrada", zgradaRoute);
app.use("/api/anketa", anketaRoute);
app.use("/api/glas", glasRoute)

app.listen("8080", ()=>{
    console.log("backend server is running");
})


