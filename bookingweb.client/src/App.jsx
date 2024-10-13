import { BrowserRouter as Router,Routes,Route } from "react-router-dom";
import Home from './pages/Home';
import Auth from './pages/Auth';
import Schedule from './pages/Schedule';
import '@/assets/root.css';


function App() {
return (
    <Router>
        <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/dang-nhap"  element={<Auth />} />
        <Route path="/lich-trinh" element={<Schedule />} />
        </Routes>
    </Router>

    );
    
}

export default App;