
import { Card, Form, Container, Row, Col, Button,Navbar, Nav } from 'react-bootstrap';
import './Main.css';


function BookingMain() {
  
  
 
    return (
        <>
            <div className="d-flex flex-column flex-xl-row gap-4 pt-xl-5">
                <div className="header-sticky d-none d-xxl-inline-block">
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
                                    <Form.Check type="checkbox" label="Sáng sớm 00:00 - 06:00 (0)" className="mb-2" />
                                    <Form.Check type="checkbox" label="Buổi sáng 06:00 - 12:00 (3)" className="mb-2" />
                                    <Form.Check type="checkbox" label="Buổi chiều 12:00 - 18:00 (13)" className="mb-2" />
                                    <Form.Check type="checkbox" label="Buổi tối 18:00 - 24:00 (9)" className="mb-2" />
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
                                        <Button variant="outline-secondary" className="py-1 px-3" key={type}>
                                            {type}
                                        </Button>
                                    ))}
                                </div>
                            </Form.Group>
                        </Card.Body>

                        <hr />

                        {/* Hàng ghế */}
                        <Card.Body className="p-3">
                            <Form.Group>
                                <Form.Label>Hàng ghế</Form.Label>
                                <div className="d-flex flex-wrap gap-2 mt-2">
                                    {["Hàng đầu", "Hàng giữa", "Hàng cuối"].map((row) => (
                                        <Button variant="outline-secondary" className="py-1 px-3" key={row}>
                                            {row}
                                        </Button>
                                    ))}
                                </div>
                            </Form.Group>
                        </Card.Body>

                        <hr />

                        {/* Tầng */}
                        <Card.Body className="p-3 pb-4">
                            <Form.Group>
                                <Form.Label>Tầng</Form.Label>
                                <div className="d-flex flex-wrap gap-2 mt-2">
                                    {["Tầng trên", "Tầng dưới"].map((floor) => (
                                        <Button variant="outline-secondary" className="py-1 px-3" key={floor}>
                                            {floor}
                                        </Button>
                                    ))}
                                </div>
                            </Form.Group>
                        </Card.Body>
                    </Card>
                </div>

                <Container fluid className="d-flex flex-column w-100">
                <header className="sticky-top bg-light p-3">
                    <Row className="d-none d-lg-flex">
                        <Col>
                            <h2 className="text-xl font-medium">TP. Hồ Chí Minh - Thừa Thiên - Huế (4)</h2>
                        </Col>
                    </Row>
                    <Row className="d-lg-none align-items-center">
                        <Col className="d-flex justify-content-between">
                            <img src="./images/icons/back.svg" alt="back" style={{ width: '20px' }} />
                            <div className="text-center">
                                <span className="d-block">TP. Hồ Chí Minh - Thừa Thiên - Huế (4)</span>
                                <small className="text-muted">Thứ 7, 09/11</small>
                            </div>
                            <img src="./images/icons/edit_filter.svg" alt="open filter" style={{ width: '20px' }} />
                        </Col>
                    </Row>
                </header>

                <Row className="p-3">
                    <Col className="d-flex gap-3 overflow-auto">
                        <Button variant="outline-warning" className="d-flex align-items-center gap-2">
                            <img src="./images/icons/save_money.svg" alt="icon" width="20" />
                            Giá rẻ bất ngờ
                        </Button>
                        <Button variant="outline-warning" className="d-flex align-items-center gap-2">
                            <img src="./images/icons/clock.svg" alt="icon" width="20" />
                            Giờ khởi hành
                        </Button>
                        <Button variant="outline-secondary" className="d-flex align-items-center gap-2">
                            <img src="./images/icons/seat.svg" alt="icon" width="20" />
                            Ghế trống
                        </Button>
                    </Col>
                </Row>

                <Row className="overflow-auto mb-3">
                    <Card className="mb-3 w-100 border-secondary">
                        <Card.Body>
                                <Row className="d-flex">
                                    {/* First section: align-items-center, takes up 7 columns */}
                                    <Col xs={7} className="d-flex align-items-center">
                                        <h5 className="font-weight-bold">08:30</h5>
                                        <div className="d-flex align-items-center justify-content-center flex-grow-1 mx-3">
                                            <svg
                                                xmlns="http://www.w3.org/2000/svg"
                                                width="16"
                                                height="16"
                                                fill="currentColor"
                                                className="bi bi-circle-fill"
                                                viewBox="0 0 16 16"
                                            >
                                                <circle cx="8" cy="8" r="8" />
                                            </svg>
                                            <span className="flex-1 border-b-2 border-dotted dotted-line"></span>
                                            <span className="text-muted">
                                                22 giờ <small>(Asian/Ho Chi Minh)</small>
                                            </span>
                                            <span className="flex-1 border-b-2 border-dotted dotted-line"></span>
                                            <img
                                                src="./images/icons/station.svg"
                                                alt="station"
                                                className="mx-2"
                                            />
                                        </div>
                                        <h5 className="font-weight-bold">06:30</h5>
                                    </Col>

                                    {/* Second section: mt-2 justify-content-end, takes up 3 columns */}
                                    <Col xs={4} className="mt-2 d-flex flex-column w-full justify-content-end">
                                        <div className="d-flex align-items-end gap-2">
                                            <div className="h-[6px] w-[6px] rounded-full bg-[#C8CCD3]"></div>
                                            <span>Limousine</span>
                                            <div className="h-[6px] w-[10px] rounded-full bg-[#C8CCD3]"></div>
                                            <span className="text-success ">28 chỗ trống</span>
                                          
                                        </div>
                                        <span className="mt-2 text-end text-lg font-semibold text-warning">
                                            470.000đ
                                        </span>
                                    </Col>
                                </Row>

                            <Row className="mt-2">
                                <Col>
                                    <strong>BX Miền Đông Mới</strong>
                                </Col>
                                <Col className="text-right">
                                    <strong>Bến Xe Phía Nam Huế</strong>
                                </Col>
                              </Row>

                        </Card.Body>
                    </Card>
                </Row>
                
            </Container>
            </div>

        </>
    );
}

export default BookingMain;