import React, { useState, useEffect } from 'react'
import "bootstrap/dist/css/bootstrap.min.css"
import { Table, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';

import useAxiosPrivate from '../../hooks/useAxiosPrivate';
import useAuth from '../../hooks/useAuth';

export default function KvaroviSaradnik() {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [count, setCount] = useState(1);
  const axiosPrivate=useAxiosPrivate();

  const [saradnici, setSaradnike] = useState(null);
  const [saradnikId, setSaradnikId]=useState(null);
  const { user, dispatch } = useAuth();
  console.log("user ", user)



  const getUsers = async () => {
    try {
      const response = await axiosPrivate.get(
        `http://localhost:8080/api/kvar/prikaziSveKvaroveSaradnik/` +
          user.saradnikId
      );
      setData(response.data);
      console.log("dobar");
    } catch (error) {
      console.error('Error fetching users:', error);
    }
  };

  useEffect(() => {
    const controller = new AbortController();
    getUsers();
    console.log("saradnik", user.saradnikId);
  }, [data]);

  async function prihvatiKvar(kvarId) {
    try {
      await axiosPrivate.put(
        `http://localhost:8080/api/kvar/prihvatiKvarSaradnik/${kvarId}/${user.saradnikId}`
      );
      getUsers(); // Refresh data after successful update
    } catch (error) {
      console.error('Error fetching users:', error);
    }
  }
  
  async function odbijKvar(kvarId) {
    try {
      await axiosPrivate.put(
        `http://localhost:8080/api/kvar/odbijKvarSaradnik/${kvarId}/${user.saradnikId}`
      );
      getUsers();
    } catch (error) {
      console.error('Error fetching users:', error);
    }
  }
  




       
      
    
   

  return (

    <section className="py-10">


      <div className="container px-4 px-lg-1 mt-5" >

        <div className="row gx-4 gx-lg-5 row-cols-1 row-cols-md-3 row-cols-xl-4 justify-content-center responsive " id='kvarovi' >
          {data ? (data?.map((item, i) => (
            <div className="col mb-5 " key={i}>
              <div className="card h-100 kvar-container">
                <div className="card-body p-2 text-center kvar-item">
                  <div className='kvar-subitem'>
                    <h2>{item.naslov}</h2>
                    <h4><b>Urgentnost:</b><br></br></h4> <p>{item.urgentnost}</p></div>
                  <div className='kvar-subitem'>
                    <p className='text-center'><b>Opis:</b> {item.opis}</p>
                    <p className='text-center'><b>Lokacija:</b> {item.zgradaLokacija}</p>
                    <p className='text-center'><b>Stan:</b> {item.stan}</p>
                  </div>

                </div>
               
                <div className="card-footer p-4 pt-0 border-top-0 bg-transparent kvar-item" >
                  <div className="text-center" ><Button variant='dark' className='mx-2' onClick={()=>prihvatiKvar(item.kvarId)}>Prihvati</Button>
                  <Button variant='dark' className='mx-2' onClick={()=>odbijKvar(item.kvarId)}>Odbij</Button></div>
                </div>
              </div>
            </div>

          ))) : (<p>Trenutno ne postoji nijedan kvar...</p>)}
        </div>

      </div>
    </section>
  )
}
