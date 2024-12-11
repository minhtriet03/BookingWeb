import { BrowserRouter as Router,Routes,Route } from "react-router-dom";
import Home from './pages/Home';
import Auth from './pages/Auth';
import Schedule from './pages/Schedule';
import '@/assets/root.css';
import Booking from './pages/Booking';
import Footer from "./component/Footer/index";
import Header from "./component/Header/index";

import UserInfo from "./pages/UserInfo/thongtin";
import History from "./pages/UserInfo/history";
import Password from "./pages/UserInfo/password";

import CheckoutPage from "./pages/Booking/ThanhToan/CheckoutPage";
import PaymentSuccess from "./pages/Booking/ThanhToan/PaymentSuccess";

import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { SetUser } from "./redux/actions/UserAction";
import { useState } from "react";
import Spinner from 'react-bootstrap/Spinner';

import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer } from 'react-toastify';

function App() {

    const dispatch = useDispatch();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getuser();

    }, []);

    const getuser = async () => {
        const response = await dispatch(SetUser());
        if (SetUser.fulfilled.match(response)) setLoading(false);
    };

    if (loading) {
        return (
            <div className="d-flex justify-content-center align-items-center vh-100">
                <Spinner animation="border" variant="warning" className="spinner-border-lg" />
                <div className="ml-2 font-weight-bold h5">Loading...</div>
            </div>
        );
    }



    return (
        <>
            <ToastContainer
                position="bottom-left"
                autoClose={1200}
                hideProgressBar={false}
                newestOnTop={false}
                closeOnClick
                rtl={false}
                pauseOnFocusLoss
                draggable
                pauseOnHover
                theme="light"
                transition: Bounce
/>
    <Router>
        <Header />
        <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/dang-nhap"  element={<Auth />} />
            <Route path="/lich-trinh" element={<Schedule />} />
            <Route path="/dat-ve" element={<Booking />} />
            <Route path="/user-info" element={<UserInfo />} />
            <Route path="/history" element={<History />} />
            <Route path="/changepass" element={<Password />} />
            <Route path="/thanh-toan" element={<CheckoutPage />} />
            <Route path="/payment-success" element={<PaymentSuccess />} />
        </Routes>
        <Footer />
    </Router>
</>
    );
}

export default App;