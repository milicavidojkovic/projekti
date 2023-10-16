//const mongoose= require("mongoose");
import mongoose from "mongoose";

const ObavestenjeSchema = new mongoose.Schema({

    autorId: {
        type: mongoose.SchemaTypes.ObjectId,
        //required: true

    }, naslov:{
        type: String,
        //required: true,
        max: 20

    }, ime:{
        type: String,

    }, prezime:{
        type: String,

    }, opis: {
        type: String,
        //required: true,
        max: 200

    }, datum: {
        type: Date,
        //required: true

    }, zgrada: {    //id
        type: mongoose.SchemaTypes.ObjectId //String,
        //required: true

    }, tipAutora: {
        type: String,
        enum:["Stanar", "Upravnik"]
    }

    
}, {timestamps: true});


export default mongoose.model("Obavestenje", ObavestenjeSchema);
//module.exports = mongoose.model("Obavestenje", ObavestenjeSchema);