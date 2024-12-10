import { useState } from 'react';
import { Link } from 'react-router-dom';
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
    const [showReturnDatePicker, setShowReturnDatePicker] = useState(false);
    const [selectedDeparture, setSelectedDeparture] = useState(null); // State cho điểm đi
    const [selectedDestination, setSelectedDestination] = useState(null); // State cho điểm đến
    const [selectedDate, setSelectedDate] = useState(null);
    const [returnDate, setReturnDate] = useState(null);
    const [tripType, setTripType] = useState("oneWay"); // Default is one way

    console.log("selectedDate", selectedDate);

    const handleTripTypeChange = (type) => {
        setTripType(type);
        if (type === "oneWay") {
            setReturnDate(null); // Clear return date when switching back to one-way
        }
    };
    const handleSelectDeparture = (tinh) => {
        setSelectedDeparture(tinh); // Cập nhật điểm đi
        setShowSelectDeparture(false);
    };

    const handleSelectDestination = (tinh) => {
        setSelectedDestination(tinh); // Cập nhật điểm đến
        setShowSelectDestination(false);
    };
    const handleSelectDate = (date) => {
        setSelectedDate(date);
        setShowDatePicker(false);
    };

    const handleSelectReturnDate = (date) => {
        setReturnDate(date);
        setShowReturnDatePicker(false);
    };
    const handleSwitchLocations = () => {
        const temp = selectedDeparture;
        setSelectedDeparture(selectedDestination);
        setSelectedDestination(temp);
    };

    const formatDateToLocal = (date) => {
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0'); // Tháng bắt đầu từ 0
        const day = String(date.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
    };

    const generateBookingUrl = () => {
        const departure = selectedDeparture?.tenTinhThanh || "";
        const destination = selectedDestination?.tenTinhThanh || "";
        const date = selectedDate ? formatDateToLocal(selectedDate) : ""; // Sử dụng hàm định dạng local
        console.log("date", date);

        return `/dat-ve?noidi=${encodeURIComponent(departure)}&noiden=${encodeURIComponent(destination)}&ngaydi=${encodeURIComponent(date)}`;
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
            <div className="search-form m-2 fw-semibold mx-lg-auto w-100 h-100 ">
                <div className="d-flex align-items-center justify-content-between text-15 w-100">
                    <Form>
                        <div className="btn-group btn-group-toggle" data-toggle="buttons">
                            <Form.Check
                                type="radio"
                                id="oneWay"
                                name="tripType"
                                label="Một chiều"
                                defaultChecked={tripType === "oneWay"}
                                onChange={() => handleTripTypeChange("oneWay")}
                                className="flex-grow-1 mx-2"
                            />
                            <Form.Check
                                type="radio"
                                id="roundTrip"
                                name="tripType"
                                label="Khứ hồi"
                                defaultChecked={tripType === "roundTrip"}
                                onChange={() => handleTripTypeChange("roundTrip")}
                                className="flex-grow-1 mx-2 d-none"
                            />
                        </div>
                    </Form>
                </div>

                <Row className="py-3 w-100 mb-4 row">
                    <Col lg={12} className="d-flex justify-content-between">
                        {/* Điểm đi */}
                        <div className="flex-grow-1 mx-1 position-relative">
                            <Form.Label>Điểm đi</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder={selectedDeparture ? selectedDeparture.tenTinhThanh : "Chọn điểm đi"}
                                aria-label="Chọn điểm đi"
                                size="lg"
                                className="control-custom"
                                onFocus={() => setShowSelectDeparture(true)}
                            />
                            <div className={`select-form ${showSelectDeparture ? 'show' : 'd-none'}`}>
                                <SelectForm onSelect={handleSelectDeparture} />
                            </div>
                        </div>

                        {/* Icon đổi vị trí */}
                    
                        <div className="flex-grow-1 position-relative d-flex align-items-center justify-content-center">
                            <img
                                className="switch-location cursor-pointer"
                                src={switchIcon}
                                alt="switch location icon"
                                onClick={handleSwitchLocations}
                            />
                        </div>


                        {/* Điểm đến */}
                        <div className="flex-grow-1 mx-1 position-relative">
                            <Form.Label>Điểm đến</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder={selectedDestination ? selectedDestination.tenTinhThanh : "Chọn điểm đến"}
                                aria-label="Chọn điểm đến"
                                size="lg"
                                className="control-custom"
                                onFocus={() => setShowSelectDestination(true)}
                            />
                            <div className={`select-form ${showSelectDestination ? 'show' : 'd-none'}`}>
                                <SelectForm onSelect={handleSelectDestination} />
                            </div> 
                        </div>

                        {/* Ngày đi */}
                        <div className={`flex-grow-${tripType === "roundTrip" ? "1" : "2"} mx-1 position-relative`}>
                            <Form.Label>Ngày đi</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder={selectedDate ? selectedDate.toLocaleDateString() : "Chọn ngày đi"}
                                aria-label="Chọn ngày đi"
                                readOnly
                                size="lg"
                                onFocus={() => setShowDatePicker(true)}
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

                        {/* Ngày về (chỉ hiển thị khi là khứ hồi) */}
                        {tripType === "roundTrip" && (
                            <div className="flex-grow-1 mx-1 position-relative">
                                <Form.Label>Ngày về</Form.Label>
                                <Form.Control
                                    type="text"
                                    placeholder={returnDate ? returnDate.toLocaleDateString() : "Chọn ngày về"}
                                    aria-label="Chọn ngày về"
                                    readOnly
                                    size="lg"
                                    onFocus={() => setShowReturnDatePicker(true)}
                                />
                                {showReturnDatePicker && (
                                    <div className="date-picker-container">
                                        <DatePicker
                                            selected={returnDate}
                                            onChange={handleSelectReturnDate}
                                            inline
                                        />
                                    </div>
                                )}
                            </div>
                        )}

                        {/* Số vé (Larger size) */}
                        <div className="flex-grow-2 " style={{ width: "90px" }}>
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
                    <Button
                        as={Link}
                        to={generateBookingUrl()}
                        className="text-white w-100 rounded-pill px-4"
                        variant=""
                        style={{ backgroundColor: '#EF5222', zIndex: 0 }}
                    >
                        Tìm chuyến xe
                    </Button>
                </div>
            </div>
        </div>
    );
}

export default SearchForm;
