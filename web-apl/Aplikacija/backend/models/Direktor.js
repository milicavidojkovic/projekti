//const mongoose= require("mongoose");
import mongoose from "mongoose";


const DirektorSchema = new mongoose.Schema({
    registrovaniKorisnikId: {
        type: mongoose.SchemaTypes.ObjectId,

    }, upravnici: {
        type: Array,
        default : []

    }, saradnici: {
        type: Array,
        default: []

    }, email: {
        type: String,           
        max: 20

    }, telefon: {
        type: Number,
        max: 999999999999

    }, prihvaceniKvarovi: {
        type: Array,
        default: []
    
    }, racuni: {
        type: Array,
        default: []
    
    }
    
}, {timestamps: true});

//module.exports = 
export default mongoose.model("Direktor", DirektorSchema);