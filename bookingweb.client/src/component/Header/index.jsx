import { Navbar, Nav, Container, Button } from 'react-bootstrap';
import './header.css'; // Đường dẫn tới file CSS của bạn

const MyNavbar = () => {
  return (
    <>
      <div className="top-zero" style={{ backgroundColor: '#F56516' }}>
        {/* Navbar chính */}
        <Navbar expand="lg">
          <Container>
            {/* Logo */}
            <Navbar.Brand href="/">
              <img
                src="/_next/static/media/logo_new.8a0251b8.svg"
                alt="logo_banner"
                width="295"
                height="60"
              />
            </Navbar.Brand>

            <Navbar.Collapse id="basic-navbar-nav" className="justify-content-end">
              <Nav>
                <Button variant="outline-light" className="d-flex align-items-center">
                  <span className="mx-2">Đăng nhập/Đăng ký</span>
                </Button>
              </Nav>
            </Navbar.Collapse>
          </Container>
        </Navbar>

        <div className="py-2">
          <Container>
            <Nav className="justify-content-center">
              <Nav.Link href="/" className="navtittle">Trang chủ</Nav.Link>
              <Nav.Link href="/lich-trinh" className="text-white navtittle">Lịch trình</Nav.Link>
              <Nav.Link href="/tra-cuu-ve" className="text-white navtittle">Tra cứu vé</Nav.Link>
              <Nav.Link href="/tin-tuc" className="text-white navtittle">Tin tức</Nav.Link>
              <Nav.Link href="https://hoadon.futabus.vn/#/tracuuhoadon/tracuu" target="_blank" className="text-white navtittle">Hóa đơn</Nav.Link>
              <Nav.Link href="/lien-he" className="text-white navtittle">Liên hệ</Nav.Link>
              <Nav.Link href="/ve-chung-toi" className="text-white navtittle">Về chúng tôi</Nav.Link>
            </Nav>
          </Container>
        </div>
      </div>
    </>
  );
};

export default MyNavbar;
