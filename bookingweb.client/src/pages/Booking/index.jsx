import SearchForm from '../../component/SearchForm/index.jsx';
import { Container } from 'react-bootstrap';
import BookingMain from './Main/index.jsx';
import DatGhe from './DatGhe/index.jsx';
import './booking.css';
import { useState } from 'react';
function Booking() {

    const [display, setDisplay] = useState(true);

    const handleDisplay = () => {
        setDisplay(!display);
    }

    return (
        <>
            <main className="mainContainer">
                <Container style={{
                    maxWidth: '1150px',
                    width: '100%',
                    padding: '15px',
                    fontFamily: 'Arial'
                }}>
                    {display ? <><SearchForm />
                        <BookingMain handleDisplay={handleDisplay} /></> : <DatGhe handleDisplay={handleDisplay} />}
                </Container>
            </main>
        </>
    );
}

export default Booking;