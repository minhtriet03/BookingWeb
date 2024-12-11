import { Container, Row, Col, Alert, Button } from 'react-bootstrap';
import { useState, useEffect,useMemo } from 'react';
import './datghe.css';
import { GetVeXeSelected } from "@/redux/actions/VeXeAction";
import { setVeXeOrder } from "@/redux/slices/VeXeSlice";
//import { createOrder } from '@/apis';
import { useSelector } from 'react-redux';
import RenderSeats from './renderSeats';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
function DatGhe({ handleDisplay }) {

    const legend = [
        { color: "#D5D9DD", label: "Đã đặt" }, // Đã đặt
        { color: "#DEF3FF", label: "Còn trống" }, // Ghế trống
        { color: "#FDEDE8", label: "Đang chọn" }, // Ghế đang chọn
    ];
    const queryParams = new URLSearchParams(window.location.search);
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const userRedux = useSelector((state) => state.user);
    const userData = {
        idUser: userRedux?.userInfo?.userInfo?.idUser,
        hoTen: userRedux?.userInfo?.userInfo?.hoTen,
        email: userRedux?.userInfo?.userInfo?.email,
        phone: userRedux?.userInfo?.userInfo?.phone,
    };

    const id_chuyenxe = useSelector((state) => state.chuyenxe.idcx);

    const chuyenXeData = useSelector((state) => state.chuyenxe);
    const chuyenXe = chuyenXeData.cxInfo.$values.find((item) => item.$id === id_chuyenxe);

    const vexedata = useSelector((state) => state.vexe);
    const vexeselectedList = vexedata?.vexeSelected?.$values||[];

    const ngayXuatBen = queryParams.get("ngaydi");
    const [bookedSeats, setBookedSeats] = useState([]);
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
        if (selectedSeatCount === 0) {
            alert("Vui lòng chọn ghế trước khi thanh toán!");
            return;
        }
        if (!userData.idUser) {
            alert("Vui lòng đăng nhập trước khi thanh toán!");
            return;
        }
        if (!userData.hoTen || !userData.phone || !userData.email) {
            alert("Vui lòng cập nhật thông tin cá nhân trước khi thanh toán!");
            return;
        }

        const orderData = {
            idUser: userData.idUser,
                ngayLap: ngayXuatBen,
                tongTien: tongTien,
                trangThai: false,
        }
        //createOrder(orderData);
        dispatch(setVeXeOrder(selectedSeatIds));
        navigate("/thanh-toan");
    };

    useEffect(() => {
        // Lấy vé xe đã chọn từ store
        dispatch(GetVeXeSelected(id_chuyenxe));
    }, [id_chuyenxe, dispatch]);

    const bookedSeatsObj = useMemo(() => {
        return vexeselectedList.map(seatId => seatId);
    }, [vexeselectedList]);
    
    // Bây giờ bạn có thể an toàn cập nhật trạng thái
    useEffect(() => {
        setBookedSeats(bookedSeatsObj);
    }, [bookedSeatsObj]);

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
                                    <a href={userData.idUser ? "/thong-tin-ca-nhan" : "/dang-nhap"}>{userData.idUser ? "Cập nhật" : "Đăng nhập"}</a>
                                </Col>
                            </Row>
                            <Row className="d-flex justify-content-between">
                                <Col xs={7} className="text-gray">
                                    Họ và tên:  
                                </Col>
                                <Col className="text-end text-black">
                                    {userData.hoTen ? userData.hoTen : "--"}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={7} className="text-gray">
                                    Số điện thoại:
                                </Col>
                                <Col className="text-end text-black">
                                    {userData.phone ? userData.phone : "--"}
                                </Col>
                            </Row>
                            <Row className="mt-2 d-flex justify-content-between">
                                <Col xs={4} className="text-gray">
                                    Email:
                                </Col>
                                <Col className="text-end text-black">
                                    {userData.email ? userData.email: "--"}
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