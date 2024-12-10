import { useEffect, useState } from 'react';
import { Form } from 'react-bootstrap';
import axios from 'axios';
import PropTypes from 'prop-types';
import './SelectForm.css';

function SelectForm({ onSelect }) {
    const [tinhThanhList, setTinhThanhList] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTinhThanh = async () => {
            try {
                const response = await axios.get('http://localhost:5108/api/tinh');
                const tinhThanhArray = response.data.$values || [];
                if (Array.isArray(tinhThanhArray)) {
                    setTinhThanhList(tinhThanhArray);
                } else {
                    setError('Dữ liệu không phải là mảng');
                }
            } catch (err) {
                console.error(err);
                setError('Không thể tải dữ liệu.');
            } finally {
                setLoading(false);
            }
        };

        fetchTinhThanh();
    }, []);

    // Hàm xử lý khi chọn một tỉnh thành
    const handleSelectTinh = (tinh) => {
        if (onSelect) {
            onSelect(tinh); // Truyền dữ liệu tỉnh thành đã chọn về parent component
        }
    };

    // Nếu không có `onSelect`, không hiển thị form
    if (!onSelect) {
        return null; // Trả về null để không hiển thị gì
    }

    return (
        <Form className='bg-white'>
            <div className="flex-grow-1 border shadow w-100 rounded position-absolute z-100 bg-white">
              

                {loading && <div className="mt-2 px-2">Đang tải...</div>}
                {error && <div className="mt-2 px-2 text-danger">{error}</div>}

                {/* Hiển thị tất cả các tỉnh thành như một danh sách */}
                {!loading && !error && (
                    <div className="tinh-thanh-list mt-2">
                        {tinhThanhList.map((tinh, index) => (
                            <div
                                key={index}
                                className="tinh-thanh-item"
                                onClick={() => handleSelectTinh(tinh)} // Khi click vào tỉnh thành, gọi handleSelectTinh
                            >
                                {tinh.tenTinhThanh}
                            </div>
                        ))}
                    </div>
                )}
            </div>
        </Form>
    );
}

// Prop validation
SelectForm.propTypes = {
    onSelect: PropTypes.func.isRequired, // Validate that onSelect is a function and required
};

export default SelectForm;
