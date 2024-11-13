

import { Container } from 'react-bootstrap';
import SearchForm from './SearchForm';
import Main from './Main';
function Schedule() {
    return (
            <>
  
      <Container  style={{
        maxWidth: '1100px',  // Hoặc kích thước bạn muốn
        width: '100%',        // Chiếm toàn bộ chiều rộng
        padding: '15px',      // Padding tùy chỉnh
        fontFamily:'Arial'
      }}>
                <main className="w-100 h-100">
                    <div className="px-3 py-5">
                        <SearchForm />
                        <Main />
                    </div>
                </main>
      </Container>

    </>
       
       
  );
}

export default Schedule;