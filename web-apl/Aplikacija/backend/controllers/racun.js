import express from "express";
const router = express.Router();
import Kvar from "../models/Kvar.js";
import Zgrada from "../models/Zgrada.js";
import Saradnik from "../models/Saradnik.js";
import Direktor from "../models/Direktor.js";
import Racun from "../models/Racun.js";
import Upravnik from "../models/Upravnik.js";
import RegistrovaniKorisnik from "../models/RegistrovaniKorisnik.js";
import Stanar from "../models/Stanar.js";

export const prikaziRacune = async(req, res) =>
{
    try
    {   //je l mi treba ovo
        //const direktor=await Direktor.findById(req.params.direktorId);

        const racuni = await Racun.find();
        //console.log(racuni)
        if (racuni.length != 0) 
        {
            let rac = [];
            for (let i = 0; i < racuni.length; i++) 
            {
                let date_time = racuni[i].datum;
                let day = ("0" + date_time.getDate()).slice(-2);
                let month = ("0" + (date_time.getMonth() + 1)).slice(-2);
                let year = date_time.getFullYear();

                let saradnik = await Saradnik.findById(racuni[i].saradnikId);
                //console.log(saradnik)
                let regSar = await RegistrovaniKorisnik.findById(saradnik.registrovaniKorisnikId);

                let r = {
                    saradnik : regSar.ime + " "+ regSar.prezime,
                    imeFirme: saradnik.imeFirme,
                    racunId: racuni[i]._id,
                    vrednost: racuni[i].vrednost,
                    datum: year + "-" + month + "-" + day,
                    naziv:racuni[i].naziv
                    
                }
                rac.push(r);
                
            }
            return res.status(200).json(rac);
        }

        else {
            return res.status(404).json("Nema računa za prikaz")    //svi su plaćeni
        }
    }
    catch(err)
    {
        return res.status(500).json(err);
    }
    
}

export const platiRacunDirektor = async(req, res) => {
    try
    {
        const direktor=await Direktor.findById(req.params.direktorId);
        const racun= await Racun.findById(req.params.racunId);

        const kvar = await Kvar.findById(racun.kvar);
        console.log(kvar)
        const sarId = racun.saradnikId;
        const saradnik = await Saradnik.findById(sarId);
        console.log(saradnik)
        

        //const kartica= req.body.kartica; //ovde može forma unesite br kartice i on unese te cifre i svaka trans. prođe

        await direktor.updateOne({ $pull: { racuni: racun._id} });
        await saradnik.updateOne({ $pull: {racuni: racun._id} });
        //await stanar.updateOne({$set: { status: "Završen"} }); stavila sam to u naplati
        await Racun.findByIdAndDelete(racun._id);

        return res.status(200).json("Uspešno plaćen račun");

    }
    catch(err)
    {
        return res.status(500).json(err);
    }
}

export const prikaziDetaljeRacuna= async(req, res) =>
{
    try
    {   
        const racun= await Racun.findById(req.params.id);
        
        let date_time = racun.datum;
        let day = ("0" + date_time.getDate()).slice(-2);
        let month = ("0" + (date_time.getMonth() + 1)).slice(-2);
        let year = date_time.getFullYear();

        const kvar = await Kvar.findById(racun.kvar);
        console.log(kvar)

        const saradnik = await Saradnik.findById(kvar.saradnikId);
        //console.log(saradnik)
        const regSar = await RegistrovaniKorisnik.findById(saradnik.registrovaniKorisnikId);
        //console.log(regSar)
        let r = {
            saradnik : regSar.ime + " " + regSar.prezime,
            naziv: racun.naziv,
            vrednost: racun.vrednost,
            zgrada: kvar.zgrada,
            stan: kvar.stan,
            datum:  year + "-" + month + "-" + day
            }
            //console.log(r)
                    
        
        return res.status(200).json(r);

    }
    catch(err)
    {
        return res.status(500).json(err);
    }
    
}

//kvar je popravljen, naplati uslugu, obavesti da je završen
export const naplatiRacunSaradnik = async(req, res)=>{
    try
    {
        const kvar = await Kvar.findById(req.params.kvarId);
        
        //je l nam treba ovo. možda za auth?
        const saradnik = await Saradnik.findById(req.params.saradnikId);

        const racun = new Racun({
            naziv: req.body.naziv,
            vrednost: req.body.vrednost,
            datum: new Date(),
            saradnikId: kvar.saradnikId, //saradnik._id
            kvar: kvar._id
            
        })

        const racunSave = await racun.save();
        const upravnik = await Upravnik.findById(kvar.upravnikId); 
        const direktor = await Direktor.findById(upravnik.direktorId);

        await Direktor.findByIdAndUpdate(direktor._id, {$push: { racuni: racunSave }}); 
        await Saradnik.findByIdAndUpdate(racun.saradnikId, {$push: { racuni: racunSave }}); //saradnik.updateone
        await Saradnik.findByIdAndUpdate(racun.saradnikId, {$pull: { dobijeniKvarovi: {_id: kvar._id }}}); //saradnik.updateone
        await kvar.updateOne({$set: { 'status': "Završen"} })

        return res.status(200).json("Naplatili ste uslugu i poslali račun direktoru");
    }
    catch(err)
    {
        return res.status(500).json(err);
    }
}


export default router;