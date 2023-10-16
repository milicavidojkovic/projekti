import mongoose from "mongoose";


const AnketaSchema = new mongoose.Schema({
    upravnikId: {
        type: mongoose.SchemaTypes.ObjectId

    }, glasovi: {
        type: Array,
        default : []

    }, opcije: {
        type: Array,
        default: []

    }, pitanje: {
        type: String,           
        max: 70

    }, brojGlasova:{
        type: Number,
        default: 0

    }, zgradaId: {
        type: mongoose.SchemaTypes.ObjectId
    }
    //mzd mi treba zgrada ovde a mzd i ne
    
}, {timestamps: true});

export default mongoose.model("Anketa", AnketaSchema);