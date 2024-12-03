import Sidebar from "./Sidebar/index";
import { Button, Form, Col, Row } from "react-bootstrap";
import { useState } from "react";
import { useSelector } from 'react-redux';

const UserInfo = () => {

    const userred = useSelector((state) => state.user);
    console.log(userred)

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

   

    return (
        <div className="d-flex justify-content-center align-items-center" style={{ height: "75vh" }}>
            <Sidebar />
            <div className="ms-3" style={{ height: '65vh', width: "800px" }}>
                <h4>Thông tin tài khoản</h4>
                <p>Quản thông tin hồ sơ để bảo mật tài khoản</p>
                <div
                    className="p-4 shadow rounded justify-content-center align-items-center"
                    style={{ height:"56vh", margin: "auto", backgroundColor: "#fff" }}
                >
                    <Form className="w-100">
                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">ID</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    name="ID"
                                    value={"User: " + userred.userInfo.idUser}
                                    disabled={!isEditing}
                                /*onChange={handleChange} // This will handle changes in this field*/
                                />
                            </Col>
                        </Form.Group>
                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">Họ và tên:</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    name="fullName"
                                    value={userred.userInfo.hoTen}
                                    disabled={!isEditing}
                                    /*onChange={handleChange} // This will handle changes in this field*/
                                />
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">Số điện thoại</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    name="phoneNumber"
                                    value={userred.userInfo.phone}
                                    disabled={!isEditing}
                                    /*onChange={handleChange}*/
                                />
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">Email</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="email"
                                    name="email"
                                    value={userred.userInfo.email}
                                    disabled={!isEditing}
                                /*onChange={handleChange}*/
                                />
                            </Col>
                        </Form.Group>

                     
                        <Form.Group as={Row} className="mb-3">
                            <Form.Label column sm="2">Địa chỉ:</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    name="address"
                                    value={userred.userInfo.address}
                                    disabled={!isEditing}
                                    /*onChange={handleChange}*/
                                />
                            </Col>
                        </Form.Group>
                    </Form>
                    <br/>
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
