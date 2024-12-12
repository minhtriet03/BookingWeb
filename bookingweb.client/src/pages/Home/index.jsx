
import SearchForm from '../../component/SearchForm/index.jsx';
import { Container } from 'react-bootstrap';
import PromoSection from './PromoSection/index.jsx';
import PopularRoutes from './PopularRoutes/index.jsx';
// import { useSelector } from 'react-redux';


function Home() {
    
  return (
    <>
    
      <Container  style={{
        maxWidth: '1100px',  // Hoặc kích thước bạn muốn
        width: '100%',        // Chiếm toàn bộ chiều rộng
        padding: '15px',      // Padding tùy chỉnh
        fontFamily:'Arial'
      }}>
        <SearchForm />
        <PromoSection/>
        <PopularRoutes />
      </Container>
     
    </>
  );
}

export default Home;