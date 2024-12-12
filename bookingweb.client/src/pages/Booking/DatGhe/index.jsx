import { Container, Row, Col, Alert, Button } from 'react-bootstrap';
import { useState, useEffect, useMemo } from 'react';
import './datghe.css';
import { GetVeXeSelected } from "@/redux/actions/VeXeAction";
import { setVeXeOrder, setIdPhieuDat } from "@/redux/slices/VeXeSlice";
import { createPhieuDat } from '@/apis';
import { useSelector } from 'react-redux';
import RenderSeats from './renderSeats';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { axiosInstance } from '@/utils/axiosInstance';
import { toast } from 'react-toastify';
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
    const chuyenXe = chuyenXeData.cxInfo.$values.find((item) => item.id === id_chuyenxe);

    const vexedata = useSelector((state) => state.vexe);
    const vexeselectedList = vexedata?.vexeSelected?.$values || [];

    const vexeOrder = vexedata?.vexeOrder || [];

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
    const handleExternalSubmit = async (e) => {
        e.preventDefault();
        if (!userData.idUser) {
            displayToast("Vui lòng đăng nhập trước khi thanh toán!");
            return;
        }
        if (!userData.hoTen || !userData.phone || !userData.email) {
            displayToast("Vui lòng cập nhật thông tin cá nhân trước khi thanh toán!");
            return;
        }
        if (selectedSeatCount === 0) {
            displayToast("Vui lòng chọn ghế trước khi thanh toán!");
            return;
        }

        const orderData = {
            idUser: userData.idUser,
            ngayLap: ngayXuatBen,
            tongTien: tongTien,
            trangThai: false,
        }
        const response = await createPhieuDat(orderData);
        dispatch(setIdPhieuDat(response.orderId));
        dispatch(setVeXeOrder(selectedSeatIds));

        handlePayment(response.orderId, selectedSeatIds);
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


    const handlePayment = async (orderId, selectedSeatIds) => {
        try {
            // Chuẩn bị dữ liệu gửi
            console.log("orderId", vexeOrder);
            const paymentData = {
                orderId: 'ORD123456', // ID đơn hàng
                fullName: 'John Doe', // Tên đầy đủ
                description: 'Test Payment', // Mô tả
                amount: tongTien, // Tổng tiền
                createdDate: new Date().toISOString(), // Ngày giờ hiện tại
                idPhieuDat: orderId, 
                idcx: id_chuyenxe,
                vexe: selectedSeatIds,
            };

            // Gửi yêu cầu đến backend
            const response = await axiosInstance.post('/api/thanh-toan/create-payment', paymentData);

            // Kiểm tra phản hồi và điều hướng nếu thành công
            if (response.data.url) {
                window.location.href = response.data.url; // Chuyển hướng tới URL thanh toán
            }
        } catch (error) {
            console.error('Error initiating payment:', error);
        }
    };


    const displayToast = (message) => {
        toast(message, {
            position: "bottom-left",
            autoClose: 1200,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            theme: "light",
        });
    }

    return (
        <>
            <button className="btn btn-outline-secondary" onClick={handleBack}>Quay lại</button>
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

                    </Col>
                    <Col>
                        <Row className="border bg-white rounded-4 p-3 mb-1">
                            <Row className="d-flex justify-content-between my-3">
                                <Col xs={8}>
                                    <h5 className=" ">Thông tin khách hàng</h5>
                                </Col>
                                <Col className="pb-1 px-3">
                                    <a className="mx-2" href={userData.idUser ? "/user-info" : "/dang-nhap"}>{userData.idUser ? "Cập nhật" : "Đăng nhập"}</a>
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
                                    {userData.email ? userData.email : "--"}
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
                                <Col className="text-end text-black">
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
                                <button className="btn_thanhtoan" onClick={handleExternalSubmit}>
                                        Thanh toán
                                </button>
                            </div>
                        </Row>
                    </Col>
                </Row>
            </Container>
        </>
    );
}
export default DatGhe;