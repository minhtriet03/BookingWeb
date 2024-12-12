﻿
import { Card, Form, Container, Row, Col, Button } from 'react-bootstrap';
import './Main.css';
import { useDispatch, useSelector } from 'react-redux';
import { useLocation } from 'react-router-dom';
import { useEffect } from 'react';
import { GetChuyenXe } from '@/redux/actions/ChuyenXeAction';
import { useState } from 'react';
import locationImage from '@/assets/image/location.svg';
import { setChuyenXe } from '@/redux/slices/ChuyenXeSlice';


function BookingMain({ handleDisplay }) { 
  
    const dispatch = useDispatch();
    const [selectedIndex, setSelectedIndex] = useState(); 
    const location = useLocation();
    const queryParams = new URLSearchParams(location.search);
    const noidi = queryParams.get("noidi"); 
    const noiden = queryParams.get("noiden");
    const chuyenXeList = useSelector((state) => state.chuyenxe);
    const ngaydi = queryParams.get("ngaydi");
    const idcxRedux = useSelector((state) => state.chuyenxe.idcx);

    const [filters, setFilters] = useState({
        time: [],
        vehicleType: [],
    });




    const handleRoute = () => {
        handleDisplay();
    }

    const handleCX = (idcx) => {
        dispatch(setChuyenXe(idcx)); // Lưu idcx vào Redux
        console.log("ID chuyến xe được chọn:", idcx);
    }


    useEffect(() => {
        if (noidi && noiden && ngaydi) {
            dispatch(GetChuyenXe({ noidi, noiden, ngaydi }));
        }
    }, [dispatch, noidi, noiden, ngaydi]);


    const chuyenXeData = chuyenXeList?.cxInfo?.$values || [];
    
    const handleSelected = (index) => {
        console.log("selectedIndex", selectedIndex);
        setSelectedIndex(index); 
    };

    const handleTimeFilterChange = (time) => {
        setFilters((prev) => ({
            ...prev,
            time: prev.time.includes(time)
                ? prev.time.filter((t) => t !== time)
                : [...prev.time, time],
        }));
    };

    const handleVehicleTypeFilterChange = (type) => {
        setFilters((prev) => ({
            ...prev,
            vehicleType: prev.vehicleType.includes(type)
                ? prev.vehicleType.filter((t) => t !== type)
                : [...prev.vehicleType, type],
        }));
    };

    const filteredChuyenXeData = chuyenXeData.filter((chuyenXe) => {
        const matchesTime = !filters.time.length || filters.time.some((time) => {
            const startTime = parseInt(chuyenXe.tgkh.split(':')[0]);
            if (time === 'early') return startTime >= 0 && startTime < 6;
            if (time === 'morning') return startTime >= 6 && startTime < 12;
            if (time === 'afternoon') return startTime >= 12 && startTime < 18;
            if (time === 'evening') return startTime >= 18 && startTime < 24;
        });

        const matchesVehicleType = !filters.vehicleType.length || filters.vehicleType.includes(chuyenXe.loaiXe);

        return matchesTime && matchesVehicleType;
    });



    console.log("chuyenxe", chuyenXeList)
 
    return (
        <>
            <div className="d-flex flex-column flex-xl-row gap-4 pt-xl-5">
                <div className="header-sticky d-none d-xxl-inline-block " style={{zIndex:0} }>
                    <Card className="shadow-sm w-100" style={{ maxWidth: '360px', minWidth: '360px', backgroundColor: 'white', fontSize: '15px', fontWeight: '500' }}>

                        {/* Header */}
                        <Card.Header className="d-flex justify-content-between align-items-center p-3">
                            <span className="text-uppercase">Bộ lọc tìm kiếm</span>
                            <div className="d-flex align-items-center gap-2 text-danger" style={{ cursor: 'pointer' }}>
                                Bỏ lọc
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash" viewBox="0 0 16 16">
                                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z" />
                                    <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z" />
                                </svg>
                            </div>
                        </Card.Header>

                        {/* Giờ đi */}
                        <Card.Body className="p-3">
                            <Form.Group>
                                <Form.Label>Giờ đi</Form.Label>
                                <div className="checkbox-group-custom mt-2">
                                    {[
                                        { label: 'Sáng sớm 00:00 - 06:00', value: 'early' },
                                        { label: 'Buổi sáng 06:00 - 12:00', value: 'morning' },
                                        { label: 'Buổi chiều 12:00 - 18:00', value: 'afternoon' },
                                        { label: 'Buổi tối 18:00 - 24:00', value: 'evening' },
                                    ].map((timeOption) => (
                                        <Form.Check
                                            key={timeOption.value}
                                            type="checkbox"
                                            label={timeOption.label}
                                            className="mb-2"
                                            onChange={() => handleTimeFilterChange(timeOption.value)}
                                        />
                                    ))}
                                </div>
                            </Form.Group>
                        </Card.Body>

                        <hr />

                        {/* Loại xe */}
                        <Card.Body className="p-3">
                            <Form.Group>
                                <Form.Label>Loại xe</Form.Label>
                                <div className="d-flex flex-wrap gap-2 mt-2">
                                    {["Ghế", "Giường", "Limousine"].map((type) => (
                                        <Button
                                            variant="outline-secondary"
                                            className={`py-1 px-3 ${filters.vehicleType.includes(type) ? 'active' : ''}`}
                                            key={type}
                                            onClick={() => handleVehicleTypeFilterChange(type)}
                                        >
                                            {type}
                                        </Button>
                                    ))}
                                </div>
                            </Form.Group>
                        </Card.Body>
                    </Card>
                </div>

                <Container fluid className="d-flex flex-column w-100" style={{ zIndex: 0 }}>

                <header className="sticky-top">
                        <Row className="d-none d-lg-flex">
                            <Col className="p-0 bg-light">
                                <h2 className="text-xl font-medium">{noidi} - {noiden} ({chuyenXeData.length})</h2>
                        </Col>
                    </Row>

                </header>


                    <Row className="mb-3">
                        {filteredChuyenXeData.map((chuyenXe, index) => (
                            <Card
                                key={index}
                                className="mb-3 w-100 shadow-light"
                                style={{
                                    //borderColor: selectedIndex === index ? '#F2744E' : '#ddd',
                                    //borderWidth: selectedIndex === index ? '2px' : '1px',
                                    border: selectedIndex === index ? '2px solid #F2744E' : '1px solid #ddd',
                                    boxShadow: selectedIndex === index ? '0 0 10px 0 #F2744E' : 'none',
                                }}
                                onClick={() => handleSelected(index), handleCX(chuyenXe.id) }
                            >
                                <Card.Body>
                                    <Row className="d-flex justify-content-around" >
                                        <Col xs={7} className="d-flex align-items-center">
                                            <h4 className="font-weight-bold">{chuyenXe.tgkh}</h4>
                                            <div className="d-flex align-items-center justify-content-center flex-grow-1 mx-3">
                                                <svg
                                                    xmlns="http://www.w3.org/2000/svg"
                                                    width="16"
                                                    height="16"
                                                    fill="currentColor"
                                                    className="bi bi-circle-fill"
                                                    viewBox="0 0 15 15"
                                                >
                                                    <circle cx="6" cy="6" r="6" />
                                                </svg>
                                                <span className="flex-1 border-b-2 border-dotted dotted-line"></span>
                                                <span className="text-muted">{chuyenXe.tongThoiGian}</span>
                                                <span className="flex-1 border-b-2 border-dotted dotted-line"></span>
                                                <img
                                                    src={locationImage}
                                                    alt="location"
                                                    className="location"
                                                    width={19}
                                                    height={19}
                                                />
                                            </div>
                                            <h4 className="font-weight-bold">{chuyenXe.tgkt}</h4>
                                        </Col>

                                        <Col xs={4} className="mt-2 d-flex flex-column justify-content-end">
                                            <div className="d-flex justify-content-end gap-3">
                                                <span className="fw-bold">{chuyenXe.loaiXe}</span>
                                                <span className="text-success fw-bold">
                                                    {30 - chuyenXe.soLuongVeDaDat} chỗ trống
                                                </span>
                                            </div>
                                            <span className="mt-2 text-end text-lg fw-bold text-danger">
                                                {chuyenXe.giaVe.toLocaleString()} VNĐ
                                            </span>

                                        </Col>
                                    </Row>

                                    <Row className="pl-4">
                                        <Col>
                                            <strong>{chuyenXe.noiKhoiHanhTinhThanh}</strong>
                                        </Col>
                                        <Col className="text-right p-0">
                                            <strong>{chuyenXe.noiDenTinhThanh}</strong>
                                        </Col>
                                    </Row>
                                    <Row xs={3} className="justify-content-end">
                                        <button className="btn_datghe" onClick={handleRoute}> Đặt ghế </button>
                                    </Row>
                                </Card.Body>
                            </Card>
                        ))}
                    </Row>             
            </Container>
            </div>
            
        </>
    );
}

export default BookingMain;