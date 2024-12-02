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

import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { SetUser } from "./redux/actions/UserAction";
//import { useNavigate } from "react-router-dom";
import { useState } from "react";


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
        return <p> dang load....</p>;
    }



return (
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
        </Routes>
        <Footer />
    </Router>

    );

}

export default App;