import React, { useState, useEffect } from "react";
import axios from "axios";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import PieChart from "../PomocneKomponente/PieChart";
import useAuth from "../../hooks/useAuth";
import "bootstrap/dist/css/bootstrap.min.css";

export default function AnketeStanar() {
  const { user, dispatch } = useAuth();
  console.log("user", user);
  const axiosPrivate = useAxiosPrivate();

  useEffect(() => {
    fetchData();
  }, []); //na svaku promenu selectedOption?

  const fetchData = async () => {
    try {
      const response = await axiosPrivate.get(
        `http://localhost:8080/api/anketa/prikaziAnketeStanar/${user.stanarId}`
      );
      
      console.log("ovde", response?.data);
      const fetchedPolls = response.data;
      // Check if the user has already voted for each poll
      const updatedPolls = fetchedPolls.map((poll) => {
        const hasVoted = poll.glas !== null;
        return { ...poll, hasVoted };
      });

      setPolls(updatedPolls);
      console.log("has voted", updatedPolls);
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

  const [polls, setPolls] = useState(null);
  const [selectedOption, setSelectedOption] = useState("");
  const [hasVoted, setHasVoted] = useState(false);
  const [votingResults, setVotingResults] = useState([]);

  const handleOptionClick = (pollIndex, optionIndex, opcija) => {
    setSelectedOption(opcija);

    setPolls((prevPolls) =>
      prevPolls.map((prevPoll, i) =>
        i === pollIndex
          ? {
              ...prevPoll,
              opcije: prevPoll.opcije.map((option, j) =>
                j === optionIndex
                  ? { ...option, selected: true }
                  : { ...option, selected: false }
              ),
            }
          : prevPoll
      )
    );
  };

  const handleVote = async (poll) => {
    try {
      if (poll.hasVoted) {
        console.log("Vec ste glasali.");
        return;
      }

      if (!selectedOption) {
        console.log("Nije selektovana ni jedna opcija.");
        return;
      }

      const anketaId = selectedOption.anketaId;

      const requestBody = {
        opcija: selectedOption,
      };
      console.log("reqBody", requestBody);

      // Make a POST request to submit the vote
      const response = await axiosPrivate.post(
        `http://localhost:8080/api/glas/glasaj/${user.stanarId}/${anketaId}/${selectedOption._id}`,
        requestBody
      );

      if (response.status === 200) {
        console.log("Uspesno glasanje");
        setHasVoted(true);
        fetchData(); // Refresh the poll data after voting
      }
    } catch (error) {
      console.error("Error voting:", error);
    }
  };

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

  if (!user) {
    return <div>Loading...</div>;
  }

  return (
    <section className="py-10">
      <div className="container d-flex justify-content-start mt-3 mx-2">
        {/*za header i buttons*/}
      </div>

      <div className="container px-4 px-lg-1 mt-3">
        <div className="row gx-4 gx-lg-5 row-cols-1 row-cols-md-3 row-cols-xl-4 justify-content-center responsive ">
          {polls ? (
            polls?.map((item, i) => (
              <div className="col mb-5 " key={i}>
                <div className="card h-100 kvar-container">
                  <div className="  card-body  p-2 text-center kvar-item">
                    <h2>{item.pitanje}</h2>
                    <div>
                      <PieChart values={getValues(item)} />
                    </div>
                    <h4>
                      <b>Opcije:</b>
                      <br></br>
                    </h4>
                    {item.opcije.map((option, optionIndex) => (
                      <div key={option.anketaId + option.naziv}>
                        <button
                          key={option.anketaId + option.naziv}
                          className={`option-button ${
                            option._id === item.glas?.opcija &&
                            option.anketaId === item.glas.anketaId
                              ? "selected-disabled"
                              : ""
                          } ${option.selected ? "selected" : ""}`}
                          onClick={() =>
                            handleOptionClick(i, optionIndex, option)
                          }
                          disabled={item.glas !== null}
                        >
                          {option.naziv}
                          <span className="percentage">
                            {item.procenat[optionIndex] == null ? "0" : item.procenat[optionIndex]}%
                          </span>
                        </button>
                      </div>
                    ))}
                    <div>
                      <button
                        className="glasaj-btn"
                        onClick={() => handleVote(item)}
                        disabled={item.glas !== null}
                      >
                        Glasaj
                      </button>
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
    </section>
  );
}
