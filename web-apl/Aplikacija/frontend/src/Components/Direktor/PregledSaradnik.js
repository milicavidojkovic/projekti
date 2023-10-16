import React, { useState, useEffect } from 'react'
import "bootstrap/dist/css/bootstrap.min.css"
import { Table, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import DodajSaradnika from './DodajSaradnika';
import SearchBar from '../PomocneKomponente/SearchBar';
import { useNavigate } from 'react-router-dom';
import useAxiosPrivate from '../../hooks/useAxiosPrivate';
import useAuth from '../../hooks/useAuth';

export default function PregledSaradnik() {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [count, setCount] = useState(1);
    const axiosPrivate = useAxiosPrivate();
    const navigate = useNavigate();
    const { user, dispatch } = useAuth();
    console.log("ovo je auth")

    useEffect(() => {
        const controller = new AbortController();
        getUsers();
        console.log(data);
    }, [])

    const getUsers = async () => {
        try {
            const response = await axiosPrivate.get("http://localhost:8080/api/saradnik/vidiSveSaradnike",
                //const response = await axiosPrivate.get("http://localhost:8000/saradnik",

            );
            setData(response.data);
            setFilteredItems(response.data);
            console.log(response?.data);
        } catch (error) {
            console.error('Error fetching users:', error);
        }
    }
    //console.warn(data);
    const obrisiSaradnika = async (id) => {
        console.log(id)
        await axiosPrivate.delete('http://localhost:8080/api/saradnik/obrisiSaradnika/' + id)
            .then(p => {
                if (p.status === 200) {
                    
                    getUsers();
                }
            }).catch((error) => {
                alert('Doslo je do greske prilikom brisanja')
            });

    }

    const [filteredItems, setFilteredItems] = useState([]);

    const handleSearch = (searchQuery) => {

        console.log("searchQuery", searchQuery);

        if (typeof searchQuery !== 'string') {
            setFilteredItems(data);
        }
        if (searchQuery === '') {
            setFilteredItems(data);
        }
        if (!searchQuery) {
            setFilteredItems(data);
        }
        else {
            const filtered = data.filter((item) =>
                item.ime.toLowerCase().includes(searchQuery.toLowerCase()) ||
                item.prezime.toLowerCase().includes(searchQuery.toLowerCase()) ||
                item.imeFirme.toLowerCase().includes(searchQuery.toLowerCase()) ||
                item.telefon.toString().toLowerCase().includes(searchQuery.toLowerCase())
            );
            setFilteredItems(filtered);
        }
    }



    return (
        <div >
            <div className="okvir" >
                <div className>

                    <div className='d-flex justify-content-between align-items-center m-2'>
                        <h3 className="dodaj-item" >Lista saradnika:  </h3>
                        <SearchBar onSearch={handleSearch} />

                    </div>

                </div>


                {data ? (
                    <Table reponsive='xl' striped variant='link' size="sm">
                        <thead className="border-top">
                            <tr>

                                <th>Ime </th>
                                <th>Prezime</th>
                                <th>Korisnicko ime</th>
                                <th>Ime Firme</th>
                                <th>Broj telefona</th>
                                <th>E-mail</th>
                                <th>  </th>
                            </tr>
                        </thead>
                        <tbody >
                            {filteredItems.map((item, i) => (

                                <tr key={i} className=" border-left-0 border-right-0 border-secondary ">


                                    <td>{item.ime}</td>
                                    <td>{item.prezime}</td>
                                    <td>{item.username}</td>
                                    <td>{item.imeFirme}</td>
                                    <td>{item.telefon}</td>
                                    <td>{item.email}</td>
                                    <td><Button variant='dark' onClick={() => obrisiSaradnika(item.saradnikId)}>Izbrisi</Button> </td>

                                </tr>

                            ))}
                            <tr>
                                <td>  </td>
                                <td>  </td>
                                <td>  </td>
                                <td>  </td>
                                <td>  </td>
                                <td>  </td>
                                <td><Button className="btn btn-outline-dark" variant="outlined" onClick={() => navigate("/DodajSaradnika")}><b>Dodaj</b></Button></td>
                            </tr>


                        </tbody>
                    </Table>
                ) : (
                    <p>Loading...</p>
                )}


            </div>





        </div>)

}