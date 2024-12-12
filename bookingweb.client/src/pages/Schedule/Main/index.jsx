import './Main.css';
import { Button } from 'react-bootstrap';
import PropTypes from 'prop-types'; // Import PropTypes
import { useNavigate } from 'react-router-dom'; // Import useNavigate hook

function Main({ data }) {
    const navigate = useNavigate(); // Khởi tạo navigate hook

    const handleFindRoute = (noidi, noiden) => {
        const ngaydi = new Date().toISOString().split('T')[0]; // Lấy ngày hiện tại
        navigate(`/dat-ve?noidi=${noidi}&noiden=${noiden}&ngaydi=${ngaydi}`); // Chuyển trang
    };

    return (
        <div className="mt-5 w-100 d-flex flex-column g-4 overflow-auto">
            <div className="row mx-2 schedule-card">
                <div className="text-header fw-medium col-3">Tuyến xe</div>
                <div className="text-header fw-medium col-1">Loại xe</div>
                <div className="text-header fw-medium col-2">Quãng đường</div>
                <div className="text-header fw-medium col-2">Thời gian hành trình</div>
                <div className="text-header fw-medium col-1">Giá vé</div>
            </div>

            {Object.entries(data).map(([destination, items], groupIndex) => (
                <div className="mx-2 my-3 schedule-card" key={groupIndex}>
                    <div className="row my-2">
                        <div className="text-header fw-medium col-3">{destination}</div>
                    </div>
                    {items.map((item, index) => (
                        <div className="row my-2" key={index}>
                            <div className="text-header fw-medium col-3">{`${item.noiKhoiHanhTinhThanh} - ${item.noiDenTinhThanh}`}</div>
                            <div className="text-header fw-medium col-1">{item.loaiXe}</div>
                            <div className="text-header fw-medium col-2">{item.khoangCach}</div>
                            <div className="text-header fw-medium col-2">{item.tongThoiGian}</div>
                            <div className="text-header fw-medium col-1">--</div>
                            <div className="text-header fw-medium col-2 d-flex justify-content-end">
                                <Button variant="" onClick={() => handleFindRoute(item.noiKhoiHanhTinhThanh, item.noiDenTinhThanh)}>
                                    <span className="fw-bold">Tìm tuyến xe</span>
                                </Button>
                            </div>
                        </div>
                    ))}
                </div>
            ))}
        </div>
    );
}

// Khai báo PropTypes
Main.propTypes = {
    data: PropTypes.object.isRequired, // Yêu cầu prop data phải là object
};

export default Main;