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
        // ... các dữ liệu khác
    ];
    return (
        <>
            <div className="mt-5 w-100 d-flex flex-column g-4 overflow-auto">
                <div className="row mx-2 schedule-card ">
                    <div className="text-header fw-medium col-4">Tuyến xe</div>
                    <div className="text-header fw-medium col-1">Loại xe</div>
                    <div className="text-header fw-medium col-2">Quãng đường</div>
                    <div className="text-header fw-medium col-2">Thời gian hành trình</div>
                    <div className="text-header fw-medium col-1">Giá vé</div>
                </div>
              
                {data.map((item, index) => (
                    <div className="row mx-2 my-3 schedule-card" key={index}>
                        <div className="text-header fw-medium col-4">{item.tuyenXe}</div>
                        <div className="text-header fw-medium col-1">{item.loaiXe}</div>
                        <div className="text-header fw-medium col-2">{item.quangDuong}</div>
                        <div className="text-header fw-medium col-2">{item.thoiGian}</div>
                        <div className="text-header fw-medium col-1">{item.giaVe}</div>
                      
                        <div className="text-header fw-medium col-2 d-flex justify-content-end" style={{flex:'1 1 auto'}}>
                            <Button variant="">
                               <span className ="fw-bold"> Tìm tuyến xe</span>
                            </Button>
                        </div>
                    </div>
                ))}
            </div>

        </>
    );
}

export default ScheduleMain;