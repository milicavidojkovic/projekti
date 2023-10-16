import React, { useState, useEffect } from 'react'
import "bootstrap/dist/css/bootstrap.min.css"
import { Table, Button } from 'react-bootstrap';
import useAuth from '../../hooks/useAuth';
import useAxiosPrivate from '../../hooks/useAxiosPrivate';

export default function PregledDugovanjaFirme() {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const axiosPrivate = useAxiosPrivate();
  const { user, dispatch } = useAuth();

  const { auth, setAuth } = useAuth();

  useEffect(() => {
    const controller = new AbortController();
    getUsers();
    console.log(data);
  }, [])

  const getUsers = async () => {
    try {
      const response = await axiosPrivate.get("http://localhost:8080/api/racun/prikaziRacune",
        //{
        //  signal:controller.signal
        //}
      );
      setData(response.data);
      console.log(response?.data);
    } catch (error) {
      console.error('Error fetching users:', error);
    }
  }
  console.warn(data);

  function plati(id) {
    try {
      const response = axiosPrivate.delete(`http://localhost:8080/api/racun/platiRacunDirektor/` + user.direktorId + "/" + id,
        {

        }
      );
      getUsers();
    } catch (error) {
      console.error('Error fetching users:', error);
    }

    getUsers();
  }

  function prikaziDetalje(id) {
    try {
      const response = axiosPrivate.get(`http://localhost:8080/api/racun/prikaziDetaljeRacuna/` + id,
      {

      }
      );
      getUsers();
    } catch (error) {
      console.error('Error fetching users:', error);
    }

    getUsers();
  }


  //sortiranje
  const sortMostRecent = () => {
    const sortedItems = [...data].sort((a, b) => new Date(b.datum) - new Date(a.datum));
    setData(sortedItems);
  };

  const sortLeastRecent = () => {
    const sortedItems = [...data].sort((a, b) => new Date(a.datum) - new Date(b.datum));
    setData(sortedItems);
  };


  return (
    <div >
      <div className="border rounded-sm " >
        <div className="mx-1 mb-2 mt-1">
          <div className="d-flex justify-content-between align-items-center">
            <h3 className="dodaj-item" >Lista dugovanja:  </h3>
            <div className="d-flex justify-content-start mx-2">
              <button className="button button-all" onClick={sortMostRecent}>Najnoviji</button>
              <button className="button button-all" onClick={sortLeastRecent}>Najstariji</button>
            </div>
          </div>


        </div>
        {data ? (
          <Table reponsive='xl' striped variant='link' size="sm">
            <thead className="border-top">
              <tr>

                <th>Firma Saradnik</th>
                <th>Ime i Prezime</th>
                <th>Naziv</th>
                <th>Datum</th>
                <th>Iznos</th>

                <th>  </th>
              </tr>
            </thead>
            <tbody >
              {data?.map((item, i) => (

                <tr key={i} className=" border-left-0 border-right-0 border-secondary ">


                  <td>{item.imeFirme}</td>
                  <td>{item.saradnik}</td>
                  <td>{item.naziv}</td>
                  <td>{item.datum}</td>
                  <td>{item.vrednost}</td>

                  <td> <Button variant='dark' onClick={() => plati(item.racunId)}>Plati</Button> </td>

                </tr>

              ))}


            </tbody>
          </Table>
        ) : (
          <p>Loading...</p>
        )}


      </div>





    </div>)
}
