
import { InputGroup, Form } from 'react-bootstrap';
import searchIcon from '@/assets/image/search.svg';
import switchIcon from '@/assets/image/switch_location.svg';
import './SearchSite.css';
import { useState } from 'react';
function ScheduleInputForm() {
    const [inputClass1, setInputClass1] = useState('');
    const [inputClass2, setInputClass2] = useState('');
    const handleMouseEnter1 = () => {
        setInputClass1('input-group-active');
    }
    const handleMouseLeave1 = () => {
        setInputClass1('');
    }

    const handleMouseEnter2 = () => {
        setInputClass2('input-group-active');
    }
    const handleMouseLeave2 = () => {
        setInputClass2('');
    }
    return (
        <>
            <div className="schedule-input-form d-flex w-100 justify-content-center g-4">
                {/* Điểm đi */}
                <InputGroup
                    className={inputClass1}
                    onMouseEnter={handleMouseEnter1}
                    onMouseLeave={handleMouseLeave1}
                >                       
                    <InputGroup.Text>
                        <img src={ searchIcon} alt="search icon" />
                    </InputGroup.Text>
                    <Form.Control
                       
                        type="text" placeholder="Nhập điểm đi" />
                </InputGroup>

                {/* Icon chuyển vị trí */}
                <img className="switch-location" src={switchIcon} alt="switch location icon" />

                {/* Điểm đến */}
                <InputGroup
                    className={inputClass2}
                    onMouseEnter={handleMouseEnter2}
                    onMouseLeave={handleMouseLeave2}
                    >
                    <InputGroup.Text>
                        <img src={searchIcon} alt="search icon" />
                    </InputGroup.Text>
                    <Form.Control
                        
                        type="text" placeholder="Nhập điểm đến" />
                </InputGroup>
            </div>
        </>
    );
}

export default ScheduleInputForm;
