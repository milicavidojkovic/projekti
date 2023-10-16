import express from "express";
const router = express.Router();
import Upravnik from "../models/Upravnik.js";
import Zgrada from "../models/Zgrada.js";
import Anketa from "../models/Anketa.js";
import Stanar from "../models/Stanar.js";
import Opcija from "../models/Opcija.js";


export const dodajAnketu = async (req, res) => { //upr
    try
    {
        let upr;
        let zgr;
        try
        {
            upr = await Upravnik.findById(req.params.upravnikId);
        }
        catch(err)
        {
            return res.status(404).json("Upravnik sa tim id-em ne postoji");
        }
        try
        {
            zgr = await Zgrada.findById(req.params.zgradaId);
        }
        catch(err)
        {
            return res.status(404).json("Upravnik sa tim id-em ne postoji");
        }

        const ank = new Anketa({
            upravnikId: upr._id,
            pitanje: req.body.pitanje,
            //opcije: req.body.opcije,
            zgradaId: zgr._id
        })

        const ankSave = await ank.save();
        
        for( let i = 0; i < req.body.opcije.length; i++)
        {
            const opc = new Opcija({
                naziv: req.body.opcije[i],
                anketaId: ank._id
            })
            const opcSave = await opc.save()
            await ankSave.updateOne({$push: {opcije: opcSave}})
        }

        await zgr.updateOne({$push: {ankete: ankSave} });

        return res.status(200).json("Uspešno ste postavili anketu!");
    }
    catch (err)
    {
        return res.status(500).json(err);
    }

}

export const obrisiAnketu = async(req, res)=> {
    try
    {
        let ank;
        let zgr;
        try
        {
            ank = await Anketa.findById(req.params.anketaId);
            console.log(ank)
        }
        catch(err)
        {
            return res.status(404).json("Anketa sa tim id-em ne postoji");
        }
        try
        {
            zgr = await Zgrada.findById(ank.zgradaId)
            console.log(zgr.lokacija)
        }
        catch(err)
        {
            return res.status(404).json("Zgrada sa tim id-em ne postoji");
        }
        console.log("bla")
        await zgr.updateOne({$pull: { ankete: {_id: ank._id } }});
        //console.log(zgr.ankete)
        for( let i = 0; i < ank.opcije.length; i++)
        {
            await Opcija.findByIdAndDelete(ank.opcije[i]._id)
        }
        await Anketa.findByIdAndDelete(ank._id);
        console.log("obrisano")
        return res.status(200).json("Uspešno ste obrisali anketu!");
    
    }
    catch (err) 
    {
        return res.status(500).json(err);
    }
}

export const izmeniAnketu = async(req, res)=> {
    try
    {
        let ank;

        try
        {
            ank = await Anketa.findById(req.params.anketaId);
        }
        catch(err)
        {
            return res.status(404).json("Anketa sa tim id-em ne postoji");
        }
        if(ank != null)
        {
            await ank.updateOne({$set: { pitanje: req.body.pitanje }});
            return res.status(200).json("Uspešno ste izmenili anketu!");
        }
        else
        {
            return res.status(404).json("Anketa sa tim id-em ne postoji")
        }
    
    }
    catch (err) 
    {
        return res.status(500).json(err);
    }
}

export const prikaziAnketeUpravnik = async(req, res)=> {
    try
    {
        let zgr;
        let ankete;

        try
        {
            zgr = await Zgrada.findById(req.params.zgradaId);
        }
        catch(err)
        {
            return res.status(404).json("Zgrada sa tim id-em ne postoji");
        }
        try
        {
            ankete = await Anketa.find({zgradaId: zgr._id});
        }
        catch(err)
        {
            return res.status(404).json("Nema kreiranih anketa u ovoj zgradi");
        }
        
        if (ankete.length != 0)
        {
            
            let vrati = []
            for (let i = 0; i < ankete.length; i++) 
            {
                let proc = [];
                for(let j = 0; j < ankete[i].glasovi.length; j++)
                {
                    const opc = await Opcija.findById(ankete[i].opcije[j]._id)
                    if(ankete[i].brojGlasova != 0)
                    {
                        proc[j] = opc.brojGlasova / ankete[i].brojGlasova * 100
                    }
                    else
                    {
                        proc[j] = 0
                    }
                }
                let ank = 
                {
                    //upravnikId: ankete[i]._id,
                    glasovi: ankete[i].glasovi,
                    opcije: ankete[i].opcije,
                    pitanje: ankete[i].pitanje,
                    brojGlasova: ankete[i].brojGlasova,
                    procenat: proc
                }

                vrati.push(ank)
            }

            return res.status(200).json(vrati)
        }
        else 
        { 
            return res.status(404).json("Nema kreiranih anketa u ovoj zgradi"); 
        }
    }
    catch (err) 
    {
        return res.status(500).json(err);
    }
}

export const prikaziAnketeStanar = async(req, res)=> {
    try
    {
        let zgr;
        let stan;
        let ankete;

        try
        {
            stan = await Stanar.findById(req.params.stanarId);
        }
        catch(err)
        {
            return res.status(404).json("Stanar sa tim id-em ne postoji");
        }
        try
        {
            zgr = await Zgrada.findOne({ lokacija: stan.zgrada});
        }
        catch(err)
        {
            return res.status(404).json("Zgrada sa tim id-em ne postoji");
        }
        try
        {
            ankete = await Anketa.find({ zgradaId: zgr._id });
        }
        catch(err)
        {
            return res.status(404).json("Nema kreiranih anketa u ovoj zgradi");
        }
        console.log(zgr)
        console.log(ankete)

        if (ankete.length != 0)
        {
            let vrati = []
            for (let i = 0; i < ankete.length; i++) 
            {
                let proc = [];
                let glas = null;
                for(let j = 0; j < ankete[i].glasovi.length; j++)
                {
                    const opc = await Opcija.findById(ankete[i].opcije[j]._id)
                    if(ankete[i].brojGlasova != 0)
                    {
                        proc[j] = opc.brojGlasova / ankete[i].brojGlasova * 100
                    }
                    else
                    {
                        proc[j] = 0
                    }                
                }
                for( let k = 0; k < ankete[i].glasovi.length; k++)
                    {
                        let flag = 0;
                        if(ankete[i].glasovi[k].stanarId == req.params.stanarId && flag == 0)
                        {
                            glas = ankete[i].glasovi[k];
                            flag = 1 
                        }
                    }
                let ank = 
                {
                    //upravnikId: ankete[i]._id,
                    glas: glas,
                    opcije: ankete[i].opcije,
                    pitanje: ankete[i].pitanje,
                    brojGlasova: ankete[i].brojGlasova,
                    procenat: proc
                    //procenat
                }

                vrati.push(ank)
            }

            return res.status(200).json(vrati)
        }
        else 
        { 
            return res.status(404).json("Nema kreiranih anketa u ovoj zgradiiiii"); 
        }
    }
    catch (err) 
    {
        return res.status(500).json(err);
    }
}

export default router;