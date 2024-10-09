import { Button, Row, Col, Form } from 'react-bootstrap';
import './SearchForm.css';

const SearchForm = () => {
  return (
    <div className="home-search position-relative z-30 t-" style={{ top: '-90px'}}>

      <div className="banner shadow-sm position-relative mx-auto mb-4 mt-0 d-none d-lg-flex h-250 w-100 cursor-pointer rounded object-cover">
        <img
          alt=""
          loading="lazy"
          decoding="async"
          className="transition-all duration-200 shadow-lg position-absolute mx-auto mb-4 d-none d-lg-flex h-100 w-100 rounded object-cover"
          style={{ inset: 0, color: 'transparent' }}
          src="https://cdn.futabus.vn/futa-busline-web-cms-prod/web_ca16250b69/web_ca16250b69.png"
        />
      </div>

      <div className="search-form m-2 font-weight-medium mx-lg-auto xl-w-1128">
        <div className="d-flex align-items-center justify-content-between text-15 w-100">
          <Form>
            <div className="btn-group btn-group-toggle " data-toggle="buttons">
              <Form.Check
                type="radio"
                id="oneWay"
                name="tripType"
                label="Một chiều"
                defaultChecked
                className="flex-grow-1 mx-2"
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

          <span className="d-none d-lg-inline-block font-weight-medium text-warning ">
            <a target="_blank" rel="noreferrer" href="/huong-dan-dat-ve-tren-web" className="text-decoration-none" style={{color: '#EF5222', fontWeight:'600'}}>
              Hướng dẫn mua vé
            </a>
          </span>
        </div>

        <Row className="py-4 w-100">
          <Col lg={6} className="d-flex justify-content-between">
            <div className="flex-grow-1 mx-2">
              <Form.Label>Điểm đi</Form.Label>
              <div className="form-control mt-1 cursor-pointer font-weight-medium text-secondary">
                <span className="text-truncate">Chọn điểm đi</span>
              </div>
            </div>

            <img
              className="position-relative bottom-6 h-8 w-8 d-lg-none"
              src="./images/icons/switch_location.svg"
              alt="switch location icon"
            />

            <div className="flex-grow-1 mx-2 text-right text-lg-left">
              <Form.Label>Điểm đến</Form.Label>
              <div className="form-control mt-1 cursor-pointer font-weight-medium text-secondary">
                <span className="text-truncate">Chọn điểm đến</span>
              </div>
            </div>
          </Col>

          <Col lg={6} className="d-flex">
            <div className="flex-grow-1 mx-2">
              <Form.Label>Ngày đi</Form.Label>
              <div className="form-control mt-1 cursor-pointer font-weight-medium text-base">
                <small className="text-muted">Thứ 3</small>
              </div>
            </div>

            <div className="flex-grow-1 mx-2">
              <Form.Label>Số vé</Form.Label>
              <div className="form-control mt-1 d-flex justify-content-between align-items-center">
                <span>1</span>
                <img src="./images/icons/arrow_down_select.svg" alt="" />
              </div>
            </div>
          </Col>
        </Row>

        <div className="d-flex justify-content-center position-absolute " style={{ width: '250px', height:'48px', bottom: '-15px'}}>
          <Button className="text-white w-100 rounded-pill px-4  " variant='' style={{ backgroundColor: '#EF5222' }}>Tìm chuyến xe</Button>
        </div>
      </div>

    </div>
  );
};

export default SearchForm;
