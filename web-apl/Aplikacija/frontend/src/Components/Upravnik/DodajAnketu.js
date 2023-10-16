import React, { useState } from "react";
import slika from "../../Assets/AnketePoz-01.png";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { useLocation, useNavigate } from "react-router";
import useAuth from "../../hooks/useAuth";

export default function DodajAnketu() {
  const pom = useLocation();
  const navigate = useNavigate();
  const { user, dispatch } = useAuth();

  console.log("pom", pom);
  console.log("pop state", pom.state);
  const idZgrade = pom.state.id;
  console.log("id Zgrade iz dodajStanara ", idZgrade);
  const lokacijaZ = pom.state.lokacija;
  const axiosPrivate = useAxiosPrivate();

  const [pitanje, setPitanje] = useState("");
  const [opcije, setOpcije] = useState(["", ""]);

  const handleQuestionChange = (e) => {
    setPitanje(e.target.value);
    console.log("pitanje:", pitanje);
    console.log("opcije:", opcije);
  };

  const handleOptionChange = (index, e) => {
    const updatedOptions = [...opcije];
    updatedOptions[index] = e.target.value;
    setOpcije(updatedOptions);
    console.log("pitanje:", pitanje);
    console.log("opcije:", opcije);
  };

  const handleAddOption = () => {
    if (opcije.length < 7) {
      setOpcije([...opcije, ""]);
    }
  };

  const handleRemoveOption = (index) => {
    if (opcije.length > 2) {
      const updatedOptions = [...opcije];
      updatedOptions.splice(index, 1);
      setOpcije(updatedOptions);
    }
  };

  const saveData = async () => {
    try {
      const body = {
        pitanje: pitanje,
        opcije: opcije,
      };
      console.log("pitanje i opcije", body);

      const response = await axiosPrivate.post(
        `http://localhost:8080/api/anketa/dodajAnketu/${user.upravnikId}/${idZgrade}/`,
        body
      );
    } catch (error) {
      console.error("Error fetching users:", error);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    console.log("pitanje:", pitanje);
    console.log("opcije:", opcije);
    await saveData();
    navigate("/Ankete", {
      state: { id: idZgrade, lokacija: lokacijaZ },
    });
  };

  return (
    <div
      className="Dodaj"
      style={{
        backgroundImage: `url(${slika})`,
        backgroundSize: "cover",
        backgroundRepeat: "no-repeat",
      }}
    >
      <form className="poll-form" onSubmit={handleSubmit}>
        <h2>Dodaj anketu stanarima na lokaciji: {lokacijaZ} </h2>
        <div className=" forma">
          <div className="field">
            <label className="tekst">Pitanje</label>
            <br></br>
            <input
              type="text"
              id="pitanje"
              placeholder="Postavite pitanje"
              className="form-input"
              value={pitanje}
              onChange={handleQuestionChange}
              required
            />
          </div>
        </div>
        <div className="form-group">
          <label>Opcije:</label>
          {opcije.map((option, index) => (
            <div key={index} className="option-container">
              <input
                type="text"
                className={`form-input ${index > 0 ? "added-option" : ""}`}
                placeholder="Opcije"
                value={option}
                onChange={(e) => handleOptionChange(index, e)}
                required
              />
              {index > 1 && (
                <button
                  type="button"
                  className="remove-option-btn"
                  onClick={() => handleRemoveOption(index)}
                >
                  -
                </button>
              )}
            </div>
          ))}
          {opcije.length < 7 && (
            <button
              type="button"
              className="add-option-btn"
              onClick={handleAddOption}
            >
              +
            </button>
          )}
        </div>
        <div className="d-flex justify-content-center">
          <button type="submit" className="dugme">
            Napravi anketu
          </button>
          <button
            className="dugme"
            onClick={() =>
              navigate("/Ankete", {
                state: { id: idZgrade, lokacija: lokacijaZ },
              })
            }
          >
            Nazad
          </button>
        </div>
      </form>
    </div>
  );
}
