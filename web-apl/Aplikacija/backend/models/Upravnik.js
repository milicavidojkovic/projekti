//const { Long } = require("mongodb");
//const mongoose= require("mongoose");
import mongoose from "mongoose";
//import Long from "mongodb";

const UpravnikSchema = new mongoose.Schema({
    
    registrovaniKorisnikId: {
        type: mongoose.SchemaTypes.ObjectId,
        //required: true

    }, zgrade: {     //type: Zgrada
        type: Array,
        default : []
        
    }, telefon: {
        type: Number,
        max: 999999999999

    }, email: {
        type: String,
        //required: true,
        max: 20

    }, direktorId: {
        type: mongoose.SchemaTypes.ObjectId,
        //required: true,        

    }, 
}, {timestamps: true});

//module.exports =
export default mongoose.model("Upravnik", UpravnikSchema);