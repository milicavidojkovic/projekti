import express from "express";
const router = express.Router();
import RegistrovaniKorisnik from "../models/RegistrovaniKorisnik.js";
import Saradnik from "../models/Saradnik.js";
import Direktor from "../models/Direktor.js";
import Racun from "../models/Racun.js";
import { generateAccessToken } from "../auth.js";
import { generateRefreshToken } from "../auth.js";

export const dodajSaradnika = async(req, res) =>
{
    try
    {
        const direktor = await Direktor.findById(req.params.id);

        //const salt = await bcrypt.genSalt(10);
        //const hashedPassword = await bcrypt.hash(req.body.password, salt);


        const check = await RegistrovaniKorisnik.find({username: req.body.username});
        //console.log(check)
        if( check.length == 0 )
        {

            const kor = await new RegistrovaniKorisnik({
            ime: req.body.ime,
            prezime: req.body.prezime,
            username: req.body.username,
            password: req.body.password,
            tipKorisnika: "Saradnik"
            });

            const user = await kor.save();

            const saradnik = await new Saradnik({
                registrovaniKorisnikId: user._id,
                imeFirme: req.body.imeFirme,
                telefon: req.body.telefon,
                email: req.body.email,
                direktorId: req.params.id
            })

            const noviSaradnik = await saradnik.save();

            await direktor.updateOne({ $push: { saradnici: noviSaradnik} });        

            return res.status(200).json("Uspešno dodat saradnik");
        }
        else
        {
            return res.status(400).json("Već postoji saradnik sa tim username-om");
        }
    }
    catch(err)
    {
        return res.status(500).json(err);
    }
}

export const vidiSveSaradnike = async(req, res) =>
{
    try
    {
        const saradnik = await Saradnik.find();
        //res.status(200).json(saradnik)
        if (saradnik.length != 0) 
        {
            let saradnici = [];

            for (let i = 0; i < saradnik.length; i++) {
                const t = await RegistrovaniKorisnik.findById(saradnik[i].registrovaniKorisnikId)
                let sar = {
                    saradnikId: saradnik[i]._id, 
                    ime: t?.ime,
                    prezime: t?.prezime,
                    username: t?.username,
                    imeFirme: saradnik[i].imeFirme,
                    telefon: saradnik[i].telefon,
                    email: saradnik[i].email,
                    // registrovaniKorisnikId: saradnik[i].registrovaniKorisnikId
                }


                saradnici.push(sar)
                
            }
            return res.status(200).json(saradnici);
        }

        else {
            return res.status(404).json("Nema saranika za prikaz")
        }
    }
    catch(err)
    {
        return res.status(500).json(err);
    }
}

export const obrisiSaradnika = async(req, res) =>
{
    try
    {
        const saradnik = await Saradnik.findById(req.params.idSaradnika);
        if(saradnik != null)
        {
            const rac = await Racun.find({saradnikId: saradnik._id});
            if(rac!= 0){
                for (let i=0; i<rac.lenght; i++)
                {
                    await Direktor.findbyIdAndUpdate(saradnik.direktorId, {$pull: {racuni: {_id: rac[i]._id}}});
                    await Racun.findByIdAndDelete(rac[i]._id);
                }
            }
            await Direktor.findByIdAndUpdate(saradnik.direktorId, {$pull: {saradnici: {_id: saradnik._id}}})

            await RegistrovaniKorisnik.findByIdAndDelete(saradnik.registrovaniKorisnikId)
            await Saradnik.findByIdAndDelete(saradnik._id);

            return res.status(200).json("Nalog saradnika je obrisan");
        }
        else
        {
            return res.status(404).json("Nema saradnika sa tim ID-em")
        }
    }
    catch(err)
    {
        return res.status(500).json(err);
    }
}

export const azurirajNalogSaradnik = async (req, res) => {

    if (req.body.registrovaniKorisnikId == req.params.id) {
        const regKor = await RegistrovaniKorisnik.findById(req.params.id)
        if(req.body.password == regKor.password)
        {
          // if (req.body.password) {
          //   try 
          //   {
          //     const salt = await bcrypt.genSalt(10);
          //     req.body.password = await bcrypt.hash(req.body.password, salt);
          //   }
          //   catch (err) 
          //   {
          //     return res.status(500).json(err);
          //   }
          // }
          try 
          {
            const sar = await Saradnik.findOne({registrovaniKorisnikId: req.params.id})
            const user = await Saradnik.findByIdAndUpdate(sar._id, {
              $set: { imeFirme: req.body.imeFirme,
                        email: req.body.email,
                        telefon: req.body.telefon }
            });
             return res.status(200).json("Nalog je ažuriran!");
          }
          catch (err) 
          {
            return res.status(500).json(err);
          }
        }
        else
        {
          return res.status(401).json("Netačna lozinka")
        }
      }
      else {
        return res.status(403).json("Možete da izmenite samo svoj nalog");
      }
}

export default router;