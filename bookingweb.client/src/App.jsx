import { BrowserRouter as Router,Routes,Route } from "react-router-dom";
import Home from './pages/Home';
import Auth from './pages/Auth';
import Schedule from './pages/Schedule';
import '@/assets/root.css';
import Booking from './pages/Booking';
import Footer from "./component/Footer/index";
import Header from "./component/Header/index";
import UserInfo from "./pages/UserInfo/index";
// import Authentication from "./component/Authentication";
// import { useEffect } from "react";
// import { useDispatch } from "react-redux";
// // import { SetUser } from "./redux/actions/authAction";
// import { useNavigate } from "react-router-dom";

function App() {
    // const dispatch = useDispatch();
    // const navigate = useNavigate();

    // useEffect(() => {
    //     const getuser = async () => {
    //         const response = await dispatch(SetUser());
    //         if (SetUser.fulfilled.match(response)) {
    //             navigate("/");
    //         }
    //     };
    //     getuser();
    // }, []);
return (
    <Router>
        <Header />
        <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/dang-nhap"  element={<Auth />} />
         <Route path="/lich-trinh" element={<Schedule />} />
            <Route path="/dat-ve" element={<Booking />} />
            <Route path="/user-info" element={<UserInfo />} />
        </Routes>
        <Footer />
    </Router>

    );

}

export default App;