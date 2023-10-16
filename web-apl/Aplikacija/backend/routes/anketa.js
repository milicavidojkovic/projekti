import express from "express";
const router = express.Router();

import { dodajAnketu, obrisiAnketu, izmeniAnketu, prikaziAnketeUpravnik, prikaziAnketeStanar } from "../controllers/anketa.js";
import { upravnikMethod, auth, stanarMethod } from "../auth.js";

router.put('/izmeniAnketu/:anketaId', auth, upravnikMethod, izmeniAnketu); //radi
router.post('/dodajAnketu/:upravnikId/:zgradaId', auth, upravnikMethod, dodajAnketu); //radi
router.delete('/obrisiAnketu/:anketaId', auth, upravnikMethod, obrisiAnketu); //radi
router.get('/prikaziAnketeUpravnik/:zgradaId', auth, upravnikMethod, prikaziAnketeUpravnik); //radi
router.get('/prikaziAnketeStanar/:stanarId', auth, stanarMethod, prikaziAnketeStanar);

export default router;