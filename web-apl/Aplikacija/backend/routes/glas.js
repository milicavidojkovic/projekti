import express from "express";
const router = express.Router();

import { glasaj } from "../controllers/glas.js";
import { auth, stanarMethod } from "../auth.js";

router.post('/glasaj/:stanarId/:anketaId/:opcijaId', auth, stanarMethod, glasaj);

export default router;