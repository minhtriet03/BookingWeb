import Sidebar from "./Sidebar/index";
import { Button, Form, Col, Row } from "react-bootstrap";
import { useState } from "react";
import { useSelector } from 'react-redux';

const UserInfo = () => {

    const userred = useSelector((state) => state.user);
    console.log("userInfooo", userred);

    const [isEditing, setIsEditing] = useState(false);

    //const [userInfo, setUserInfo] = useState({
    //    fullName: "Lê Tấn Tài",
    //    phoneNumber: "0348696666",
    //    gender: "Male",
    //    email: "letaikun@gmail.com",
    //    dob: "2024-11-25",
    //    address: "Nhập địa chỉ"
    //});

    const handleEdit = () => {
        setIsEditing(true);
    };

    const handleSave = () => {
        setIsEditing(false);
        //console.log("Thông tin đã lưu:", userInfo);
        // Save user info to the backend or local storage here
    };

    const handleCancel = () => {
        setIsEditing(false);
        // Optionally reset user info to its initial state
    };

    //const handleChange = (e) => {
    //    const { name, value } = e.target;
    //    setUserInfo((prevState) => ({
    //        ...prevState,
    //        [name]: value
    //    }));
    //};

    return (
        <div className="d-flex justify-content-center align-items-center" style={{ height: "75vh" }}>
            <Sidebar />
            <div className="ms-3" style={{ height: '65vh', width: "800px" }}>
                <h4>Thông tin tài khoản</h4>
                <p>Quản thông tin hồ sơ để bảo mật tài khoản</p>
                <div
                    className="p-4 shadow rounded justify-content-center align-items-center"
                    style={{ margin: "auto", backgroundColor: "#fff" }}
                >
                    <Form className="w-100">
                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">Họ và tên:</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    name="fullName"
                                    /*value={userred.name}*/
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
                                    /*value={userred.}*/
                                    disabled={!isEditing}
                                    /*onChange={handleChange}*/
                                />
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">Giới tính</Form.Label>
                            <Col sm="2">
                                <Form.Select
                                    name="gender"
                                    /*value={userInfo.gender}*/
                                    disabled={!isEditing}
                                    /*onChange={handleChange} // This will handle changes in this select field*/
                                >
                                    <option value="Male">Nam</option>
                                    <option value="Female">Nữ</option>
                                    <option value="Other">Other</option>
                                </Form.Select>
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">Email</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="email"
                                    name="email"
                                    /*value={userred.email}*/
                                    disabled={!isEditing}
                                    /*onChange={handleChange}*/
                                />
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3">
                            <Form.Label column sm="2">Ngày sinh:</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="date"
                                    name="dob"
                                    /*value={userInfo.dob}*/
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
                                    /*value={userInfo.address}*/
                                    disabled={!isEditing}
                                    /*onChange={handleChange}*/
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
