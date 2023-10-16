import express from "express";
const router = express.Router();

import { dodajSaradnika, vidiSveSaradnike, obrisiSaradnika, azurirajNalogSaradnik } from "../controllers/saradnik.js";
import { azurirajNalogRegKor } from "../controllers/registrovaniKorisnik.js";
import { auth, direktorMethod, saradnikMethod } from "../auth.js";
import {upload} from "./auth.js";

router.post('/dodajSaradnika/:id', auth, direktorMethod, upload.single('file'), dodajSaradnika); //radi
router.get('/vidiSveSaradnike', auth, direktorMethod, vidiSveSaradnike); //radi
router.delete('/obrisiSaradnika/:idSaradnika', auth, direktorMethod, obrisiSaradnika); //radi
router.put('/azurirajNalogSaradnik/:id', auth, saradnikMethod, azurirajNalogRegKor, azurirajNalogSaradnik);

export default router;