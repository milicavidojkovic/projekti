//const mongoose = require("mongoose");
import mongoose from "mongoose";

const KvarSchema = new mongoose.Schema({
    urgentnost:{
        type: String,
        enum:["Hitno je", "Nije hitno"]
        
    }, stanarId: {
        type: mongoose.SchemaTypes.ObjectId
        
    }, upravnikId: {
        type: mongoose.SchemaTypes.ObjectId

    }, naslov:{
        type: String,
        //required: true,
        max: 20

    }, opis: {
        type: String,
        //required: true,
        max: 70

    }, status:{
        type: String,
        enum: ["Prijavljen", "Prosleđen direktoru", "Prosleđen saradniku", "Popravka je u toku", "Odbijen", "Završen"]

    }, saradnikId: {
        type: mongoose.SchemaTypes.ObjectId
        //popuniće se kad saradnik prihvati problem
        
    }, zgradaLokacija: {
        type: String

    }, stan: {
        type: Number
    },

},{timestamps: true});


//module.exports =
export default mongoose.model("Kvar", KvarSchema);