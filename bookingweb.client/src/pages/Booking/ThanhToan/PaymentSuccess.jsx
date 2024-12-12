import { useLocation } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

function PaymentSuccess() {
    const location = useLocation();
    const queryParams = new URLSearchParams(location.search);
    const navigate = useNavigate()

    const responseCode = queryParams.get("vnp_ResponseCode");
    const message =
        responseCode === "00"
            ? "Thanh toán thành công! Cảm ơn bạn đã sử dụng dịch vụ."
            : "Thanh toán thất bại. Vui lòng thử lại.";

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