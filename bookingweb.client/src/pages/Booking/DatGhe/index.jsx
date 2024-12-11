import { Container, Row, Col, Alert, Button } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import './datghe.css';
import { createOrder } from '@/apis';
import { useSelector } from 'react-redux';
import RenderSeats from './renderSeats';
import { useNavigate } from 'react-router-dom';
function DatGhe({ handleDisplay }) {

    const legend = [
        { color: "#D5D9DD", label: "Đã đặt" }, // Đã đặt
        { color: "#DEF3FF", label: "Còn trống" }, // Ghế trống
        { color: "#FDEDE8", label: "Đang chọn" }, // Ghế đang chọn
    ];
    const queryParams = new URLSearchParams(window.location.search);
    const navigate = useNavigate();

    const userData = useSelector((state) => state.user);

    const id_chuyenxe = useSelector((state) => state.chuyenxe.idcx);
    const chuyenXeData = useSelector((state) => state.chuyenxe);
    const chuyenXe = chuyenXeData.cxInfo.$values.find((item) => item.$id === id_chuyenxe);

    const ngayXuatBen = queryParams.get("ngaydi");

    const [bookedSeats, setBookedSeats] = useState({});
    const [selectedSeats, setSelectedSeats] = useState({});
    const [selectedSeatCount, setSelectedSeatCount] = useState(0);
    const [showLimitAlert, setShowLimitAlert] = useState(false);
    const [tongTien, setTongTien] = useState(0);

    const handleBack = () => {
        handleDisplay();
    }
    // Xử lý khi nhấn nút trong div khác
    const handleExternalSubmit = (e) => {
        e.preventDefault();
        const { hoTen, email, phone } = userData.userInfo.userInfo;
        if (!hoTen || !phone || !email) {
            alert("Vui lòng cập nhật thông tin cá nhân trước khi thanh toán!");
        } else {
            createOrder(orderData);
            navigate("/thanh-toan");
        }

    };

    useEffect(() => {
        const fetchedBookedSeats = ["A01", "B03", "A06"];
        const bookedSeatsObj = fetchedBookedSeats.reduce((acc, seatId) => {
            acc[seatId] = true;
            return acc;
        }, {});
        setBookedSeats(bookedSeatsObj);
    }, []);

    const handleSeatSelection = (seatId) => {
        if (bookedSeats[seatId]) return;

        if (selectedSeatCount >= 5 && !selectedSeats[seatId]) {
            setShowLimitAlert(true);
            return;
        }

        setSelectedSeats((prev) => {
            const updated = { ...prev, [seatId]: !prev[seatId] };
            const soLuongGhe = Object.values(updated).filter(Boolean).length;
            setSelectedSeatCount(soLuongGhe);
            setTongTien(soLuongGhe * chuyenXe.giaVe);
            setShowLimitAlert(false);
            return updated;
        });
    };

    const selectedSeatIds = Object.keys(selectedSeats).filter(seatId => selectedSeats[seatId]);

    const orderData = {
        idUser: userData.userInfo.userInfo.$id,
        ngayLap: ngayXuatBen,
        tongTien: tongTien,
        trangThai: false,
    }

    return (
        <>
            <button onClick={handleBack}>Quay lại</button>
            <Container className="my-4 ">
                <Row>
                    <Col md={7} className="border bg-white rounded-4 me-3 p-3">
                        <Row className="mt-3 text-sm font-normal px-2">
                            <h5 className="mb-3">Chọn ghế</h5>
                            <Col>
                                <RenderSeats
                                    title="Tầng dưới"
                                    bookedSeats={bookedSeats}
                                    selectedSeats={selectedSeats}
                                    onSeatSelect={handleSeatSelection}
                                />
                            </Col>
                            <Col>
                                <RenderSeats
                                    title="Tầng trên"
                                    bookedSeats={bookedSeats}
                                    selectedSeats={selectedSeats}
                                    onSeatSelect={handleSeatSelection}
                                />
                            </Col>
                            <Row className="h-auto mt-5 text-sm font-normal">
                                {legend.map((item, index) => (
                                    <Col key={index} className="d-flex align-items-center justify-content-center gap-2">
                                        <div className="iconChuThich" style={{ backgroundColor: item.color }}></div>
                                        <span>{item.label}</span>
                                    </Col>
                                ))}
                            </Row>
                        </Row>
                        {/*<Row className="mt-2 w-100 border m-auto" />*/}
                    </Col>
                    <Col>
                        <Row className="border bg-white rounded-4 p-3 mb-1">
                            <Row className="d-flex justify-content-between my-3">
                                <Col xs={8}>
                                    <h5  className=" ">Thông tin khách hàng</h5>
                                </Col>
                                <Col>
                                    <a href={userData.userInfo.$id ? "/thong-tin-ca-nhan" : "/dang-nhap"}>{userData.userInfo.userInfo.$id ? "Cập nhật" : "Đăng nhập"}</a>
                                </Col>
                            </Row>
                            <Row className="d-flex justify-content-between">
                                <Col xs={7} className="text-gray">
                                    Họ và tên:  
                                </Col>
                                <Col className="text-end text-black">
                                    {userData.userInfo.hoTen ? userData.userInfo.userInfo.hoTen : "--"}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={7} className="text-gray">
                                    Số điện thoại:
                                </Col>
                                <Col className="text-end text-black">
                                    {userData.userInfo.phone ? userData.userInfo.userInfo.phone : "--"}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={4} className="text-gray">
                                    Email:
                                </Col>
                                <Col className="text-end text-black">
                                    {userData.userInfo.email ? userData.userInfo.userInfo.email: "--"}
                                </Col>
                            </Row>
                        </Row>
                        <Row className="border bg-white rounded-4 p-3 mb-3">
                            <h5 className="my-3">Thông tin lượt đi</h5>
                            <Row className="d-flex justify-content-between">
                                <Col xs={7} className="text-gray">
                                    Tuyến đường:
                                </Col>
                                <Col className="text-end text-black">
                                    {chuyenXe.noiKhoiHanhTinhThanh} - {chuyenXe.noiDenTinhThanh}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={7} className="text-gray">
                                    Thời gian xuất bến:
                                </Col>
                                <Col  className="text-end text-black">
                                    {ngayXuatBen}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={7} className="text-gray">
                                    Số ghế đã chọn: 
                                </Col>
                                <Col className="text-end text-black">
                                    {selectedSeatCount}
                                </Col>  
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={4} className="text-gray">
                                    Số ghế:
                                </Col>
                                <Col className="text-end text-black">
                                    {selectedSeatCount > 0
                                        ? selectedSeatIds.slice().reverse().join(", ") // Đảo ngược mảng và nối chuỗi
                                        : <div>--</div>}
                                </Col>
                            </Row>

                            <Row className="mt-2 d-flex justify-content-between">
                                {showLimitAlert && (
                                    <Alert variant="danger">
                                        Bạn chỉ có thể chọn tối đa 5 ghế!
                                    </Alert>
                                )}
                            </Row>
                        </Row>
                        <Row className="border bg-white rounded-4 p-3 mb-1">
                            <h5 className="my-3 ">Thông tin giá</h5>
                            <div className="mt-2 d-flex justify-content-between">
                                <h5 className="text-end text-black p-2">
                                    {tongTien} VNĐ
                                </h5>
                                <Button variant="" onClick={handleExternalSubmit}>
                                        Thanh toán
                                </Button>
                            </div>
                        </Row>
                    </Col>
                </Row>
            </Container>
        </>
    );
}
export default DatGhe;