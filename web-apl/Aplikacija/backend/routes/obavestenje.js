import express from "express";
const router = express.Router();

import {dodajObavestenjeUpravnik, dodajObavestenjeStanar, obrisiObavestenjeUpravnik, obrisiObavestenjeStanar, prikaziSvaObavestenjaUpravnik, prikaziSvaObavestenjaStanar} from "../controllers/obavestenje.js";
import {auth, stanarMethod, upravnikMethod} from "../auth.js";

import {upload} from "./auth.js";


router.post('/dodajObavestenjeStanar/:id', auth, stanarMethod, upload.single('file'), dodajObavestenjeStanar);  //radi
router.post('/dodajObavestenjeUpravnik/:upravnikId/:zgradaId', auth,  upravnikMethod, upload.single('file'), dodajObavestenjeUpravnik); //radi
router.delete('/obrisiObavestenjeUpravnik/:obavestenjeId/:upravnikId', auth,  upravnikMethod, obrisiObavestenjeUpravnik);   //radi
router.delete('/obrisiObavestenjeStanar/:obavestenjeId/:stanarId', auth, stanarMethod, obrisiObavestenjeStanar);    //radi
router.get('/prikaziSvaObavestenjaStanar/:id', auth, stanarMethod, prikaziSvaObavestenjaStanar);     //radi            
router.get('/prikaziSvaObavestenjaUpravnik/:zgradaId', auth, upravnikMethod, prikaziSvaObavestenjaUpravnik);  //radi              

export default router;