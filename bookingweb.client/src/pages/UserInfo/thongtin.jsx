import Sidebar from "./Sidebar/index";
import { Button, Form, Col, Row } from "react-bootstrap";
import { useState } from "react";
import { updateUser } from '@/apis/index';
import { useSelector } from 'react-redux';
import { Toaster, toast } from 'sonner';



const UserInfo = () => {
    const userred = useSelector((state) => state.user);
    console.log(userred);

    const [errors, setErrors] = useState({});
    const [formData, setFormData] = useState({
        id: userred.userInfo.userInfo.idUser,
        fullName: userred.userInfo.userInfo.hoTen,
        phoneNumber: userred.userInfo.userInfo.phone,
        email: userred.userInfo.userInfo.email,
        address: userred.userInfo.userInfo.diaChi,
        status: userred.userInfo.userInfo.trangThai,
        idaccount: userred.userInfo.idAccount
    });
    const [isEditing, setIsEditing] = useState(false);

    const validate = () => {
        const newErrors = {};

        if (!formData.fullName.trim()) {
            newErrors.fullName = "Họ và tên là bắt buộc.";
        }

        const phoneRegex = /^[0-9]{10}$/;
        if (!formData.phoneNumber) {
            newErrors.phoneNumber = "Số điện thoại là bắt buộc.";
        } else if (!phoneRegex.test(formData.phoneNumber)) {
            newErrors.phoneNumber = "Số điện thoại không hợp lệ (10 số).";
        }

        const emailRegex = /^[^\s@]+@[^\s@]+.[^\s@]+$/;
        if (!formData.email) {
            newErrors.email = "Email là bắt buộc.";
        } else if (!emailRegex.test(formData.email)) {
            newErrors.email = "Email không hợp lệ.";
        }

        if (!formData.address.trim()) {
            newErrors.address = "Địa chỉ là bắt buộc.";
        }

        setErrors(newErrors);
        return Object.keys(newErrors).length === 0;
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const handleEdit = () => {
        setIsEditing(true);
    };

   const handleSave = async (e) => {
    e.preventDefault();
    if (validate()) {
        const userData = {
            IdUser: userred.userInfo.userInfo.idUser,
            HoTen: formData.fullName,
            DiaChi: formData.address,
            email: formData.email,
            Phone: formData.phoneNumber,   
            TrangThai: userred.userInfo.userInfo.trangThai,
            idAccount: userred.userInfo.idAccount
        };
        console.log(userData);
        try {
            await updateUser(userData);
            toast.success('Update thành công');
            
                setIsEditing(false); 
            
        } catch (error) {
            console.error("Lỗi khi cập nhật:", error);
            toast.error('Update thất bại');

        }
    }
};


    const handleCancel = () => {
        setIsEditing(false);
        setFormData({
            fullName: userred.userInfo.hoTen,
            phoneNumber: userred.userInfo.phone,
            email: userred.userInfo.email,
            address: userred.userInfo.address,
        });
        setErrors({}); 
    };

    return (
        <div className="d-flex justify-content-center align-items-center" style={{ height: "75vh" }}>
            <Toaster richColors position="top-right" />
            <Sidebar />
            <div className="ms-3" style={{ height: '65vh', width: "800px" }}>
                <h4>Thông tin tài khoản</h4>
                <p>Quản lý thông tin hồ sơ để bảo mật tài khoản</p>
                <div
                    className="p-4 shadow rounded justify-content-center align-items-center"
                    style={{ height: "56vh", margin: "auto", backgroundColor: "#fff" }}
                >
                    <Form className="w-100" onSubmit={handleSave}>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">Họ và tên:</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    name="fullName"
                                    value={formData.fullName}
                                    disabled={!isEditing}
                                    onChange={handleChange}
                                    isInvalid={!!errors.fullName}
                                />
                                <Form.Control.Feedback type="invalid">
                                    {errors.fullName}
                                </Form.Control.Feedback>
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">Số điện thoại</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    name="phoneNumber"
                                    value={formData.phoneNumber}
                                    disabled={!isEditing}
                                    onChange={handleChange}
                                    isInvalid={!!errors.phoneNumber}
                                />
                                <Form.Control.Feedback type="invalid">
                                    {errors.phoneNumber}
                                </Form.Control.Feedback>
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3 d-flex">
                            <Form.Label column sm="2">Email</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="email"
                                    name="email"
                                    value={formData.email}
                                    disabled={!isEditing}
                                    /*onChange={handleChange}*/
                                    isInvalid={!!errors.email}
                                />
                                <Form.Control.Feedback type="invalid">
                                    {errors.email}
                                </Form.Control.Feedback>
                                </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3">
                            <Form.Label column sm="2">Địa chỉ:</Form.Label>
                            <Col sm="7">
                                <Form.Control
                                    type="text"
                                    name="address"
                                    value={formData.address}
                                    disabled={!isEditing}
                                    onChange={handleChange}
                                    isInvalid={!!errors.address}
                                />
                                <Form.Control.Feedback type="invalid">
                                    {errors.address}
                                </Form.Control.Feedback>
                            </Col>
                        </Form.Group>


                        <br />
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
                                        type="submit"
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
                    </Form>
                </div>
            </div>
            
        </div>
    );
};

export default UserInfo;
