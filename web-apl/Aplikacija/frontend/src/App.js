import "./App.css";
import { Navigate } from "react-router-dom";
import useAuth from "./hooks/useAuth";
import "bootstrap/dist/css/bootstrap.min.css";
import { Route, Routes, BrowserRouter as Router } from "react-router-dom";

import HomeS from "./Components/FirstPage/HomeS";
import RequiredAuth from "./Components/RequiredAuth";
import LoginPage from "./Components/FirstPage/LoginPage";
import HomePage from "./Components/FirstPage/HomePage";
import Error from "./Components/FirstPage/Error";
import Layout from "./Components/FirstPage/Layout";

//stanar
import IzmeniStanara from "./Components/Stanar/IzmeniStanara";
import KvaroviStanar from "./Components/Stanar/KvaroviStanar";
import Stanar from "./Components/Stanar/Stanar";
import AnketeStanar from "./Components/Stanar/AnketeStanar";
import PrijaviKvar from "./Components/Stanar/PrijaviKvar";
import StanarLayout from "./Components/Stanar/StanarLayout";
import ObavestenjaStanar from "./Components/Stanar/ObavestenjaStanar";
import DodajObavestenjeStanar from "./Components/Stanar/DodajObavestenjeStanar";
import PlatiRacun from "./Components/Stanar/PlatiRacun";
//direktor
import NavBarDirektor from "./Components/Direktor/DirektorLayout";
import Direktor from "./Components/Direktor/Direktor";
import IzmeniDirektora from "./Components/Direktor/IzmeniDirektora"
import Saradnici from "./Components/Direktor/Saradnici";
import Upravnici from "./Components/Direktor/Upravnici";
import Dugovanja from "./Components/Direktor/Dugovanja";
import Kvarovi from "./Components/Direktor/Kvarovi";
import DodajSaradnika from "./Components/Direktor/DodajSaradnika";
import PrikazSvihZgrada from "./Components/Direktor/PrikazSvihZgrada";
import DodajUpravnika from "./Components/Direktor/DodajUpravnika";
import PrikazZgradaPoUpravniku from "./Components/Direktor/PrikazZgradaPoUpravniku";
import DirektorLayout from "./Components/Direktor/DirektorLayout";
import PregledZgrada from "./Components/Direktor/PregledZgrada";
import UpravnikLayout from "./Components/Upravnik/UpravnikLayout";

//upravnik
import Upravnik from './Components/Upravnik/Upravnik'
import Zgrade from './Components/Upravnik/Zgrade';
import IzmeniUpravnika from "./Components/Upravnik/IzmeniUpravnika";
import DodajAnketu from "./Components/Upravnik/DodajAnketu";
//import KvaroviUpravnik from './Components/Upravnik/KvaroviUpravnik';
import Ankete from './Components/Upravnik/Ankete';
import OglasnaTabla from './Components/Upravnik/OglasnaTabla'
import PregledStanara from './Components/Upravnik/PregledStanara'
import PregledKvarovaUpravnik from './Components/Upravnik/PregledKvarovaUpravnik';
import DodajStanara from './Components/Upravnik/DodajStanara'
import DodajObavestenje from './Components/Upravnik/DodajObavestenje';
//import ZgradeUpravnikK from "./Components/Upravnik/ZgradeUpravnikK";
import Naplata from "./Components/Upravnik/Naplata";
//Saradnik
import Saradnik from './Components/Saradnik/Saradnik';
import IzmeniSaradnika from "./Components/Saradnik/IzmeniSaradnika";
import KvaroviSaradnik from './Components/Saradnik/KvaroviSaradnik';
import SaradnikLayout from './Components/Saradnik/SaradnikLayout';
import Racuni from "./Components/Saradnik/Racuni";
import DodajRacun from "./Components/Saradnik/DodajRacun";

