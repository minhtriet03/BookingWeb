import { Navbar, Nav, Container, Button } from 'react-bootstrap';
import './header.css'; // Đường dẫn tới file CSS của bạn
import homeBanner from '@/assets/image/homeBanner.png';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { SetUser } from '@/redux/actions/UserAction';
import { logout } from '@/redux/actions/authAction';
import { useSelector } from 'react-redux';
function Header () {
    const navigate = useNavigate(); 
    const dispatch = useDispatch();
    

  const handleClick = () => {
    navigate('/dang-nhap'); 
    };
<<<<<<< HEAD

=======
>>>>>>> 35d812ffe9eedbf4753bd9855622388b6880697a

    const handleClickLogout = async () => {
        const result = await dispatch(logout());
        if (logout.fulfilled.match(result)) {
            await dispatch(SetUser());
            navigate("/dang-nhap");
        }
    };

    const isLogin = useSelector((state) => state.auth.isAuthenticated);
  return (
    <>
          <div className="top-zero" style={{ backgroundImage: `url(${homeBanner})`, minHeight: '200px' }}>
        {/* Navbar chính */}
        <Navbar expand="lg" className="pt-0">
          <Container className="top-0">
            {/* Logo */}
            <Navbar.Brand href="/" className="pt-0">
              <img
                src="https://futabus.vn/_next/static/media/logo_new.8a0251b8.svg"
                alt="logo_banner"
                width="295"
                height="60"
              />
            </Navbar.Brand>

            <Navbar.Collapse id="basic-navbar-nav" className="justify-content-end">
              <Nav>
                              { !isLogin ? (
                <Button variant="outline-light" className="d-flex align-items-center" onClick={handleClick}>
                  <span className="mx-2">Đăng nhập/Đăng ký</span>
                 </Button>
                 ) : (
                 <Button variant="outline-light" className="d-flex align-items-center" onClick={handleClickLogout}>
                  <span className="mx-2">Đăng xuất</span>
                                  </Button>
                )}
              </Nav>
            </Navbar.Collapse>
          </Container>
        </Navbar>

        <div className="pt-1">
          <Container>
            <Nav className="justify-content-around px-5 mx-5">
              <Nav.Link href="/" className="navtittle">TRANG CHỦ</Nav.Link>
              <Nav.Link href="/lich-trinh" className="navtittle">LỊCH TRÌNH</Nav.Link>
              <Nav.Link href="/tra-cuu-ve" className="navtittle">TRA CỨU VÉ</Nav.Link>
              <Nav.Link href="/tin-tuc" className=" navtittle">TIN TỨC</Nav.Link>
              <Nav.Link href="" target="_blank" className="navtittle">HÓA ĐƠN</Nav.Link>
              <Nav.Link href="/lien-he" className="navtittle">LIÊN HỆ</Nav.Link>
              <Nav.Link href="/ve-chung-toi" className="navtittle">VỀ CHÚNG TÔI</Nav.Link>
            </Nav>
          </Container>
        </div>
      </div>
    </>
  );
};

export default Header;
