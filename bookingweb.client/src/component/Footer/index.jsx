import { Row, Col, Button, Form } from 'react-bootstrap';
import './footer.css'; // Đảm bảo rằng bạn đã tạo file CSS và import vào đây

function Footer() {
  return (
    <footer className='bottom-zero content'>
        <Row>
          <Col lg={4}>
            <h3>Futa</h3>
            <p>Futa là một ứng dụng đặt xe</p>
          </Col>
          <Col lg={4}>
            <h3>Liên hệ</h3>
            <p>
              <i className="fa fa-map-marker"></i>
              123 đường abc, quận 1, tp.hcm
            </p>
            <p>
              <i className="fa fa-phone"></i>
              0123456789
            </p>
            <p>
              <i className="fa fa-envelope"></i>
              email@example.com {/* Thay thế bằng email thực */}
            </p>
          </Col>
          <Col lg={4}>
            <h3>Đăng ký nhận tin</h3>
            <Form.Control type="text" placeholder="Nhập email của bạn" className="mb-2" />
          </Col>
        </Row>
    </footer>
  );
}

export default Footer;
