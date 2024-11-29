import ProfileIcon from './Icon/Profile.svg';
import HistoryIcon from './Icon/History.svg';
import PasswordIcon from './Icon/Password.svg';
import { useNavigate } from 'react-router-dom';

const Sidebar = () => {

    const navigate = useNavigate(); 

    const historyClick = () => {
        navigate("/history")
    };

    const infoClick = () => {
        navigate("/user-info")
    };

    const passClick = () => {
        navigate("/changepass")
    };
    return (
        <div className="col-span-12 hidden rounded-2xl border p-2 sm:col-span-3 lg:block" style={{ height:'68vh', width: '250px', border: '1px solid #ddd', borderRadius: '8px', padding: '10px' }}>
            <div
                className="cursor-pointer p-2"
                onClick={infoClick }
                style={{
                    transition: 'background-color 0.3s ease, box-shadow 0.3s ease',
                    cursor:"pointer"
                }}
             
            >
                <div className="sub-menu-active rounded-lg px-3 py-2">
                    <div className="d-flex align-items-center">
                        <img src={ProfileIcon} alt="" style={{ width: '24px', height: '24px' }} />
                        <span className="ms-3">Thông tin hồ sơ</span>
                    </div>
                </div>
            </div>
            <div
                className="cursor-pointer p-2"
                onClick={historyClick}
                style={{
                    transition: 'background-color 0.3s ease, box-shadow 0.3s ease',
                    cursor: "pointer"
                }}

            >
                <div className="sub-menu-active rounded-lg px-3 py-2">
                    <div className="d-flex align-items-center">
                        <img src={HistoryIcon} alt="" style={{ width: '24px', height: '24px' }} />
                        <span className="ms-3">Lịch sử mua vé</span>
                    </div>
                </div>
            </div>
            <div
                className="cursor-pointer p-2"
                onClick={passClick}
                style={{
                    transition: 'background-color 0.3s ease, box-shadow 0.3s ease',
                    cursor: "pointer"
                }}

            >
                <div className="sub-menu-active rounded-lg px-3 py-2">
                    <div className="d-flex align-items-center">
                        <img src={PasswordIcon} alt="" style={{ width: '24px', height: '24px' }} />
                        <span className="ms-3">Đặt lại mật khẩu</span>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Sidebar;
