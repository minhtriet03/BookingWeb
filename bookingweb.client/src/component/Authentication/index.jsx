import { useSelector } from "react-redux";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";



function Authentication ({ children }) {
    const { isAuthenticated } = useSelector((state) => state.auth);
    const navigate = useNavigate();

    useEffect(() => {
        if (!isAuthenticated) {
            alert("Phiên đăng nhập đã hết hạn, vui lòng đăng nhập lại.");
            navigate("/login");
        }
    }, [isAuthenticated, navigate]);

    return children;
};

export default Authentication;