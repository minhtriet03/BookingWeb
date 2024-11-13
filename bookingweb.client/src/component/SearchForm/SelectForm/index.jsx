import { Form, ListGroup } from 'react-bootstrap';

function SelectForm() {
  return (
    <>
      <Form className='bg-white'>
        <div className="flex-grow-1 border shadow w-100 rounded position-absolute z-100 bg-white" style={{ top: '0px' }}>
          {/* <Form.Control
            type="text"
            placeholder="Chọn điểm đi"
            aria-label="Chọn điểm đi"
            size="lg"
            className="mx-2"
            style={{ width: 'calc(100% - 16px)' }}  // 16px là khoảng trống của mx-2
          /> */}
          <Form.Label className='mt-2 px-2'>Tỉnh/Thành phố</Form.Label>
          <ListGroup className='mt-1 w-100 fw-normal border-bottom' style={{ overflowY : 'auto', maxHeight: '200px'}}>
            <ListGroup.Item>An Giang</ListGroup.Item>
            <ListGroup.Item>TP Hồ Chí Minh</ListGroup.Item>
            <ListGroup.Item>Cần Thơ</ListGroup.Item>
            <ListGroup.Item>Đồng Tháp</ListGroup.Item>
            <ListGroup.Item>Tiền Giang</ListGroup.Item>
          </ListGroup>

        </div>
      </Form>
    </>
  );
}

export default SelectForm