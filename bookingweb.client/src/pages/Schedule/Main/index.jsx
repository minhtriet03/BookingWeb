import './Main.css';
import { Button } from 'react-bootstrap';
import { useState, useEffect } from 'react';

function ScheduleMain() {
    const [data, setData] = useState({}); // State để lưu dữ liệu đã nhóm
    const [loading, setLoading] = useState(true); // State để hiển thị trạng thái loading
    const [error, setError] = useState(null); // State để xử lý lỗi

    // Hàm fetch dữ liệu từ API
    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('http://localhost:5108/api/tuyenduong/lichtrinh');
                if (!response.ok) {
                    throw new Error('Lỗi khi tải dữ liệu!');
                }

                const result = await response.json();
                console.log("Dữ liệu từ API:", result);

                // Nhóm dữ liệu theo 'noiDenTinhThanh' (Nơi đến)
                const grouped = result.reduce((acc, item) => {
                    const destination = item.noiDenTinhThanh; // Nơi đến
                    if (!acc[destination]) {
                        acc[destination] = [];
                    }
                    acc[destination].push(item);
                    return acc;
                }, {});

                console.log("Dữ liệu đã nhóm theo nơi đến:", grouped); // In dữ liệu sau khi nhóm
                setData(grouped);
            } catch (err) {
                console.error("Lỗi khi gọi API:", err);
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    // Hiển thị trạng thái loading hoặc lỗi
    if (loading) {
        return <div>Đang tải dữ liệu...</div>;
    }

    if (error) {
        return <div>Lỗi: {error}</div>;
    }

    return (
        <div className="mt-5 w-100 d-flex flex-column g-4 overflow-auto">
            {/* Tiêu đề bảng */}
            <div className="row mx-2 schedule-card">
                <div className="text-header fw-medium col-3">Tuyến xe</div>
                <div className="text-header fw-medium col-2">Loại xe</div>
                <div className="text-header fw-medium col-2">Quãng đường</div>
                <div className="text-header fw-medium col-2">Thời gian hành trình</div>
                <div className="text-header fw-medium col-1">Giá vé</div>
            </div>

            {/* Hiển thị dữ liệu nhóm theo nơi đến */}
            {Object.entries(data).map(([destination, items], groupIndex) => (
                <div className="mx-2 my-3 schedule-card" key={groupIndex}>
                    <div className="row my-2">
                        <div className="text-header fw-medium col-3">{destination}</div>
                    </div>
                    {items.map((item, index) => (
                        <div className="row my-2" key={index}>
                            <div className="text-header fw-medium col-3">{`${item.noiKhoiHanhTinhThanh} - ${item.noiDenTinhThanh}`}</div>
                            <div className="text-header fw-medium col-2">{item.loaiXe}</div>
                            <div className="text-header fw-medium col-2">{item.khoangCach}</div>
                            <div className="text-header fw-medium col-2">{item.tongThoiGian}</div>
                            <div className="text-header fw-medium col-1">--</div>
                            <div className="text-header fw-medium col-2 d-flex justify-content-end">
                                <Button variant="">
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

export default ScheduleMain;
