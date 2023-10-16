//const mongoose= require("mongoose");
import mongoose from "mongoose";


const RegistrovaniKorisnikSchema = new mongoose.Schema({
    username:{
        type: String,
        //required: true,
        unique: true

    }, password:{
        type: String,
        //required: true,
        max: 20

    }, tipKorisnika:{
        type: String,
        //required: true,
        enum: [ "Stanar", "Upravnik", "Direktor", "Saradnik"]

    }, ime:{
        type: String,
        max: 20,
        //required: true
        
    }, prezime:{
        type: String,
        //required: true,
        max: 20
        
    }, 
}, {timestamps: true});

//module.exports =
export default mongoose.model("RegistrovaniKorisnik", RegistrovaniKorisnikSchema);