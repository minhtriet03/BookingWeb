import { BrowserRouter as Router,Routes,Route } from "react-router-dom";
import Home from './pages/Home';
import Auth from './pages/Auth';
import Schedule from './pages/Schedule';
import '@/assets/root.css';
import Booking from './pages/Booking';
import Footer from "./component/Footer/index";
import Header from "./component/Header/index";
function App() {
return (
    <Router>
        <Header />
        <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/dang-nhap"  element={<Auth />} />
            <Route path="/lich-trinh" element={<Schedule />} />
            <Route path="/dat-ve" element={<Booking />} />
        </Routes>
        <Footer />
    </Router>
    );
}

export default App;