import { useLocation } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { useEffect } from 'react';
import { useSelector } from 'react-redux';
import { axiosInstance } from '@/utils/axiosInstance';


function PaymentSuccess() {

    const location = useLocation();
    const queryParams = new URLSearchParams(location.search);
    const navigate = useNavigate();

    const responseCode = queryParams.get("vnp_ResponseCode");
    const orderId = queryParams.get("idPhieuDat");
    const id_chuyenxe = useSelector((state) => state.chuyenxe.idcx);
    const vexe = useSelector((state) => state.vexe.vexeOrder);


    const message =
        responseCode === "00"
            ? "Thanh toán thành công! Cảm ơn bạn đã sử dụng dịch vụ."
            : "Thanh toán thất bại. Vui lòng thử lại.";

    useEffect(() => {
        const updatePaymentStatus = async () => {
            if (responseCode === "00") {
                try {
                    const response = await axiosInstance.post('/api/thanh-toan/update-status', {
                        IdPhieuDat: orderId,
                        idcx: id_chuyenxe,
                        vexe: vexe
                    });

                    if (response.data.success) {
                        console.log("Cập nhật trạng thái thành công.");
                    } else {
                        console.error("Cập nhật trạng thái thất bại.");
                    }
                } catch (error) {
                    console.error("Lỗi khi gọi API cập nhật trạng thái:", error);
                }
            }
        };

        updatePaymentStatus();
    }, [responseCode, orderId]);

    return (
        <div className="container my-5">
            <div className="row justify-content-center">
                <div className="col-md-6">
                    <div className="card">
                        <div className="card-body">
                            <h1 className="card-title text-center">{message}</h1>
                            {responseCode === "00" ? (
                                <div className="text-center">
                                    <i className="fas fa-check-circle text-success" style={{ fontSize: 48 }}></i>
                                </div>
                            ) : (
                                <div className="text-center">
                                    <i className="fas fa-times-circle text-danger" style={{ fontSize: 48 }}></i>
                                </div>
                            )}
                            <p className="card-text text-center">
                                {responseCode === "00"
                                    ? "Chúng tôi sẽ gửi thông tin về đơn hàng của bạn."
                                    : "Vui lòng kiểm tra lại thông tin thanh toán và thử lại."}
                            </p>
                            <div className="text-center">
                                <a onClick={() => navigate('/')} className="btn btn-primary">Quay lại trang chủ</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default PaymentSuccess;