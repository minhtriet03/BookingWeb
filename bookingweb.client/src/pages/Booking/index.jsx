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
         
                <Container style={{
                    maxWidth: '1100px',  // Hoặc kích thước bạn muốn
                    width: '100%',        // Chiếm toàn bộ chiều rộng
                    padding: '15px',      // Padding tùy chỉnh
                    fontFamily: 'Arial'
                }}>
                    {display ? <><SearchForm />
                        <BookingMain handleDisplay={handleDisplay} /></> : <DatGhe handleDisplay={handleDisplay} />}
                </Container>
            
        </>
    );
}

export default Booking;