import './Main.css';
import { Button } from 'react-bootstrap';

function ScheduleMain() {
    const data = [
        {
            tuyenXe: 'An Nhơn ⇔ TP. Hồ Chí Minh',
            loaiXe: 'Giường',
            quangDuong: '639km',
            thoiGian: '11 giờ 30 phút',
            giaVe: '---',
        },
        {
            tuyenXe: 'An Nhơn ⇔ TP. Hồ Chí Minh',
            loaiXe: 'Ghế ',
            quangDuong: '639km',
            thoiGian: '11 giờ',
            giaVe: '---',
        },
        {
            tuyenXe: 'Bạc Liêu ⇔ TP. Hồ Chí Minh',
            loaiXe: 'Giường',
            quangDuong: '285km',
            thoiGian: '5 giờ',
            giaVe: '---',
        },
        {
            tuyenXe: 'Bạc Liêu ⇔ TP. Hồ Chí Minh',
            loaiXe: 'Ghế',
            quangDuong: '285km',
            thoiGian: '4 giờ 30 phút',
            giaVe: '---',
          
        },
    ];

    // Nhóm dữ liệu theo tuyenXe
    const groupedData = data.reduce((acc, item) => {
        if (!acc[item.tuyenXe]) {
            acc[item.tuyenXe] = [];
        }
        acc[item.tuyenXe].push(item);
        return acc;
    }, {});
    return (
        <>
            <div className="mt-5 w-100 d-flex flex-column g-4 overflow-auto">
                <div className="row mx-2 schedule-card ">
                    <div className="text-header fw-medium col-3">Tuyến xe</div>
                    <div className="text-header fw-medium col-1">Loại xe</div>
                    <div className="text-header fw-medium col-2">Quãng đường</div>
                    <div className="text-header fw-medium col-2">Thời gian hành trình</div>
                    <div className="text-header fw-medium col-1">Giá vé</div>
                </div>
                {Object.entries(groupedData).map(([tuyenXe, items], groupIndex) => (
                    <div className=" mx-2 my-3 schedule-card" key={groupIndex}>
                        {/* Tiêu đề nhóm */}

                        {/* Lặp qua các chuyến xe */}
                        {items.map((item, index) => (
                            <div className="row my-2" key={index}>
                                <div className="text-header fw-medium col-3">{tuyenXe}</div>
                                <div className="text-header fw-medium col-1">{item.loaiXe}</div>
                                <div className="text-header fw-medium col-2">{item.quangDuong}</div>
                                <div className="text-header fw-medium col-2">{item.thoiGian}</div>
                                <div className="text-header fw-medium col-1">{item.giaVe}</div>
                                <div className="text-header fw-medium col-2 d-flex justify-content-end" style={{flex:'1 1 auto'}}>
                                    <Button variant="">
                                        <span className="fw-bold">Tìm tuyến xe</span>
                                    </Button>
                                </div>
                            </div>
                        ))}
                    </div>
                ))}

            </div>

        </>
    );
}

export default ScheduleMain;