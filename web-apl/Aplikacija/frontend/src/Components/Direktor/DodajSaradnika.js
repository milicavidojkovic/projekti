import React, { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css"
import { Button } from 'react-bootstrap'; 
import useAuth from '../../hooks/useAuth';
import useAxiosPrivate from '../../hooks/useAxiosPrivate';

import slika from '../../Assets/saradnik2.jpg';

export default function DodajSaradnika() {

    const podaci = { username: "", password: "", ime: "", prezime: "", imeFirme: "",email:"", telefon: null};
    const [formValues, setFormValues] = useState(podaci);
    const [formErrors, setFormErrors] = useState({});
    const [isSubmit, setIsSubmit] = useState(false);
    const navigate = useNavigate();
    const axiosPrivate=useAxiosPrivate();

    const { user, dispatch } = useAuth();

  
    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormValues({ ...formValues, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setFormErrors(validate(formValues));
        setIsSubmit(true);

    };

    useEffect(() => {
        console.log("iz useEffect: ");
        console.log(formErrors);
        if (Object.keys(formErrors).length === 0 && isSubmit) {
            console.log(formValues);
            saveData();
            console.log("uspešno")
            setFormValues(podaci);
        }
        else {
            console.log("nije uspešno")
        }
    }, [formErrors]);

    const validate = (values) => {
        const errors = {};
        const regex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
        const regex2 = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/gmi;
        if (!values.ime) {
            errors.ime = "Obavezno polje!";
        }
        if (!values.prezime) {
            errors.prezime = "Obavezno polje!";
        }
        if (!values.imeFirme) {
            errors.imeFirme = "Obavezno polje!";
        }
        if (!values.username) {
            errors.username = "Obavezno polje!";
        }
        if (!values.email) {
            errors.email = "Obavezno polje!";
        }else if (!regex.test(values.email)) {
            errors.email = "Format nije odgovarajući!";
        }
        if (!values.telefon) {
            errors.telefon = "Obavezno polje";
        } else if (!regex2.test(values.telefon)) {
            errors.telefon = "Format nije odgovarajući!";
        }
        
        if (!values.password) {
            errors.password = "Password is required";
        } else if (values.password.length < 4) {
            errors.password = "Password must be more than 4 characters";
        } else if (values.password.length > 10) {
            errors.password = "Password cannot exceed more than 10 characters";
        }

        return errors;
    };

    const saveData=async()=> {
        try {
            console.log(formValues);
            const response = await axiosPrivate.post(`http://localhost:8080/api/saradnik/dodajSaradnika/`+user.direktorId, formValues);
            
            
          } catch (error) {
            console.error('Error fetching users:', error);
          }
        
        }
       
    


    return (



        <div className="Dodaj" style={{
            backgroundImage: `url(${slika})`,
            backgroundSize: 'cover',
            backgroundRepeat: 'no-repeat',

        }}>
            <form className="" onSubmit={handleSubmit} >
                <h2>Dodaj novog saradnika</h2>

                <div className="forma" >
                    <div className="field">
                        <label className='tekst'>Ime</label>
                        <br>
                        </br>
                        <input className='input'
                            type="text"
                            name="ime"
                            placeholder="ime"
                            value={formValues.ime}
                            onChange={handleChange}
                        />
                    </div>
                    < p className="upozorenja">{formErrors.ime}</p>
                    <div className="field">
                        <label className='tekst'>Prezime</label>
                        <br>
                        </br>
                        <input className='input'
                            type="text"
                            name="prezime"
                            placeholder="prezime"
                            value={formValues.prezime}
                            onChange={handleChange}
                        />
                    </div>
                    < p className="upozorenja">{formErrors.prezime}</p>
                    <div className="field">
                        <label className='tekst'>Korisničko ime</label>
                        <br>
                        </br>
                        <input className='input'
                            type="text"
                            name="username"
                            placeholder="korisničko ime"
                            value={formValues.username}
                            onChange={handleChange}
                        />
                    </div>
                    < p className="upozorenja">{formErrors.username}</p>
                    <div className="field">
                        <label className='tekst'>Šifra</label>
                        <br>
                        </br>
                        <input className='input'
                            type="password"
                            name="password"
                            placeholder="šifra"
                            value={formValues.password}
                            onChange={handleChange}
                        />
                    </div>
                    < p className="upozorenja">{formErrors.password}</p>
                    <div className="field">
                        <label className='tekst'>Ime firme</label>
                        <br>
                        </br>
                        <input className='input'
                            type="text"
                            name="imeFirme"
                            placeholder="ime firme"
                            value={formValues.imeFirme}
                            onChange={handleChange}
                        />
                    </div>
                    < p className="upozorenja">{formErrors.imeFirme}</p>
                    <div className="field">
                        <label className='tekst'>E-mail</label>
                        <br>
                        </br>
                        <input className='input'
                            type="email"
                            name="email"
                            placeholder="e-mail"
                            value={formValues.email}
                            onChange={handleChange}
                        />
                    </div>
                    < p className="upozorenja">{formErrors.email}</p>

                    <div className="field">
                        <label className='tekst'>Telefon</label>
                        <br></br>
                        <input className='input'
                            type="tel"
                            name="telefon"
                            placeholder="telefon"
                            value={formValues.telefon}
                            onChange={handleChange}
                        />
                    </div>
                    <p className="upozorenja">{formErrors.telefon}</p>

                    <button className="dugme">Dodaj</button>
                    <button className="dugme" onClick={() => navigate("/Saradnici")}>Nazad</button>


                    {Object.keys(formErrors).length === 0 && isSubmit ? (
                        <p className="upozorenja">Dodavanje zgrade je uspešno obavljeno!</p>
                    ) : ""}


                </div>
            </form>
        </div>


    )
}
