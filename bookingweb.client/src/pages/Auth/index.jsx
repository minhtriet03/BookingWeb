import { useState } from 'react';
import { Container, Form, Button, Row, Col, Image, Tabs, Tab } from 'react-bootstrap';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { loginUser } from '@/redux/actions/authAction'; 
import { registerUser } from '@/apis';
import { SetUser } from '@/redux/actions/UserAction';
import { useSelector } from 'react-redux';
import './Auth.css';

function Auth() {
    const [key, setKey] = useState('login'); 
    const [formData, setFormData] = useState({
        email: '',
        password: '',
        confirmPassword: '',
    });

    const dispatch = useDispatch();
    const navigate = useNavigate();

    const userred = useSelector((state) => state.user.userInfo);
    console.log("userInfooo", userred?.hoTen);



    // const { auth } = useSelector(x => x.auth);

    // Xử lý khi form được submit
    const handleSubmit = async (e) => {
        e.preventDefault();
    
        try {
            if (key === 'login') {
                const actionResult = await dispatch(loginUser({ 
                    email: formData.email, 
                    password: formData.password 
                }));

                console.log(actionResult);
    
                if (actionResult.type === 'auth/login/fulfilled') {
                    await dispatch(SetUser());
                   
                     navigate('/');
                } else {
                    console.error('Đăng nhập thất bại:', actionResult.error?.message || 'Không rõ nguyên nhân');
                }
            } else if (key === 'register') {
                if (formData.password !== formData.confirmPassword) {
                    alert('Mật khẩu không khớp!');
                    return;
                }  
                try {
                    // Gọi API đăng ký tài khoản
                    const result = await registerUser({ UserName: formData.email, Password: formData.password });
                    alert('Đăng ký thành công!');
                    if (result) {
                        navigate('/dang-nhap');
                    }
                    else {
                        alert('Đăng ký thất bại!');
                    }
                    
                } catch (error) {
                    console.error('Đăng ký thất bại:', error)
                    
                }
            }
        } catch (error) {
            console.error('Lỗi xảy ra:', error);
        }
    };




    // Xử lý khi người dùng nhập form
    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    return (
        <Container
            style={{
                maxWidth: '1100px',
                width: '100%',
                padding: '15px',
                fontFamily: 'Arial',
            }}
        >
            <Row className="justify-content-center rounded-5 position-relative bg-white shadow" style={{ border: '1px solid #E33E0B', top: '-90px' }}>
                <Col md={7} className="pb-5" style={{ paddingLeft: '0px' }}>
                    <Image src="https://cdn.futabus.vn/futa-busline-cms-dev/TVC_00aa29ba5b/TVC_00aa29ba5b.svg" className="object-cover h-100 w-100" />
                </Col>

                <Col md={5} className="py-4">
                    <h3 className="text-center mb-4">{key === 'login' ? 'Đăng nhập' : 'Đăng ký'}</h3>

                    <Tabs
                        id="auth-tabs"
                        activeKey={key}
                        onSelect={(k) => setKey(k)}
                        className="mb-3 custom-tabs"
                    >
                        {/* Tab Đăng nhập */}
                        <Tab eventKey="login" title="Đăng nhập" className="tab-title">
                            <Form onSubmit={handleSubmit}>
                                <Form.Group controlId="formBasicEmail">
                                    <Form.Control
                                        type="email"
                                        placeholder="Nhập email"
                                        className="mb-4"
                                        name="email"
                                        value={formData.email}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>

                                <Form.Group controlId="formBasicPassword">
                                    <Form.Control
                                        type="password"
                                        placeholder="Nhập mật khẩu"
                                        name="password"
                                        value={formData.password}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>

                                <Button
                                    variant=""
                                    type="submit"
                                    className="w-100 my-4 rounded-pill"
                                    style={{ backgroundColor: '#EA4C0F', color: 'white' }}
                                >
                                    Đăng nhập
                                </Button>
                                <a style={{ color: '#EA4C0F', fontWeight: '500', textDecoration: 'none' }}>
                                    Quên mật khẩu
                                </a>
                            </Form>
                        </Tab>

                        {/* Tab Đăng ký */}
                        <Tab eventKey="register" title="Đăng ký" className="tab-title">
                            <Form onSubmit={handleSubmit}>
                                <Form.Group controlId="formRegisterEmail">
                                    <Form.Control
                                        type="email"
                                        placeholder="Nhập email"
                                        className="mb-4"
                                        name="email"
                                        value={formData.email}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>

                                <Form.Group controlId="formRegisterPassword">
                                    <Form.Control
                                        type="password"
                                        placeholder="Nhập mật khẩu"
                                        className="mb-4"
                                        name="password"
                                        value={formData.password}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>

                                <Form.Group controlId="formConfirmPassword">
                                    <Form.Control
                                        type="password"
                                        placeholder="Nhập lại mật khẩu"
                                        name="confirmPassword"
                                        value={formData.confirmPassword}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>

                                <Button
                                    variant=""
                                    type="submit"
                                    className="w-100 my-4 rounded-pill"
                                    style={{ backgroundColor: '#EA4C0F', color: 'white' }}
                                >
                                    Đăng ký
                                </Button>
                            </Form>
                        </Tab>
                    </Tabs>
                </Col>
            </Row>
        </Container>
    );
}

export default Auth;
