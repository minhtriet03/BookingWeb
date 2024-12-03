import { Col, Image, Table, Row, Card, Alert } from "react-bootstrap";
import { useState, useEffect } from "react";

function RenderSeats() {
    const lowerSeats = [
        "A01", "00", "A02", "A03", "A04", "A05", "A06", "A07", "A08", "A09",
        "A10", "A11", "A12", "A13", "A14", "A15", "A16", "A17"
    ];
    const upperSeats = [
        "B01", "00", "B02", "B03", "B04", "B05", "B06", "B07", "B08", "B09",
        "B10", "B11", "B12", "B13", "B14", "B15", "B16", "B17"
    ];
    const legend = [
        { color: "#D5D9DD", label: "Đã đặt" }, // Đã đặt
        { color: "#DEF3FF", label: "Còn trống" }, // Ghế trống
        { color: "#FDEDE8", label: "Đang chọn" }, // Ghế đang chọn
    ];

    // State để lưu trạng thái các ghế
    const [selectedSeats, setSelectedSeats] = useState({});
    const [bookedSeats, setBookedSeats] = useState({});

    // State để lưu số lượng ghế đã chọn
    const [selectedSeatCount, setSelectedSeatCount] = useState(0);

    // State để lưu thông báo khi đạt giới hạn
    const [showLimitAlert, setShowLimitAlert] = useState(false);

    useEffect(() => {
        // Giả sử bạn có một API để lấy dữ liệu ghế đã được đặt từ DB
        // Ví dụ, các ghế đã đặt
        const fetchedBookedSeats = ["A01", "B03", "A06"]; // Các ghế đã đặt
        const bookedSeatsObj = fetchedBookedSeats.reduce((acc, seatId) => {
            acc[seatId] = true;
            return acc;
        }, {});
        setBookedSeats(bookedSeatsObj);
    }, []);

    const handleSeatSelection = (seatId) => {
        if (bookedSeats[seatId]) return; // Nếu ghế đã được đặt, không thay đổi trạng thái

        if (selectedSeatCount >= 5 && !selectedSeats[seatId]) {
            // Nếu đã chọn đủ 5 ghế và đang chọn ghế chưa được chọn
            setShowLimitAlert(true); // Hiển thị thông báo "Đã đủ số ghế"
            return;
        }

        setSelectedSeats((prevSelected) => {
            const updatedSelected = { ...prevSelected, [seatId]: !prevSelected[seatId] };
            const selectedCount = Object.values(updatedSelected).filter(Boolean).length; // Đếm số ghế được chọn
            setSelectedSeatCount(selectedCount); // Cập nhật số lượng ghế được chọn
            setShowLimitAlert(false); // Ẩn thông báo khi chọn ghế
            return updatedSelected;
        });
    };

    // Hàm render ghế
    const renderSeats = (seats, title) => {
        const seatRows = [];

        // Nhóm các ghế thành các hàng 3 ghế
        for (let i = 0; i < seats.length; i += 3) {
            seatRows.push(seats.slice(i, i + 3));
        }

        return (
            <Table className="seatTable" key={title}>
                <thead>
                    <tr>
                        <th colSpan="3">{title}</th>
                    </tr>
                </thead>
                <tbody>
                    {seatRows.map((row, rowIndex) => (
                        <tr key={`${title}-row-${rowIndex}`}>
                            {row.map((seatId) => (
                                seatId === "00" ? (
                                    <td key={seatId}></td> // Nếu ghế là "00", tạo td trống
                                ) : (
                                    <td
                                        key={seatId}
                                        className={`justify-content-center align-items-center ${bookedSeats[seatId] ? 'booked' : ''}`}
                                        style={{ position: 'relative' }}
                                        onClick={() => handleSeatSelection(seatId)}
                                    >
                                        <div className="position-relative d-flex justify-content-center align-items-center">
                                            {/* Đổi hình ảnh tùy theo trạng thái ghế */}
                                            <Image
                                                width={34}
                                                src={bookedSeats[seatId] ?
                                                    "https://futabus.vn/images/icons/seat_disabled.svg" :
                                                    (selectedSeats[seatId]
                                                        ? "https://futabus.vn/images/icons/seat_selecting.svg"
                                                        : "https://futabus.vn/images/icons/seat_active.svg")
                                                }
                                                alt="seat icon"
                                            />
                                            <span
                                                className="position-absolute seatSpan"
                                                style={{
                                                    color: bookedSeats[seatId]
                                                        ? "#B0B0B0" // Màu cho ghế đã đặt
                                                        : selectedSeats[seatId]
                                                            ? "#EF5222"
                                                            : "#339AF4", // Màu cho ghế còn trống
                                                }}
                                            >
                                                {seatId}
                                            </span>
                                        </div>
                                    </td>
                                )
                            ))}
                        </tr>
                    ))}
                </tbody>
            </Table>
        );
    };

    // Lấy các ghế đã chọn và nối chúng thành chuỗi
    const selectedSeatIds = Object.keys(selectedSeats).filter(seatId => selectedSeats[seatId]);

    return (
        <>
            {/* Cột chọn ghế */}
            <h5>Chọn ghế</h5>
            <Row className="mt-4 text-sm font-normal p-3">
                <Col>{renderSeats(lowerSeats, "Tầng dưới")}</Col>
                <Col>{renderSeats(upperSeats, "Tầng trên")}</Col>
            </Row>

            {/* Thông báo nếu đã chọn đủ 5 ghế */}
            {showLimitAlert && (
                <Alert variant="danger">
                    Bạn chỉ có thể chọn tối đa 5 ghế!
                </Alert>
            )}

            {/* Hiển thị thông tin ghế đã chọn */}
            <Card className="mt-4">
                <Card.Body>
                    <Card.Title>Số ghế đã chọn: {selectedSeatCount}</Card.Title>
                    <Card.Text>
                        {selectedSeatCount > 0 ? (
                            selectedSeatIds.join(", ") // Nối các ghế đã chọn thành chuỗi
                        ) : (
                            <div>Chưa có ghế nào được chọn</div>
                        )}
                    </Card.Text>
                </Card.Body>
            </Card>

            {/* Legend */}
            <Row className="mt-4 text-sm font-normal">
                {legend.map((item, index) => (
                    <Col key={index} className="d-flex align-items-center justify-content-center gap-2">
                        <div className="iconChuThich" style={{ backgroundColor: item.color }}></div>
                        <span>{item.label}</span>
                    </Col>
                ))}
            </Row>
        </>
    );
}

export default RenderSeats;
