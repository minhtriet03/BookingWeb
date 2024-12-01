import { Container, Row, Col, Table, OverlayTrigger,Tooltip,Image } from 'react-bootstrap';
function DatGhe({ handleDisplay }) {
        const lowerSeats = [
            { id: "A01", status: "active" },
            { id: "A02", status: "active" },
            { id: "A03", status: "active" },
            { id: "A04", status: "active" },
            { id: "A05", status: "active" },
            { id: "A06", status: "active" },
            { id: "A07", status: "active" },
            { id: "A08", status: "active" },
            { id: "A09", status: "active" },
            { id: "A10", status: "active" },
            { id: "A11", status: "active" },
            { id: "A12", status: "active" },
            { id: "A13", status: "active" },
            { id: "A14", status: "active" },
            { id: "A15", status: "active" },
            { id: "A16", status: "active" },
            { id: "A17", status: "active" },
        ];

        const upperSeats = [
            { id: "B01", status: "active" },
            { id: "B02", status: "active" },
            { id: "B03", status: "active" },
            { id: "B04", status: "active" },
            { id: "B05", status: "active" },
            { id: "B06", status: "active" },
            { id: "B07", status: "active" },
            { id: "B08", status: "active" },
            { id: "B09", status: "active" },
            { id: "B10", status: "active" },
            { id: "B11", status: "active" },
            { id: "B12", status: "active" },
            { id: "B13", status: "active" },
            { id: "B14", status: "active" },
            { id: "B15", status: "active" },
            { id: "B16", status: "active" },
            { id: "B17", status: "active" },
        ];

        const legend = [
            { color: "#D5D9DD", label: "Đã bán" },
            { color: "#DEF3FF", label: "Còn trống" },
            { color: "#FDEDE8", label: "Đang chọn" },
        ];
    const handleBack = () => {
        handleDisplay();
    }

    return (
        <>
            <button onClick={handleBack}>Quay lại</button>
            <Container className="my-4 ">
                <Row className="">
                    <Col md={8} className="border bg-white rounded-4 me-3 p-3">
                        {/* Cột chọn ghế */}
                        <h5>Chọn ghế </h5>
                        <Row className="mt-4 text-sm font-normal p-3">
                            <Table  className="seatTable">
                                <thead>
                                    <tr>
                                        <th colSpan="3">Tầng dưới</th>
                                        <th colSpan="3">Tầng trên</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td className="justify-content-center align-items-center" style={{ position: 'relative' }}>
                                            <div className="position-relative d-flex justify-content-center align-items-center">
                                                <Image width={32} src="https://futabus.vn/images/icons/seat_active.svg" alt="seat icon" />
                                                <span
                                                    className="position-absolute"
                                                    style={{
                                                        fontSize: '10px',
                                                        fontWeight: '600',
                                                        color: '#A2ABB3',
                                                        top: '50%',
                                                        left: '50%',
                                                        transform: 'translate(-50%, -50%)',
                                                        cursor: 'default'
                                                    }}
                                                >
                                                    A01
                                                </span>
                                            </div>
                                        </td>
                                        <td className="justify-content-center align-items-center" style={{ position: 'relative' }}>
                                            <div className="position-relative d-flex justify-content-center align-items-center">
                                                <Image width={32} src="https://futabus.vn/images/icons/seat_active.svg" alt="seat icon" />
                                                <span
                                                    className="position-absolute"
                                                    style={{
                                                        fontSize: '10px',
                                                        fontWeight: '600',
                                                        color: '#A2ABB3',
                                                        top: '50%',
                                                        left: '50%',
                                                        transform: 'translate(-50%, -50%)',
                                                        cursor: 'default'
                                                    }}
                                                >
                                                    A01
                                                </span>
                                            </div>
                                        </td>
                                        <td className="justify-content-center align-items-center" style={{ position: 'relative' }}>
                                            <div className="position-relative d-flex justify-content-center align-items-center">
                                                <Image width={32} src="https://futabus.vn/images/icons/seat_active.svg" alt="seat icon" />
                                                <span
                                                    className="position-absolute"
                                                    style={{
                                                        fontSize: '10px',
                                                        fontWeight: '600',
                                                        color: '#A2ABB3',
                                                        top: '50%',
                                                        left: '50%',
                                                        transform: 'translate(-50%, -50%)',
                                                        cursor: 'default'
                                                    }}
                                                >
                                                    A01
                                                </span>
                                            </div>
                                        </td>
                                        <td className="justify-content-center align-items-center" style={{ position: 'relative' }}>
                                            <div className="position-relative d-flex justify-content-center align-items-center">
                                                <Image width={32} src="https://futabus.vn/images/icons/seat_active.svg" alt="seat icon" />
                                                <span
                                                    className="position-absolute"
                                                    style={{
                                                        fontSize: '10px',
                                                        fontWeight: '600',
                                                        color: '#A2ABB3',
                                                        top: '50%',
                                                        left: '50%',
                                                        transform: 'translate(-50%, -50%)',
                                                        cursor: 'default'
                                                    }}
                                                >
                                                    A01
                                                </span>
                                            </div>
                                        </td>
                                        <td className="justify-content-center align-items-center" style={{ position: 'relative' }}>
                                            <div className="position-relative d-flex justify-content-center align-items-center">
                                                <Image width={32} src="https://futabus.vn/images/icons/seat_active.svg" alt="seat icon" />
                                                <span
                                                    className="position-absolute"
                                                    style={{
                                                        fontSize: '10px',
                                                        fontWeight: '600',
                                                        color: '#A2ABB3',
                                                        top: '50%',
                                                        left: '50%',
                                                        transform: 'translate(-50%, -50%)',
                                                        cursor: 'default'
                                                    }}
                                                >
                                                    A01
                                                </span>
                                            </div>
                                        </td>
                                        <td className="justify-content-center align-items-center" style={{ position: 'relative' }}>
                                            <div className="position-relative d-flex justify-content-center align-items-center">
                                                <Image width={32} src="https://futabus.vn/images/icons/seat_active.svg" alt="seat icon" />
                                                <span
                                                    className="position-absolute"
                                                    style={{
                                                        fontSize: '10px',
                                                        fontWeight: '600',
                                                        color: '#A2ABB3',
                                                        top: '50%',
                                                        left: '50%',
                                                        transform: 'translate(-50%, -50%)',
                                                        cursor: 'default'
                                                    }}
                                                >
                                                    A01
                                                </span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        { }
                                    </tr>
                                </tbody>
                            </Table>
                        </Row>
                        {/* Legend */}
                        <Row className="mt-4 text-sm font-normal">
                            {legend.map((item, index) => (
                                <Col key={index} className="d-flex align-items-center justify-content-center gap-2">
                                    <div
                                        style={{
                                            width: "16px",
                                            height: "16px",
                                            backgroundColor: item.color,
                                            borderRadius: "50%",
                                            border: "1px solid #ccc",
                                        }}
                                    ></div>
                                    <span>{item.label}</span>
                                </Col>
                            ))}
                        </Row>
                    </Col>
                    <Col>
                        <Row className="border bg-white rounded-4 p-3 mb-3">
                            <h5>Thông tin lượt đi</h5>

                        </Row>
                        <Row className="border bg-white rounded-4 p-3">
                            <h5>Thông tin lượt đi</h5>
                        </Row>
                    </Col>
                </Row>
            </Container>
        </>
    );
}
export default DatGhe;