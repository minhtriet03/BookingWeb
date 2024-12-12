import Image from 'react-bootstrap/Image';
import { Carousel, Row, Col } from 'react-bootstrap';
import './PromoSection.css'; // Ensure you have created and imported this CSS file

function PromoSection() {
    return (
        <>
            <h2 className="home-title text-green">KHUYẾN MÃI</h2>
            <Carousel style={{ zIndex: '-999', marginBottom: '50px' }}>
                <Carousel.Item>
                    <Row>
                        <Col xs={6} md={4}>
                            <Image
                                src="https://cdn.futabus.vn/futa-busline-web-cms-prod/343_x_184_px_x4_4fd05509ef/343_x_184_px_x4_4fd05509ef.jpg"
                                rounded
                                className="promo-image shadow"
                            />
                        </Col>
                        <Col xs={6} md={4}>
                            <Image
                                src="https://cdn.futabus.vn/futa-busline-web-cms-prod/2_343_x_184_px_f365e0f9c8/2_343_x_184_px_f365e0f9c8.png"
                                rounded
                                className="promo-image shadow"
                            />
                        </Col>
                        <Col xs={6} md={4}>
                            <Image
                                src="https://cdn.futabus.vn/futa-busline-web-cms-prod/343_x_184_px_0b1588190d/343_x_184_px_0b1588190d.png"
                                rounded
                                className="promo-image shadow"
                            />
                        </Col>
                    </Row>
                </Carousel.Item>
                <Carousel.Item>
                    <Row>
                        <Col xs={6} md={4}>
                            <Image
                                src="https://cdn.futabus.vn/futa-busline-web-cms-prod/VNPAYFUTA_67_Resize_343_x_184_bd2e13cd77/VNPAYFUTA_67_Resize_343_x_184_bd2e13cd77.png"
                                rounded
                                className="promo-image shadow"
                            />
                        </Col>
                        <Col xs={6} md={4}>
                            <Image
                                src="https://cdn.futabus.vn/futa-busline-cms-dev/343x184_4x_29d182ce55/343x184_4x_29d182ce55.png"
                                rounded
                                className="promo-image shadow"
                            />
                        </Col>
                        <Col xs={6} md={4}>
                            <Image
                                src="https://cdn.futabus.vn/futa-busline-web-cms-prod/343x184_ea6055b4a6/343x184_ea6055b4a6.png"
                                rounded
                                className="promo-image shadow"
                            />
                        </Col>
                    </Row>
                </Carousel.Item>
                <Carousel.Item>
                    <Row>
                        <Col xs={6} md={4}>
                            <Image
                                src="https://cdn.futabus.vn/futa-busline-cms-dev/343x184_4x_29d182ce55/343x184_4x_29d182ce55.png"
                                rounded
                                className="promo-image shadow"
                            />
                        </Col>
                        <Col xs={6} md={4}>
                            <Image
                                src="https://cdn.futabus.vn/futa-busline-web-cms-prod/Zalo_11b66ecb81/Zalo_11b66ecb81.png"
                                rounded
                                className="promo-image shadow"
                            />
                        </Col>
                        <Col xs={6} md={4}>
                            <Image
                                src="https://cdn.futabus.vn/futa-busline-cms-dev/Banner_FUTA_Pay_2_57b0471834/Banner_FUTA_Pay_2_57b0471834.png"
                                rounded
                                className="promo-image shadow"
                            />
                        </Col>
                    </Row>
                </Carousel.Item>
            </Carousel>
        </>
    );
}

export default PromoSection;
