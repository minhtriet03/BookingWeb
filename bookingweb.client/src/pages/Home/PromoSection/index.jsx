import Image from 'react-bootstrap/Image';
import { Carousel, Row, Col } from 'react-bootstrap';
import './PromoSection.css'; // Đảm bảo bạn đã tạo file CSS và import vào đây

function PromoSection() {
  return (
    <>
      <Carousel>
        <Carousel.Item>
          <Row>
            <Col xs={6} md={4}>
              <Image src="holder.js/350x190" rounded className="promo-image shadow" />
            </Col>
            <Col xs={6} md={4}>
              <Image src="holder.js/350x190" rounded className="promo-image shadow" />
            </Col>
            <Col xs={6} md={4}>
              <Image src="holder.js/350x190" rounded className="promo-image shadow" />
            </Col>
          </Row>
        </Carousel.Item>
        <Carousel.Item>
          <Row>
            <Col xs={6} md={4}>
              <Image src="holder.js/350x190" rounded className="promo-image shadow" />
            </Col>
            <Col xs={6} md={4}>
              <Image src="holder.js/350x190" rounded className="promo-image shadow" />
            </Col>
            <Col xs={6} md={4}>
              <Image src="holder.js/350x190" rounded className="promo-image shadow" />
            </Col>
          </Row>
        </Carousel.Item>
        <Carousel.Item>
          <Row>
            <Col xs={6} md={4}>
              <Image src="holder.js/350x190" rounded className="promo-image shadow" />
            </Col>
            <Col xs={6} md={4}>
              <Image src="holder.js/350x190" rounded className="promo-image shadow" />
            </Col>
            <Col xs={6} md={4}>
              <Image src="holder.js/350x190" rounded className="promo-image shadow" />
            </Col>
          </Row>
        </Carousel.Item>


      </Carousel>
    </>
  );
}

export default PromoSection;
