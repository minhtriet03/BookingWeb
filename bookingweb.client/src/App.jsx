﻿import { BrowserRouter as Router,Routes,Route } from "react-router-dom";
import Home from './pages/Home';
import Auth from './pages/Auth';
import '@/assets/root.css';

function App() {
return (
    <Router>
        <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/dang-nhap"  element={<Auth />} />
        </Routes>
    </Router>

    );

}

export default App;