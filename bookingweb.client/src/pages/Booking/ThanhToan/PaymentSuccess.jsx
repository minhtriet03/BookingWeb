import { useLocation } from 'react-router-dom';

function PaymentSuccess() {
    const location = useLocation();
    const queryParams = new URLSearchParams(location.search);

    const responseCode = queryParams.get("vnp_ResponseCode");
    const message =
        responseCode === "00"
            ? "Thanh toán thành công! Cảm ơn bạn đã sử dụng dịch vụ."
            : "Thanh toán thất bại. Vui lòng thử lại.";

    return (
        <div className="container">
            <h1>{message}</h1>
            <a href="/">Quay lại trang chủ</a>
        </div>
    );
}

export default PaymentSuccess;
