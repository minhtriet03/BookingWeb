import Sidebar from "./Sidebar/index";
import { Card, Button,} from "react-bootstrap";


const UserInfo = () => {
    return (
        <div
            className="d-flex justify-content-center align-items-center"
            style={{ height: "75vh" }}
        >
            <Sidebar />
            <div className="ms-3" style={{ height:'65vh' }}>
                <h4>Thông tin tài khoản</h4>
                <p>Quản thông tin hồ sơ để bảo mật tài khoản</p>
                <div
                    className="p-4 shadow rounded"
                    style={{ maxWidth: "800px", margin: "auto", backgroundColor: "#fff" }}
                >
                    <Card className="text-center p-4 border-0" style={{ maxWidth: "250px", margin: "0 auto" }}>
                        <Card.Body>
                            <div className="d-flex justify-content-center mb-3">
                                <div className="rounded-circle overflow-hidden" style={{ width: "172px", height: "172px" }}>
                                    <img
                                        src="https://via.placeholder.com/150"
                                        alt="Avatar"
                                        className="w-100 h-100 object-fit-cover"
                                    />
                                </div>
                            </div>
                            <Button variant="outline-primary" className="rounded-pill py-2 px-4 mb-2">
                                Chọn ảnh
                            </Button>
                            <Card.Text className="text-muted" style={{ fontSize: "12px" }}>
                                Dung lượng file tối đa 1 MB <br />
                                Định dạng: JPEG, PNG
                            </Card.Text>
                        </Card.Body>
                    </Card>
                </div>
            </div>
            
        </div>
    );
};
export default UserInfo;
