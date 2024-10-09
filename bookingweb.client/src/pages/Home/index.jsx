import Header from '@/component/Header';
import Footer from '@/component/Footer';
import SearchForm from './SearchForm/index.jsx';
import { Container } from 'react-bootstrap';
import PromoSection from './PromoSection/index.jsx';

function Home() {
  return (
    <>
      <Header />
      <Container  style={{
        maxWidth: '1100px',  // Hoặc kích thước bạn muốn
        width: '100%',        // Chiếm toàn bộ chiều rộng
        padding: '15px',      // Padding tùy chỉnh
      }}>
        <SearchForm />
        <PromoSection />
      </Container>
      <Footer />
    </>
  );
}

export default Home;