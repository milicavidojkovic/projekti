import React, { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css"
import { Button } from 'react-bootstrap';
import slika from '../../Assets/saradnik2.jpg'
import useAxiosPrivate from '../../hooks/useAxiosPrivate';
import useAuth from '../../hooks/useAuth';
import { useLocation } from 'react-router-dom';

export default function DodajRacun() {

    const podaci = { naziv: "", vrednost: "" };
    //const zgradaDrop = { brStanova: "", lokacija: "", stanari: "", upravnikId: null, kvarovi: {} , zgrada:""};

    const [formValues, setFormValues] = useState(podaci);
    const [formErrors, setFormErrors] = useState({});
    const [isSubmit, setIsSubmit] = useState(false);
    const navigate = useNavigate();
   
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const axiosPrivate = useAxiosPrivate();

    const pom =useLocation();
    const kvarId=pom.state;
    console.log("pom", pom);

    const { user, dispatch } = useAuth();

    const handleChange = (e) => {
        const { name, value } = e.target;
        console.log({ name, value });
        setFormValues({ ...formValues, [name]: value });
        console.log(formValues);

    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setFormErrors(validate(formValues));
        setIsSubmit(true);


    };
    //DORADI!!!!!!!!!!!
    const handleSelect = (e) => {

        const zgradaId = e.target.value;
        console.log(e.target.value);
        // const zgrada = listaZgrade.filter(z => {
        //console.log(z.id);
        //   return (z.id == zgradaId);

        //})
        //console.log(zgrada);
        const { name, value } = e.target;
        console.log({ name, value });
        setFormValues({ ...formValues, [name]: value });
        console.log(formValues);

    };
    useEffect(() => {

        
    }, [])

    useEffect(() => {
        //console.log("iz useEffect: ");
        console.log(formErrors);
        if (Object.keys(formErrors).length === 0 && isSubmit) {
            saveData();
            
            console.log("uspešno")
        }
        else {
            console.log("nije uspešno")
        }
    }, [formErrors]);

    const validate = (values) => {
        const errors = {};
       if (!values.naziv) {
            errors.naziv = "Obavezno polje!";
        }
        if (!values.vrednost) {
            errors.vrednost = "Obavezno polje!";
        }

        return errors;
    };


    const saveData = async () => {
        try {
            console.log(formValues);
            const response = await axiosPrivate.post(`http://localhost:8080/api/racun/naplatiRacunSaradnik/`+user.saradnikId+`/`+kvarId, formValues
            
            );
            navigate("/Racuni")

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
                <h2>Naplati račun SmartWalls kompaniji</h2>

                <div className="forma" >
                    <div className="field">
                        <label className='tekst'>Naziv</label>
                        <br>
                        </br>
                        <input className='input'
                            type="text"
                            name="naziv"
                            placeholder="naziv"
                            value={formValues.naziv}
                            onChange={handleChange}
                        />
                    </div>
                    < p className="upozorenja">{formErrors.naziv}</p>
                    <div className="field">
                        <label className='tekst'>Vrednost</label>
                        <br>
                        </br>
                        <input className='input'
                            type="number"
                            name="vrednost"
                            placeholder="vrednost"
                            value={formValues.vrednost}
                            onChange={handleChange}
                        />
                    </div>
                    < p className="upozorenja">{formErrors.vrednost}</p>
                   



                    <button className="dugme" type='submit'>Naplati</button>
                    <button className="dugme" onClick={() => navigate("/Racuni")}>Nazad</button>


                    {Object.keys(formErrors).length === 0 && isSubmit ? (
                        <p className="upozorenja">Naplata računa je uspešno obavljeno!</p>
                    ) : ""}
                </div>
            </form>
        </div>



    )
}
