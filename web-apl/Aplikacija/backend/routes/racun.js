import express from "express";
const router = express.Router();

import { prikaziRacune, platiRacunDirektor, naplatiRacunSaradnik, prikaziDetaljeRacuna} from "../controllers/racun.js";
import { auth, direktorMethod, saradnikMethod} from "../auth.js";

import {upload} from "./auth.js";

//KAKAV ID OVDE TREBA

router.post('/naplatiRacunSaradnik/:saradnikId/:kvarId', auth, saradnikMethod, upload.single('file'), naplatiRacunSaradnik);    //radi
router.delete('/platiRacunDirektor/:direktorId/:racunId', auth, direktorMethod, platiRacunDirektor);    //radi
router.get('/prikaziDetaljeRacuna/:id', auth, direktorMethod, prikaziDetaljeRacuna);   //radi        //je l treba dir method
router.get('/prikaziRacune', auth, direktorMethod, prikaziRacune);   //radi

export default router;