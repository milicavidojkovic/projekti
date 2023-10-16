//const mongoose= require("mongoose");
import mongoose from "mongoose";

const StanarSchema = new mongoose.Schema({
    registrovaniKorisnikId: {
        type: mongoose.SchemaTypes.ObjectId,
        //required: true

    }, brStana: {
        type: Number,
        //required: true,

    }, dugovanje: {
        type: Number,
        default: 0,

    }, zgrada: {
        //required: true,
        type: String    //lokacija

    }, brojUkucana: {
        //required: true,
        type: Number,
        default: 1

    }, kvarovi: {
        type: Array,
        default : []

    }, upravnikId: {
        type: mongoose.SchemaTypes.ObjectId

    },
    // ankete: {
    //     type: Array,
    //     default : []
    // }
}, {timestamps: true});

//module.exports =
export default mongoose.model("Stanar", StanarSchema);