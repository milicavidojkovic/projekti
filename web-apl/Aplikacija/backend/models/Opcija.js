import mongoose from "mongoose";


const OpcijaSchema = new mongoose.Schema({
    naziv: {
        type: String

    }, brojGlasova: {
        type: Number,
        default: 0

    }, anketaId: {
        type: mongoose.SchemaTypes.ObjectId,
    }
    
}, {timestamps: true});

//module.exports = 
export default mongoose.model("Opcija", OpcijaSchema);