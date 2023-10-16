import mongoose from "mongoose";


const GlasSchema = new mongoose.Schema({
    stanarId: {
        type: mongoose.SchemaTypes.ObjectId,

    }, opcija: {
        type: String,
        default : []

    }, anketaId: {
        type: mongoose.SchemaTypes.ObjectId,
    }
    
}, {timestamps: true});

//module.exports = 
export default mongoose.model("Glas", GlasSchema);