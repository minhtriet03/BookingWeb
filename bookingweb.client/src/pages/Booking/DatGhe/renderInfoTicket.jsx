
import { Row, Col, Alert } from 'react-bootstrap';


const RenderInfoTicket = ({ infoTicket }) => {
    return (
        <>
            <h5>Thông tin lượt đi</h5>
            <Row className="mt-4 d-flex justify-content-between">
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
                    Thời gian xuất bến:
                </Col>
                <Col xs={7} className="text-end text-black">
                    {selectedSeatCount > 0
                        ? selectedSeatIds.slice().reverse().join(", ") // Đảo ngược mảng và nối chuỗi
                        : <div></div>}
                </Col>
            </Row>
            <Row className="mt-2 d-flex justify-content-between">
                {showLimitAlert && (
                    <Alert variant="danger">
                        Bạn chỉ có thể chọn tối đa 5 ghế!
                    </Alert>
                )}
            </Row>
        </>
    );
}
export default RenderInfoTicket;