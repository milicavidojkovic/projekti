import React, { useState, useEffect } from "react";
import axios from "axios";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Button } from "react-bootstrap";
import { Link, useLocation, useNavigate } from "react-router-dom";
import PieChart from "../PomocneKomponente/PieChart";
import useAuth from "../../hooks/useAuth";
import "bootstrap/dist/css/bootstrap.min.css";
import DeleteOutlineIcon from "@mui/icons-material/DeleteOutline";

export default function Ankete() {
  const navigate = useNavigate();
  const idZgrade = useLocation().state.id;
  const lokacija = useLocation().state.lokacija;

  function DodajAnketu() {
    console.log(idZgrade);
    navigate("/DodajAnketu", { state: { id: idZgrade, lokacija: lokacija } });
  }

  const { user, dispatch } = useAuth();
  const axiosPrivate = useAxiosPrivate();

  useEffect(() => {
    fetchData();
    const interval = setInterval(fetchData, 20000);

    return () => {
      clearInterval(interval);
    };
  }, []);

  const fetchData = async () => {
    try {
      const response = await axiosPrivate.get(
        `http://localhost:8080/api/anketa/prikaziAnketeUpravnik/${idZgrade}`
      );
      setPolls(response.data);
      //console.log("polls", polls);
    } catch (error) {
      console.error("Error fetching ankete:", error);
    }
  };

  //stvari za poll i glasanje
  //boje: ljub plava zelena tamnoplava vanila tirkizna lila
  const colors = [
    "#CEACE0",
    "#7CD8FF",
    "#8ADB96",
    "#8191E2",
    "#FFEDAB",
    "#5ACFBA",
    "#CEBEFF",
  ];

  const [polls, setPolls] = useState();
  const [selectedOption, setSelectedOption] = useState("");
  const [hasVoted, setHasVoted] = useState(false);
  const [votingResults, setVotingResults] = useState([]);

  const getValues = (poll) => {
    console.log("procentici", poll.opcije);
    if (!poll || !poll.opcije) {
      return [];
    }
    //poll.procenat[i]!=null ? poll.procenat[i] : 0,
    const values = poll.opcije.map((option, i) => ({
      percentage: poll.procenat[i] != null ? poll.procenat[i] : 0,
      color: colors[i % colors.length],
      label: option.naziv,
    }));

    console.log("values", values);
    return values;
  };

  const handleDelete = async (pollId) => {
    console.log('polllllid',pollId);
    try {
      await axiosPrivate.delete(`http://localhost:8080/api/anketa/obrisiAnketu/${pollId}`);
      fetchData();
    } catch (error) {
      console.error("Error deleting anketa:", error);
    }
  };

  if (!user) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <div className="border rounded-sm mx-1 ">
        <div className="dodaj-deo">
          <h3 className="dodaj-item">Ankete</h3>
          <Button
            variant="dark"
            className="dugme"
            onClick={() => DodajAnketu()}
          >
            Dodaj anketu
          </Button>
        </div>
      </div>

      <div className="container px-4 px-lg-1 mt-3">
        <div className="row gx-4 gx-lg-5 row-cols-1 row-cols-md-3 row-cols-xl-4 justify-content-center responsive ">
          {console.log("polls u ret", polls)}
          {polls ? (
            polls?.map((item, i) => (
              <div className="col mb-5" key={i}>
                <div className="card h-100 kvar-container">
                
                  <div className="">
                    <div className=" card-body d-flex-column flex-column p-2 text-center kvar-item">
                    <div className="delete-icon" onClick={() => handleDelete(item.opcije[0].anketaId)}>
                      <DeleteOutlineIcon size="large"/>
                    </div>
                      <h2>{item.pitanje}</h2>
                      <div>
                        <PieChart values={getValues(item)} />
                      </div>
                      <div>
                        <h4>
                          <b>Opcije:</b>
                          <br></br>
                        </h4>
                      </div>
                      {item.opcije ? (
                        item.opcije.map((option, i) => (
                          <div
                            className=""
                            key={option.anketaId + option.naziv}
                          >
                            <button
                              key={option.anketaId + option.naziv}
                              className="option-button"
                              disabled
                            >
                              {option.naziv}
                              <span className="percentage">
                                {item.procenat[i] == null
                                  ? "0"
                                  : item.procenat[i]}
                                %
                              </span>
                            </button>
                          </div>
                        ))
                      ) : (
                        <p>Loading ...</p>
                      )}
                    </div>
                  </div>
                </div>
              </div>
            ))
          ) : (
            <p>Loading...</p>
          )}
        </div>
      </div>
    </div>
  );
}
