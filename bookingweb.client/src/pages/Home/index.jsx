import Header from '../../component/Header';
import Footer from '../../component/Footer';
import SearchForm from './section1/index.jsx';
import { Container } from 'react-bootstrap';

function Home() {
  return (
    <>
      <Header />
      <Container md>
        <SearchForm />
      </Container>
      <Footer />
    </>
  );
}

export default Home;