import SearchForm from '../../component/SearchForm/index.jsx';
import { Container } from 'react-bootstrap';
import BookingMain from './Main/index.jsx';
function Booking () {
    return (
        <>
            
            <Container style={{
                maxWidth: '1100px',  
                width: '100%',       
                padding: '15px',     
                fontFamily: 'Arial'
            }}>
                <SearchForm />
                <BookingMain />
            </Container>
        </>
    );
}

export default Booking;