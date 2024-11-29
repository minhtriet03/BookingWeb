import Sidebar from "./Sidebar/index";
import { Form, Button, Col, Row } from 'react-bootstrap';

const History = () => {
    return (
        <div
            className="d-flex justify-content-center align-items-center"
            style={{ height: "75vh" }}
        >
            <Sidebar />
            <div className="col-span-12 mt-6 d-flex justify-content-center sm:mt-0 lg:col-span-9" style={{ height: '65vh', width: "800px" }}>
                <div>
                    <h4>Đặt lại mật khẩu</h4>
                    <p>Để đảm bảo bảo mật tài khoản, vui lòng không tiết lộ mật khẩu cho bất kì ai</p>
                    <div className="text-center" style={{ height: '56.5vh', width:"450px", border: '1px solid #ddd', borderRadius: '8px', padding: '10px' }}>
                        <h5 className="mt-3">(+84) 348696887</h5>
                        <Form className="w-100">
                            <Form.Group className="mb-3 mt-4 d-flex flex-column">
                                <Form.Label className="mb-1 text-start">
                                    * Mật khẩu cũ
                                </Form.Label>
                                <Form.Control
                                    type="password"
                                    placeholder="Nhập mật khẩu cũ"
                                />
                            </Form.Group>
                            <Form.Group className="mb-3 mt-4 d-flex flex-column">
                                <Form.Label className="mb-1 text-start">
                                    * Mật khẩu mới
                                </Form.Label>
                                <Form.Control
                                    type="password"
                                    placeholder="Nhập mật khẩu mới"
                                />
                            </Form.Group>
                            <Form.Group className="mb-3 mt-4 d-flex flex-column">
                                <Form.Label className="mb-1 text-start">
                                    * Xác nhận mật khẩu
                                </Form.Label>
                                <Form.Control
                                    type="password"
                                    placeholder="Xác nhận mật khẩu"
                                />
                            </Form.Group>
                        </Form>
                        <div>
                            <Button
                                variant="danger"
                                className="rounded-pill px-4 py-2 mx-2"
                             
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
                    </div>
                    
                </div>           
            </div>
            
        </div>
    );
};
export default History;