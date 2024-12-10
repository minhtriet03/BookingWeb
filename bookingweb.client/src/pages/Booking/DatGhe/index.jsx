﻿import { Container, Row, Col, Alert, Button } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import './datghe.css';
import { useSelector } from 'react-redux';
import RenderSeats from './renderSeats';
import { useNavigate } from 'react-router-dom';
function DatGhe({ handleDisplay }) {
    const userData = useSelector((state) => state.user);
    const navigate = useNavigate();
    const legend = [
        { color: "#D5D9DD", label: "Đã đặt" }, // Đã đặt
        { color: "#DEF3FF", label: "Còn trống" }, // Ghế trống
        { color: "#FDEDE8", label: "Đang chọn" }, // Ghế đang chọn
    ];
    const [selectedSeats, setSelectedSeats] = useState({});
    const [bookedSeats, setBookedSeats] = useState({});
    const [selectedSeatCount, setSelectedSeatCount] = useState(0);
    const [showLimitAlert, setShowLimitAlert] = useState(false);

    const chuyenXeList = useSelector((state) => state.chuyenxe);

    console.log("cxl",chuyenXeList);


    const handleBack = () => {
        handleDisplay();
    }
    // Xử lý khi nhấn nút trong div khác
    const handleExternalSubmit = (e) => {
        //if (validate()) {
            e.preventDefault();
            alert("Biểu mẫu hợp lệ!");
            navigate("/thanh-toan");
        //}
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
            setSelectedSeatCount(Object.values(updated).filter(Boolean).length);
            setShowLimitAlert(false);
            return updated;
        });
    };

    const selectedSeatIds = Object.keys(selectedSeats).filter(seatId => selectedSeats[seatId]);

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
                                <Col xs={9}>
                                    <h5  className=" ">Thông tin khách hàng</h5>
                                </Col>
                                <Col>
                                    <a href="/thong-tin-ca-nhan">Chỉnh sửa</a>
                                </Col>
                            </Row>
                            <Row className="d-flex justify-content-between">
                                <Col xs={4} className="text-gray">
                                    Họ và tên:
                                </Col>
                                <Col xs={8} className="text-end text-black">
                                    {userData.userInfo.hoTen ? userData.userInfo.hoTen : "--"}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={5} className="text-gray">
                                    Số điện thoại:
                                </Col>
                                <Col xs={7} className="text-end text-black">
                                    {userData.userInfo.phone ? userData.userInfo.phone : "--"}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={5} className="text-gray">
                                    Email:
                                </Col>
                                <Col xs={7} className="text-end text-black">
                                    {userData.userInfo.email ? userData.userInfo.email: "--"}
                                </Col>
                            </Row>
                        </Row>
                        <Row className="border bg-white rounded-4 p-3 mb-3">
                            <h5 className="my-3">Thông tin lượt đi</h5>
                            <Row className="d-flex justify-content-between">
                                <Col xs={4} className="text-gray">
                                    Tuyến xe:
                                </Col>
                                <Col xs={8} className="text-end text-black">
                                    Long Xuyên - Miền Tây
                                    {/*{Noi_KhoiHanh || ''} - {Noi_Den || ''}*/}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={5} className="text-gray">
                                    Thời gian xuất bến:
                                </Col>
                                <Col xs={7} className="text-end text-black">
                                    00:00 01/01/2024 {/*{Noi_KhoiHanh || ''} - {Noi_Den || ''}*/}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={5} className="text-gray">
                                    Số ghế đã chọn: 
                                </Col>
                                <Col xs={7} className="text-end text-black">
                                    {selectedSeatCount}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={5} className="text-gray">
                                    Số ghế:
                                </Col>
                                <Col xs={7} className="text-end text-black">
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
                                    190.000đ
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