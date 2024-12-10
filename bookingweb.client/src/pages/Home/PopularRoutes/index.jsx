import { Card, Row, Col, Image } from 'react-bootstrap';

const PopularRoutes = () => {
  const routes = [
    {
      from: 'Tp Hồ Chí Minh',
      destinations: [
        { to: 'Đà Lạt', price: '290.000đ', distance: '305km', duration: '8 giờ', date: '16/10/2024' },
        { to: 'Cần Thơ', price: '165.000đ', distance: '166km', duration: '3 giờ 12 phút', date: '16/10/2024' },
        { to: 'Long Xuyên', price: '190.000đ', distance: '203km', duration: '5 giờ', date: '16/10/2024' },
      ],
      image: 'https://cdn.futabus.vn/futa-busline-cms-dev/Rectangle_23_2_8bf6ed1d78/Rectangle_23_2_8bf6ed1d78.png'
    },
    {
      from: 'Đà Lạt',
      destinations: [
        { to: 'TP. Hồ Chí Minh', price: '290.000đ', distance: '310km', duration: '8 giờ', date: '16/10/2024' },
        { to: 'Đà Nẵng', price: '410.000đ', distance: '757km', duration: '17 giờ', date: '16/10/2024' },
        { to: 'Cần Thơ', price: '435.000đ', distance: '457km', duration: '11 giờ', date: '16/10/2024' },
      ],
      image: 'https://cdn.futabus.vn/futa-busline-cms-dev/Rectangle_23_3_2d8ce855bc/Rectangle_23_3_2d8ce855bc.png'
    },
    {
      from: 'Đà Nẵng',
      destinations: [
        { to: 'Đà Lạt', price: '410.000đ', distance: '666km', duration: '17 giờ', date: '16/10/2024' },
        { to: 'BX An Sương', price: '410.000đ', distance: '966km', duration: '20 giờ', date: '16/10/2024' },
        { to: 'Nha Trang', price: '300.000đ', distance: '528km', duration: '9 giờ 25 phút', date: '16/10/2024' },
      ],
      image: 'https://cdn.futabus.vn/futa-busline-cms-dev/Rectangle_23_4_061f4249f6/Rectangle_23_4_061f4249f6.png'
    }
  ];

  return (
    <div className="layout mt-8">
      <h2 className="home-title text-green">TUYẾN PHỔ BIẾN</h2>
      <p className="home-title-content">Được khách hàng tin tưởng và lựa chọn</p>
      <Row className="no-scrollbar overflow-x-auto overflow-y-hidden pl-4 sm:justify-between sm:px-0">
        {routes.map((route, index) => (
          <Col xs={12} md={4} className="mb-4" key={index}>
            <Card className="popular-route-card card-box-shadow cursor-pointer">
              <Image src={route.image} alt="" width="360" height="140" fluid />
              <Card.ImgOverlay className="text-white py-2" style={{ left: '16px', top: '64px' }}>
                <Card.Title className="text-[15px]">Tuyến xe từ</Card.Title>
                <Card.Text className="text-xl font-semibold">{route.from}</Card.Text>
              </Card.ImgOverlay>
              <Card.Body className="max-h-64 overflow-y-auto">
                {route.destinations.map((dest, idx) => (
                  <div className="flex flex-col border-bottom p-4" key={idx}>
                    <div className="d-flex justify-content-between">
                      <span className="text-green text-lg font-medium">{dest.to}</span>
                      <span className="text-[15px] font-medium text-black">{dest.price}</span>
                    </div>
                    <span className="text-gray text-[15px]">{dest.distance} - {dest.duration} - {dest.date}</span>
                  </div>
                ))}
              </Card.Body>
            </Card>
          </Col>
        ))}
      </Row>
    </div>
  );
};

export default PopularRoutes;
