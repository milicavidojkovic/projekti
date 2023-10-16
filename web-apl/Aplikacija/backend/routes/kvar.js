import express from "express";
const router = express.Router();

import { prikaziSveKvaroveStanar, prikaziSveKvaroveDirektor, prikaziSveKvaroveSaradnik, prikaziSvePrihvaceneKvaroveSaradnik, prikaziSveKvaroveUpravnik,
     prijaviKvar, proslediKvarDirektoru, proslediKvarSaradniku, prihvatiKvarSaradnik, odbijKvarSaradnik, odbijKvarUpravnik} from "../controllers/kvar.js";
import {auth, direktorMethod, saradnikMethod, stanarMethod, upravnikMethod} from "../auth.js";
import {upload} from "./auth.js";

router.get('/prikaziSveKvaroveStanar/:id', auth, stanarMethod, prikaziSveKvaroveStanar); //radi
router.get('/prikaziSveKvaroveDirektor/:id', auth, direktorMethod, prikaziSveKvaroveDirektor); //radi
router.get('/prikaziSveKvaroveSaradnik/:id', auth, saradnikMethod, prikaziSveKvaroveSaradnik); //radi
router.get('/prikaziSvePrihvaceneKvaroveSaradnik/:id', auth, saradnikMethod, prikaziSvePrihvaceneKvaroveSaradnik); //radi
router.get('/prikaziSveKvaroveUpravnik/:upravnikId/:zgradaId', auth, upravnikMethod, prikaziSveKvaroveUpravnik); //radi
router.put('/proslediKvarDirektoru/:id', auth, upravnikMethod, proslediKvarDirektoru); //radi - ne menja se u zg kvarovi status kvara
router.put('/proslediKvarSaradniku/:saradnikId/:kvarId', auth, direktorMethod, proslediKvarSaradniku); //radi
router.post('/prijaviKvar/:id', auth, stanarMethod, upload.single('file'), prijaviKvar); //radi
router.put('/prihvatiKvarSaradnik/:kvarId/:saradnikId', auth, saradnikMethod, prihvatiKvarSaradnik); //radi
router.put('/odbijKvarSaradnik/:kvarId/:saradnikId', auth, saradnikMethod, odbijKvarSaradnik); //radi
router.put('/odbijKvarUpravnik/:id', auth, upravnikMethod, odbijKvarUpravnik); //radi

export default router;