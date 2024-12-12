import { Row, Col, Form } from 'react-bootstrap';
import './footer.css'; // Đảm bảo rằng bạn đã tạo file CSS và import vào đây
import { MDBFooter, MDBContainer, MDBRow, MDBCol, MDBIcon } from 'mdb-react-ui-kit';

function Footer() {
    return (
        <MDBFooter bgColor='light' className='text-center text-lg-start text-muted'>
            <section className='d-flex justify-content-center justify-content-lg-between p-4 border-bottom'>
                <div className='me-5 d-none d-lg-block'>
                    <span>Theo dõi chúng tôi trên mạng xã hội:</span>
                </div>

                <div>
                    <a href='' className='me-4 text-reset'>
                        <MDBIcon fab icon="facebook-f" />
                    </a>
                    <a href='' className='me-4 text-reset'>
                        <MDBIcon fab icon="twitter" />
                    </a>
                    <a href='' className='me-4 text-reset'>
                        <MDBIcon fab icon="google" />
                    </a>
                    <a href='' className='me-4 text-reset'>
                        <MDBIcon fab icon="instagram" />
                    </a>
                </div>
            </section>

            <section className=''>
                <MDBContainer className='text-center text-md-start mt-5'>
                    <MDBRow className='mt-3'>
                        <MDBCol md="3" lg="4" xl="3" className='mx-auto mb-4'>
                            <h6 className='text-uppercase fw-bold mb-4'>
                                <MDBIcon icon="bus" className="me-3" />
                                Đặt vé xe
                            </h6>
                            <p>
                                Đặt vé xe nhanh chóng và dễ dàng với chúng tôi.
                            </p>
                        </MDBCol>

                        <MDBCol md="2" lg="2" xl="2" className='mx-auto mb-4'>
                            <h6 className='text-uppercase fw-bold mb-4'>Dịch vụ</h6>
                            <p>
                                <a href='#!' className='text-reset'>
                                    Đặt vé xe
                                </a>
                            </p>
                            <p>
                                <a href='#!' className='text-reset'>
                                    Thông tin chuyến xe
                                </a>
                            </p>
                            <p>
                                <a href='#!' className='text-reset'>
                                    Hỗ trợ
                                </a>
                            </p>
                        </MDBCol>

                        <MDBCol md="3" lg="2" xl="2" className='mx-auto mb-4'>
                            <h6 className='text-uppercase fw-bold mb-4'>Liên hệ</h6>
                            <p>
                                <MDBIcon icon="home" className="me-2" />
                                Hà Nội, Việt Nam
                            </p>
                            <p>
                                <MDBIcon icon="envelope" className="me-3" />
                                info@datvexe.com
                            </p>
                            <p>
                                <MDBIcon icon="phone" className="me-3" /> + 84 123 456 789
                            </p>
                        </MDBCol>

                        <MDBCol md="4" lg="3" xl="3" className='mx-auto mb-md-0 mb-4'>
                            <h6 className='text-uppercase fw-bold mb-4'>Chính sách</h6>
                            <p>
                                <a href='#!' className='text-reset'>
                                    Chính sách bảo mật
                                </a>
                            </p>
                            <p>
                                <a href='#!' className='text-reset'>
                                    Chính sách hoàn tiền
                                </a>
                            </p>
                        </MDBCol>
                    </MDBRow>
                </MDBContainer>
            </section>

            <div className='text-center p-4' style={{ backgroundColor: 'rgba(0, 0, 0, 0.05)' }}>
                2023 Copyright:
                <a className='text-reset fw-bold' href='https://datvexe.com/'>
                    Đặt vé xe
                </a>
            </div>
        </MDBFooter>
    );
}

export default Footer;