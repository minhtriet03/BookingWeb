import { useState, useEffect } from 'react';
import { Button, Row, Col, Form } from 'react-bootstrap';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import './SearchForm.css';
import SelectForm from './SelectForm';
import switchIcon from '@/assets/image/switch_location.svg';

function SearchForm() {
  const [showSelectDeparture, setShowSelectDeparture] = useState(false);
  const [showSelectDestination, setShowSelectDestination] = useState(false);
  const [showDatePicker, setShowDatePicker] = useState(false);
  const [selectedDate, setSelectedDate] = useState(null);

  // Function to hide all forms when clicking outside
  const handleClickOutside = (e) => {
    if (!e.target.closest('.form-control') && !e.target.closest('.select-form') && !e.target.closest('.date-picker-container')) {
      setShowSelectDeparture(false);
      setShowSelectDestination(false);
      setShowDatePicker(false);
    }
  };

  // Add event listener to detect clicks outside the form
  useEffect(() => {
    document.addEventListener('click', handleClickOutside);
    return () => {
      document.removeEventListener('click', handleClickOutside);
    };
  }, []);

  const handleSelectDeparture = () => {
    // Hide the departure form after selecting an item
    setShowSelectDeparture(false);
  };

  const handleSelectDestination = () => {
    // Hide the destination form after selecting an item
    setShowSelectDestination(false);
  };

  const handleSelectDate = (date) => {
    setSelectedDate(date);
    // Hide the date picker after selecting a date
    setShowDatePicker(false);
  };

  const handleFocusDeparture = () => {
    setShowSelectDeparture(true);
    setShowSelectDestination(false);
    setShowDatePicker(false);
  };

  const handleFocusDestination = () => {
    setShowSelectDestination(true);
    setShowSelectDeparture(false);
    setShowDatePicker(false);
  };

  const handleFocusDate = () => {
    setShowDatePicker(true);
    setShowSelectDeparture(false);
    setShowSelectDestination(false);
  };

  return (
    <div className="home-search position-relative z-30" style={{ top: '-90px' }}>
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

      <div className="search-form m-2 fw-semibold mx-lg-auto w-100 h-100">
        <div className="d-flex align-items-center justify-content-between text-15 w-100">
          <Form>
            <div className="btn-group btn-group-toggle" data-toggle="buttons">
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

          <span className="d-none d-lg-inline-block text-warning">
            <a target="_blank" rel="noreferrer" href="/huong-dan-dat-ve-tren-web" className="text-decoration-none" style={{ color: '#EF5222', fontWeight: '600' }}>
              Hướng dẫn mua vé
            </a>
          </span>
        </div>

        <Row className="py-3 w-100 mb-4 row">
          <Col lg={12} className="d-flex justify-content-between">
            <div className="flex-grow-1 mx-2 position-relative">
              <Form.Label>Điểm đi</Form.Label>
              <Form.Control
                type="text"
                placeholder="Chọn điểm đi"
                aria-label="Chọn điểm đi"
                size="lg"
                className="control-custom"
                onFocus={handleFocusDeparture}
              />
              <div className={`select-form ${showSelectDeparture ? 'show' : ''}`}>
                <SelectForm onSelect={handleSelectDeparture} />
              </div>
            </div>

            <div className="flex-grow-1 position-relative">
              <img className="switch-location" src={switchIcon} alt="switch location icon" />
            </div>

            <div className="flex-grow-1 mx-2 text-right text-lg-left position-relative">
              <Form.Label>Điểm đến</Form.Label>
              <Form.Control
                type="text"
                placeholder="Chọn điểm đến"
                aria-label="Chọn điểm đến"
                size="lg"
                className="control-custom"
                onFocus={handleFocusDestination}
              />
              <div className={`select-form ${showSelectDestination ? 'show' : ''}`}>
                <SelectForm onSelect={handleSelectDestination} />
              </div>
            </div>

            <div className="flex-grow-1 mx-2 position-relative">
              <Form.Label>Ngày đi</Form.Label>
              <Form.Control
                type="text"
                placeholder={selectedDate ? selectedDate.toLocaleDateString() : "Chọn ngày đi"}
                aria-label="Chọn ngày đi"
                readOnly
                size="lg"
                onFocus={handleFocusDate}
              />
              {showDatePicker && (
                <div className="date-picker-container">
                  <DatePicker
                    selected={selectedDate}
                    onChange={handleSelectDate}
                    inline
                  />
                </div>
              )}
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

        <div className="d-flex justify-content-center position-absolute" style={{ width: '250px', height: '48px', bottom: '-15px' }}>
          <Button className="text-white w-100 rounded-pill px-4" variant="" style={{ backgroundColor: '#EF5222' }}>
            Tìm chuyến xe
          </Button>
        </div>
      </div>
    </div>
  );
}

export default SearchForm;
