import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { Table, Button } from "react-bootstrap";
import useAuth from "../../hooks/useAuth";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { useNavigate } from "react-router";
import SearchBar from "../PomocneKomponente/SearchBar";

export default function Racuni() {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const axiosPrivate = useAxiosPrivate();
  const { user, dispatch } = useAuth();

  const { auth, setAuth } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    const controller = new AbortController();
    getUsers();
    console.log(data);
  }, []);

  const getUsers = async () => {
    try {
      const response = await axiosPrivate.get(
        `http://localhost:8080/api/kvar/prikaziSvePrihvaceneKvaroveSaradnik/${user.saradnikId}`
      );

      setData(response.data);
      setFilteredItems(response.data);
      console.log(response?.data);
    } catch (error) {
      console.error("Error fetching users:", error);
    }
  };
  console.warn(data);
  
  function plati(id) {
    navigate("/DodajRacun", { state: id });
  }

  const [filteredItems, setFilteredItems] = useState([]);

  const handleSearch = (searchQuery) => {
    console.log("searchQuery", searchQuery);

    if (typeof searchQuery !== "string") {
      setFilteredItems(data);
    }
    if (searchQuery === "") {
      setFilteredItems(data);
    }
    if (!searchQuery) {
      setFilteredItems(data);
    } else {
      const filtered = data.filter(
        (item) =>
          item.naslov.toLowerCase().includes(searchQuery.toLowerCase()) ||
          item.zgradaLokacija.toLowerCase().includes(searchQuery.toLowerCase())
      );
      setFilteredItems(filtered);
    }
  };

  return (
    <div>
      <div className="okvir">
        <div className>

          <div className="d-flex justify-content-between align-items-center m-2">
            <h3 className="dodaj-item">Lista kvarova spremnih za naplatu:</h3>
            <SearchBar onSearch={handleSearch} />
          </div>
        </div>

        {data ? (
          <Table reponsive="xl" striped variant="link" size="sm">
            <thead className="border-top">
              <tr>
                <th>Naslov </th>
                <th>Opis</th>
                <th>Lokacija zgrade</th>
                <th>Stan</th>

                <th> </th>
              </tr>
            </thead>
            <tbody>
              {filteredItems?.map((item, i) => (
                <tr
                  key={i}
                  className=" border-left-0 border-right-0 border-secondary "
                >
                  <td>{item.naslov}</td>
                  <td>{item.opis}</td>
                  <td>{item.zgradaLokacija}</td>
                  <td>{item.stan}</td>

                  <td>
                    {" "}
                    <Button variant="dark" onClick={() => plati(item.kvarId)}>
                      Naplati
                    </Button>{" "}
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        ) : (
          <p>Sve usluge su naplaćene...</p>
        )}
      </div>
    </div>
  );
}
