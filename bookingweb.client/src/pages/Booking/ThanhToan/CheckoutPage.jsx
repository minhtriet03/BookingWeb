
import { axiosInstance } from '@/utils/axiosInstance';


const CheckoutPage = () => {
const handlePayment = async () => {
    try {
        const response = await axiosInstance.post('/api/thanh-toan/create-payment', {
            request: {
            amount: 500000, // Giá trị động từ người dùng
            orderId: 'ORD123456', // Mã tham chiếu
            returnUrl: `${window.location.origin}/payment-success`
        }
        });
        if (response.data.url) {
            window.location.href = response.data.url; // Điều hướng tới VNPay
        }
    } catch (error) {
        console.error("Error initiating payment:", error);
    }
};

return (
    <div>
        <button onClick={handlePayment} className="btn btn-primary">
            Thanh toán với VNPay
        </button>
    </div>
);
}

export default CheckoutPage;