function App() {
  const { user } = useAuth();
  console.log("App.js:", user);
  return (
    <>
      <Router>
        <Routes>
          {/*public rute*/}
          <Route path="/" element={<Layout />}>
            <Route path="/login" element={<LoginPage />} />
            <Route path="/" element={<HomePage />} />
          </Route>
          {/*zasticene rute, stitimo ih reqAuth*/}
          <Route element={<RequiredAuth allowedRole={"Stanar"} />}>
            <Route path="/" element={<StanarLayout />}>
              <Route path="/Home" element={<HomePage />} />
              <Route path="/Stanar" element={<Stanar />} />
              <Route path="/IzmeniStanara" element={<IzmeniStanara />} />
              <Route path="/KvaroviStanar" element={<KvaroviStanar />} />
              <Route path="/AnketeStanar" element={<AnketeStanar />} />
              <Route path="/PrijaviKvar" element={<PrijaviKvar />} />
              <Route path="/ObavestenjaStanar" element={<ObavestenjaStanar/>}/>
              <Route path="/DodajObavestenjeStanar" element={<DodajObavestenjeStanar/>}/>
              <Route path="/PlatiRacun" element={<PlatiRacun/>}/>
              
            </Route>
          </Route>

          <Route element={<RequiredAuth allowedRole={"Direktor"} />}>
            <Route path="/" element={<DirektorLayout />}>
              <Route path="/Direktor" element={<Direktor />} />
              <Route path="/IzmeniDirektora" element={<IzmeniDirektora />} />
              <Route path="/Saradnici" element={<Saradnici />} />
              <Route path="/Upravnici" element={<Upravnici />} />
              <Route path="/Dugovanja" element={<Dugovanja />} />
              <Route path="/Kvarovi" element={<Kvarovi />} />
              <Route path="/PregledZgrada" element={<PregledZgrada />} />
              <Route path="/DodajSaradnika" element={<DodajSaradnika />} />
              <Route path="/DodajUpravnika" element={<DodajUpravnika />} />
              <Route path="/PrikazSvihZgrada" element={<PrikazSvihZgrada />} />
              <Route
                path="/PrikazZgradaPoUpravniku"
                element={<PrikazZgradaPoUpravniku />}
              />
            </Route>
          </Route>

        

      <Route element={<RequiredAuth allowedRole={"Upravnik"} />}>
        <Route path="/" element={<UpravnikLayout />}>
          <Route path="/Upravnik" element={<Upravnik />} />
          <Route path="/IzmeniUpravnika" element={<IzmeniUpravnika />} />
          <Route path="/Ankete" element={<Ankete />} />
          <Route path="/DodajAnketu" element={<DodajAnketu />} />
          <Route path="/Zgrade" element={<Zgrade />} />
          <Route path="/PregledStanara" element={<PregledStanara />} />
          <Route path="/OglasnaTabla" element={<OglasnaTabla />} />
          <Route path="/PregledKvarovaUpravnik" element={<PregledKvarovaUpravnik />} />
          <Route path="/DodajStanara" element={<DodajStanara />} />
          <Route path="/DodajObavestenje" element={<DodajObavestenje />} />
          <Route path="/HomeU" element={<HomeS />} />
          <Route path="Naplata" element={<Naplata/>}/>
          
         </Route>
      </Route>

      <Route element={<RequiredAuth allowedRole={"Saradnik"} />}>
        <Route path="/" element={<SaradnikLayout />}>
          <Route path="/Saradnik" element={<Saradnik />} />
          <Route path="/IzmeniSaradnika" element={<IzmeniSaradnika />} />
          <Route path="/KvaroviSaradnik" element={<KvaroviSaradnik />} />
          <Route path="/HomeS" element={<HomeS />} />
          <Route path="/Racuni" element={<Racuni />} />
          <Route path="/DodajRacun" element={<DodajRacun />} />

          
         </Route>
      </Route>

      {/*Catch All Errori*/}
      <Route path="*" element={<Error />} />

    </Routes>
    </Router>
    </>
  );
}

export default App;

