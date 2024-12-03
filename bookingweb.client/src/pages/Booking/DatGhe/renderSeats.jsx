import { Table, Image } from "react-bootstrap";

function RenderSeats({ title, bookedSeats, selectedSeats, onSeatSelect }) {
    // Khai báo danh sách ghế bên trong component
    const seats = title === "Tầng dưới"
        ? [
            "A01", "00", "A02", "A03", "A04", "A05", "A06", "A07", "A08", "A09",
            "A10", "A11", "A12", "A13", "A14", "A15", "A16", "A17"
        ]
        : [
            "B01", "00", "B02", "B03", "B04", "B05", "B06", "B07", "B08", "B09",
            "B10", "B11", "B12", "B13", "B14", "B15", "B16", "B17"
        ];

    const seatRows = [];

    // Nhóm ghế thành các hàng 3 ghế
    for (let i = 0; i < seats.length; i += 3) {
        seatRows.push(seats.slice(i, i + 3));
    }

    return (
        <Table borderless className="seatTable" key={title}>
            <thead>
                <tr>
                    <th colSpan="3" className="text-center">{title}</th>
                </tr>
            </thead>
            <tbody>
                {seatRows.map((row, rowIndex) => (
                    <tr key={`${title}-row-${rowIndex}`}>
                        {row.map((seatId) => (
                            seatId === "00" ? (
                                <td key={seatId}></td> // Tạo ô trống cho ghế "00"
                            ) : (
                                <td
                                    key={seatId}
                                    className={`justify-content-center align-items-center ${bookedSeats[seatId] ? 'booked' : ''}`}
                                    style={{ position: 'relative' }}
                                >
                                        <div className="position-relative d-flex justify-content-center align-items-center"
                                            onClick={() => onSeatSelect(seatId)}
                                        >
                                            <Image
                                                className="seatIcon"
                                            width={40}
                                            src={bookedSeats[seatId]
                                                ? "https://futabus.vn/images/icons/seat_disabled.svg"
                                                : (selectedSeats[seatId]
                                                    ? "https://futabus.vn/images/icons/seat_selecting.svg"
                                                    : "https://futabus.vn/images/icons/seat_active.svg")
                                            }
                                            alt="seat icon"
                                        />
                                        <span
                                            className="position-absolute seatSpan"
                                            style={{
                                                color: bookedSeats[seatId]
                                                    ? "#B0B0B0"
                                                    : selectedSeats[seatId]
                                                        ? "#EF5222"
                                                        : "#339AF4",
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
}

export default RenderSeats;
