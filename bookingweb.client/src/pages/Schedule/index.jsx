import { useState, useEffect } from 'react';
import { Container } from 'react-bootstrap';
import axios from 'axios';
import SearchForm from './SearchForm';
import Main from './Main';

function Schedule() {
    const [data, setData] = useState({});
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get('http://localhost:5108/api/tuyenduong/lichtrinh');
                if (response.data && Array.isArray(response.data.$values)) {
                    const dataArray = response.data.$values;

                    const grouped = dataArray.reduce((acc, item) => {
                        const destination = item.noiDenTinhThanh;
                        if (!acc[destination]) {
                            acc[destination] = [];
                        }
                        acc[destination].push(item);
                        return acc;
                    }, {});

                    setData(grouped);
                } else {
                    throw new Error('Dữ liệu không phải là mảng');
                }
            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    if (loading) {
        return <div>Đang tải dữ liệu...</div>;
    }

    if (error) {
        return <div>Lỗi: {error}</div>;
    }

    return (
        <>
            <Container
                style={{
                    maxWidth: '1100px', // Kích thước tối đa
                    width: '100%',     // Chiếm toàn bộ chiều rộng
                    padding: '15px',   // Padding
                    fontFamily: 'Arial'
                }}
            >
                <main className="w-100 h-100">
                    <div className="px-3 py-5">
                        <SearchForm />
                        <Main data={data} />
                    </div>
                </main>
            </Container>
        </>
    );
}

export default Schedule;
