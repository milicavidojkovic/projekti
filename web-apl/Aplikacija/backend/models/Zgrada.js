//const mongoose= require("mongoose");
import mongoose from "mongoose";

const ZgradaSchema = new mongoose.Schema({
    brStanova: {
        type: Number,
        //required: true,

    }, lokacija: {   
        //required: true,
        type: String    

    }, stanari: {
        //required: true,
        type: Array,
        default : []

    }, upravnikId: {
        type: mongoose.SchemaTypes.ObjectId,
        default: null
    
    }, kvarovi: {
        type: Array,
        default: []

    }, obavestenja: {
        type: Array,
        default: []

    }, slika: {
        type: String

    }, ankete: {
        type: Array,
        default: []
    }
    
}, {timestamps: true});

//module.exports =
export default mongoose.model("Zgrada", ZgradaSchema);