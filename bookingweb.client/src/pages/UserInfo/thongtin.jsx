import Sidebar from "./Sidebar/index";
import { Button,Form,Col,Row} from "react-bootstrap";
import { useState } from "react";
import { useSelector } from 'react-redux';


const UserInfo = () => {

    const [isEditing, setIsEditing] = useState(false);

    const handleEdit = () => {
        setIsEditing(true);
    };

    const handleSave = () => {
        setIsEditing(false);
       
    };

    const handleCancel = () => {
        setIsEditing(false);
        
    };

    const userred = useSelector((state) => state.user.userInfo);
    console.log(userred)
    return (
        <div
            className="d-flex justify-content-center align-items-center"
            style={{ height: "75vh" }}
        >
            <Sidebar />
            <div className="ms-3" style={{ height: '65vh',width:"800px"}}>
                <h4>Thông tin tài khoản</h4>
                <p>Quản thông tin hồ sơ để bảo mật tài khoản</p>
                <div
                    className="p-4 shadow rounded justify-content-center align-items-center"
                    style={{ margin: "auto", backgroundColor: "#fff" }}
                >
                    <Form className="w-100">
                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">
                                Họ và tên:
                            </Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    placeholder="Lê Tấn Tài"
                                    disabled={!isEditing}
                                />
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">
                                Số điện thoại
                            </Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    placeholder="0348696666"
                                    disabled={!isEditing}
                                />
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">
                                Giới tính
                            </Form.Label>
                            <Col sm="2">
                                <Form.Select disabled={!isEditing}>
                                    <option value="Male">Nam</option>
                                    <option value="Female">Nữ</option>
                                    <option value="Other">Other</option>
                                </Form.Select>
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">
                                Email
                            </Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="email"
                                    placeholder="letaikun@gmail.com"
                                    disabled={!isEditing}
                                />
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3">
                            <Form.Label column sm="2">
                                Ngày sinh:
                            </Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="date"
                                    defaultValue="2024-11-25"
                                    disabled={!isEditing}
                                />
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3">
                            <Form.Label column sm="2">
                                Địa chỉ:
                            </Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    placeholder="Nhập địa chỉ"
                                    disabled={!isEditing}
                                />
                            </Col>
                        </Form.Group>
                    </Form>

                    <div className="d-flex justify-content-center">
                        {!isEditing ? (
                            <Button
                                variant="danger"
                                className="rounded-pill px-4 py-2"
                                style={{ backgroundColor: "#FF5722", border: "none" }}
                                onClick={handleEdit}
                            >
                                Cập nhật
                            </Button>
                        ) : (
                            <div>
                                <Button
                                    variant="success"
                                    className="rounded-pill px-4 py-2 mx-2"
                                    onClick={handleSave}
                                >
                                    Lưu
                                </Button>
                                <Button
                                    variant="secondary"
                                    className="rounded-pill px-4 py-2"
                                    onClick={handleCancel}
                                >
                                    Hủy
                                </Button>
                            </div>
                        )}
                    </div>

                </div>  
            </div>
            
        </div>
    );
};
export default UserInfo;
