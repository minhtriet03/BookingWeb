import { Button, Row, Col, Form } from 'react-bootstrap';
import './SearchForm.css';

function SearchForm() {
  return (
    <div className="home-search position-relative z-30 t-" style={{ top: '-90px' }}>

      <div className="banner shadow-sm position-relative mx-auto mb-4 mt-0 d-none d-lg-flex h-250 w-100 cursor-pointer rounded-5 overflow-hidden">
        <img
          alt=""
          loading="lazy"
          decoding="async"
          className="transition-all duration-200 shadow-lg position-absolute d-none d-lg-flex h-100 w-100 rounded object-cover"
          style={{ inset: 0, color: 'transparent' }}
          src="https://cdn.futabus.vn/futa-busline-web-cms-prod/web_ca16250b69/web_ca16250b69.png"
        />
      </div>


      <div className="search-form m-2 fw-semibold mx-lg-auto xl-w-1128 h-200">
        <div className="d-flex align-items-center justify-content-between text-15 w-100">
          <Form>
            <div className="btn-group btn-group-toggle " data-toggle="buttons">
              <Form.Check
                type="radio"
                id="oneWay"
                name="tripType"
                label="Một chiều"
                defaultChecked
                className="flex-grow-1 mx-2 "
              />
              <Form.Check
                type="radio"
                id="roundTrip"
                name="tripType"
                label="Khứ hồi"
                className="flex-grow-1 mx-2"
              />
            </div>
          </Form>

          <span className="d-none d-lg-inline-block text-warning ">
            <a target="_blank" rel="noreferrer" href="/huong-dan-dat-ve-tren-web" className="text-decoration-none" style={{ color: '#EF5222', fontWeight: '600' }}>
              Hướng dẫn mua vé
            </a>
          </span>
        </div>

        <Row className="py-3 w-100 mb-4">
          <Col lg={12} className="d-flex justify-content-between">
            <div className="flex-grow-1 mx-2">
              <Form.Label>Điểm đi</Form.Label>
              <Form.Control
                type="text"
                placeholder="Chọn điểm đi"
                aria-label="Chọn điểm đi"
                readOnly
                size='lg'
              />
            </div>

            <img
              className="position-relative bottom-6 h-8 w-8 d-lg-none"
              src="https://futabus.vn/images/icons/switch_location.svg"
            />

            <div className="flex-grow-1 mx-2 text-right text-lg-left">
              <Form.Label>Điểm đến</Form.Label>
              <Form.Control
                type="text"
                placeholder="Chọn điểm đến"
                aria-label="Chọn điểm đến"
                readOnly
                size='lg'
              />
            </div>

            <div className="flex-grow-1 mx-2">
              <Form.Label>Ngày đi</Form.Label>
              <Form.Control
                type="text"
                placeholder=""
                aria-label="Chọn ngày đi"
                readOnly
                size='lg'
              />
            </div>

            <div className="flex-grow-1 mx-2">
              <Form.Label>Số vé</Form.Label>
              <Form.Select aria-label="" size="lg">
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
              </Form.Select>
            </div>
          </Col>

        </Row>

        <div className="d-flex justify-content-center position-absolute " style={{ width: '250px', height: '48px', bottom: '-15px' }}>
          <Button className="text-white w-100 rounded-pill px-4  " variant='' style={{ backgroundColor: '#EF5222' }}>Tìm chuyến xe</Button>
        </div>
      </div>

    </div>
  );
};

export default SearchForm;
