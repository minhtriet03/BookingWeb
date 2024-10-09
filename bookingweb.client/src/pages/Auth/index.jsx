import { useState } from 'react';
import Header from '@/component/Header';
import Footer from '@/component/Footer';
import { Container, Form, Button, Row, Col, Image, Tabs, Tab } from 'react-bootstrap';
import './Auth.css'; // Nhớ import file CSS ở đây

function Auth() {
  const [key, setKey] = useState('login');

  return (
    <>
      <Header />
      <Container
        style={{
          maxWidth: '1100px',
          width: '100%',
          padding: '15px',
          fontFamily: 'Arial',
        }}
      >
        <Row className="justify-content-center rounded-5 position-relative bg-white shadow" style={{ border: '1px solid #E33E0B',  top: '-90px',  }}>
          <Col md={7} className="pb-5" style={{ paddingLeft: '0px'}}>
            <Image src="https://cdn.futabus.vn/futa-busline-cms-dev/TVC_00aa29ba5b/TVC_00aa29ba5b.svg"  className="object-cove h-100 w-100" />
          </Col>

          <Col md={5} className='py-4'>
            <h3 className='text-center mb-4'>
              {key === 'login' ? 'Đăng nhập' : 'Đăng ký'}
            </h3>

            <Tabs
              id="auth-tabs"
              activeKey={key}
              onSelect={(k) => setKey(k)}
              className="mb-3 custom-tabs"
            >
              <Tab eventKey="login" title="Đăng nhập" className='tab-tittle'>
                <Form>
                  <Form.Group controlId="formBasicEmail">
                    <Form.Control type="email" placeholder="Nhập email" className='mb-4' />
                  </Form.Group>

                  <Form.Group controlId="formBasicPassword">
                    <Form.Control type="password" placeholder="Nhập mật khẩu" />
                  </Form.Group>

                  <Button variant="" type="submit" className='w-100 my-4 rounded-pill' style={{ backgroundColor: '#EA4C0F', color: 'white' }}>
                    Đăng nhập
                  </Button>
                  <a className="" style={{ color: '#EA4C0F', fontWeight: '500', textDecoration: 'none'}}>
                    Quên mật khẩu    
                  </a>
                </Form>
              </Tab>

              <Tab eventKey="register" title="Đăng ký" className='tab-tittle'>
                <Form>
                  <Form.Group controlId="formRegisterEmail">
                    <Form.Control type="email" placeholder="Nhập email" className='mb-4' />
                  </Form.Group>

                  <Form.Group controlId="formRegisterPassword">
                    <Form.Control type="password" placeholder="Nhập mật khẩu" className='mb-4'/>
                  </Form.Group>

                  <Form.Group controlId="formConfirmPassword">
                    <Form.Control type="password" placeholder="Nhập lại mật khẩu" />
                  </Form.Group>

                  <Button variant="" type="submit" className='w-100 my-4 rounded-pill' style={{ backgroundColor: '#EA4C0F', color: 'white' }}>
                    Đăng ký
                  </Button>
                </Form>
              </Tab>
            </Tabs>
          </Col>
        </Row>
      </Container>
      <Footer />
    </>
  );
}

export default Auth;
