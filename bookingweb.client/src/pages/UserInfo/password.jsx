import Sidebar from "./Sidebar/index";
import { Form, Button} from 'react-bootstrap';
import { useSelector } from 'react-redux';
import { useState } from 'react';
import { Toaster, toast } from 'sonner';
import { changePass } from '@/apis/index';

const History = () => {
    const userred = useSelector((state) => state.user);
    console.log(userred);
    const [formData, setFormData] = useState({
        oldPassword: '',
        newPassword: '',
        confirmPassword: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (formData.newPassword !== formData.confirmPassword) {
            toast.error('Mật khẩu xác nhận và mật khẩu mới không trùng khớp');
            return;
        }
        try {
            const data = {
                id: userred.userInfo.$id,
                oldPassword: formData.oldPassword,
                newPassword: formData.newPassword,
            };

            await changePass(data);
            toast.success('Đổi mật khẩu thành công');
        } catch {
            toast.error('Mật khẩu không chính xác');
        }
       
    };

    return (
        <div className="d-flex justify-content-center align-items-center" style={{ height: "75vh" }}>
            <Toaster richColors position="top-right" />
            <Sidebar />
            <div className="col-span-12 mt-6 d-flex justify-content-center sm:mt-0 lg:col-span-9" style={{ height: '65vh', width: "800px" }}>
                <div>
                    <h4>Đặt lại mật khẩu</h4>
                    <p>Để đảm bảo bảo mật tài khoản, vui lòng không tiết lộ mật khẩu cho bất kỳ ai</p>
                    <div className="text-center" style={{ height: '56.5vh', width: "450px", border: '1px solid #ddd', borderRadius: '8px', padding: '10px' }}>
                        <h5 className="mt-3">(+84) 348696887</h5>
                        <Form className="w-100" onSubmit={handleSubmit}>
                            <Form.Group className="mb-3 mt-4 d-flex flex-column">
                                <Form.Label className="mb-1 text-start">
                                    * Mật khẩu cũ
                                </Form.Label>
                                <Form.Control
                                    type="password"
                                    placeholder="Nhập mật khẩu cũ"
                                    name="oldPassword"
                                    value={formData.oldPassword}
                                    onChange={handleChange}
                                />
                            </Form.Group>
                            <Form.Group className="mb-3 mt-4 d-flex flex-column">
                                <Form.Label className="mb-1 text-start">
                                    * Mật khẩu mới
                                </Form.Label>
                                <Form.Control
                                    type="password"
                                    placeholder="Nhập mật khẩu mới"
                                    name="newPassword"
                                    value={formData.newPassword}
                                    onChange={handleChange}
                                />
                            </Form.Group>
                            <Form.Group className="mb-3 mt-4 d-flex flex-column">
                                <Form.Label className="mb-1 text-start">
                                    * Xác nhận mật khẩu
                                </Form.Label>
                                <Form.Control
                                    type="password"
                                    placeholder="Xác nhận mật khẩu"
                                    name="confirmPassword"
                                    value={formData.confirmPassword}
                                    onChange={handleChange}
                                />
                            </Form.Group>


                            <div>
                                <Button
                                    variant="danger"
                                    className="rounded-pill px-4 py-2 mx-2"
                                    type="submit"
                                >
                                    Lưu
                                </Button>
                                <Button
                                    variant="secondary"
                                    className="rounded-pill px-4 py-2"
                                >
                                    Hủy
                                </Button>
                            </div>
                        </Form>
                    </div>
                </div>
            </div>
        </div>
    );
};
export default History;