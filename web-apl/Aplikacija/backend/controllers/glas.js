import express from "express";
const router = express.Router();
import Anketa from "../models/Anketa.js";
import Glas from "../models/Glas.js";
import Opcija from "../models/Opcija.js";


export const glasaj = async (req, res) => { //stanar
    try
    {
        let ank;
        let opc;

        const glas = new Glas({
            stanarId: req.params.stanarId,
            opcija: req.body.opcija,
            anketaId: req.params.anketaId
        })

        try
        {
            opc = await Opcija.findById(req.params.opcijaId)
            let brGl = opc.brojGlasova + 1;
            await opc.updateOne({$set: {brojGlasova: brGl}})
        }
        catch(err)
        {
            return res.status(404).json("Opcija sa tim id-em ne postoji");
        }
        try
        {
            ank = await Anketa.findByIdAndUpdate(req.params.anketaId, {
                $push: {glasovi: glas}})
            let brGl = ank.brojGlasova + 1;
            await ank.updateOne({$set: {brojGlasova: brGl}})
        }
        catch(err)
        {
            return res.status(404).json("Anketa sa tim id-em ne postoji");
        }

        return res.status(200).json("Vaš glas je zabeležen");
    }
    catch (err)
    {
        return res.status(500).json(err);
    }

}

export default router;