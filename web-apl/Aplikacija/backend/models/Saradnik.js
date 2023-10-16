//const mongoose= require("mongoose");
import mongoose from "mongoose";

const SaradnikSchema = new mongoose.Schema({
    registrovaniKorisnikId: {
        type: mongoose.SchemaTypes.ObjectId,
        //required: true

    }, imeFirme: {
        //required: true,
        type: String

    }, telefon: {
        type: Number,
        //type: String,
        max: 999999999999

    }, email: {
        type: String,
        //required: true,
        max: 20

    }, dobijeniKvarovi: {
        type: Array,
        default: []

    }, racuni: {
        type: Array,
        default: []

    }, direktorId: {
        type: mongoose.SchemaTypes.ObjectId
    }

}, {timestamps: true});

//module.exports =
export default mongoose.model("Saradnik", SaradnikSchema);