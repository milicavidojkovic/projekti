import mongoose from "mongoose";

const RacunSchema = new mongoose.Schema({

    saradnikId: {
        type: mongoose.SchemaTypes.ObjectId

    }, naziv: {
        type: String,
        max: 20


    }, datum: {
        type: Date,
        

    }, kvar: {
        type: mongoose.SchemaTypes.ObjectId

    }, vrednost: {
        type: Number

    }

    
}, {timestamps: true});


export default mongoose.model("Racun", RacunSchema);