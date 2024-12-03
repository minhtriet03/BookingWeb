import { useState } from 'react';
import Sidebar from "./Sidebar/index";
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import { Button } from 'react-bootstrap';

const columns = [
    { id: 'mave', label: 'Mã Vé', minWidth: 170 },
    { id: 'maphieu', label: 'Mã Phiếu', minWidth: 170 },
    { id: 'tuyenduong', label: 'Tuyến Đường', minWidth: 200 },
    { id: 'ngaydi', label: 'Ngày Đi', minWidth: 170 },
    { id: 'giave', label: 'Giá Vé', minWidth: 150, align: 'right' },
    { id: 'thanhtoan', label: 'Thanh Toán', minWidth: 150, align: 'right' },
    { id: 'trangthai', label: 'Trạng Thái', minWidth: 150, align: 'right' },
    { id: 'thaotac', label: 'Thao Tác', minWidth: 150, align: 'right' },
];

function createData(mave, maphieu, tuyenduong, ngaydi, giave, thanhtoan, trangthai, thaotac) {
    return { mave, maphieu, tuyenduong, ngaydi, giave, thanhtoan, trangthai, thaotac };
}

const rows = [
    createData('MV001', 'MP001', 'Hà Nội - Hồ Chí Minh', '2024-12-01', 500000, 'Đã Thanh Toán', 'Đã Xác Nhận', 'Xem'),
    createData('MV002', 'MP002', 'Hà Nội - Đà Nẵng', '2024-12-02', 350000, 'Chưa Thanh Toán', 'Chờ Xác Nhận', 'Xem'),
    createData('MV003', 'MP003', 'Hà Nội - Hải Phòng', '2024-12-03', 150000, 'Đã Thanh Toán', 'Đã Xác Nhận', 'Xem'),
    createData('MV004', 'MP004', 'Hồ Chí Minh - Đà Nẵng', '2024-12-04', 400000, 'Đã Thanh Toán', 'Đã Xác Nhận', 'Xem'),
    createData('MV005', 'MP005', 'Hà Nội - Nha Trang', '2024-12-05', 550000, 'Chưa Thanh Toán', 'Chờ Xác Nhận', 'Xem'),
    createData('MV006', 'MP006', 'Hồ Chí Minh - Cần Thơ', '2024-12-06', 300000, 'Đã Thanh Toán', 'Đã Xác Nhận', 'Xem'),
    createData('MV007', 'MP007', 'Hà Nội - Sapa', '2024-12-07', 400000, 'Chưa Thanh Toán', 'Chờ Xác Nhận', 'Xem'),
    createData('MV008', 'MP008', 'Đà Nẵng - Huế', '2024-12-08', 200000, 'Đã Thanh Toán', 'Đã Xác Nhận', 'Xem'),
    createData('MV009', 'MP009', 'Hồ Chí Minh - Phú Quốc', '2024-12-09', 800000, 'Chưa Thanh Toán', 'Chờ Xác Nhận', 'Xem'),
    createData('MV010', 'MP010', 'Hà Nội - Vũng Tàu', '2024-12-10', 600000, 'Đã Thanh Toán', 'Đã Xác Nhận', 'Xem'),
    createData('MV011', 'MP011', 'Hồ Chí Minh - Quy Nhơn', '2024-12-11', 450000, 'Chưa Thanh Toán', 'Chờ Xác Nhận', 'Xem'),
    createData('MV012', 'MP012', 'Đà Nẵng - Pleiku', '2024-12-12', 350000, 'Đã Thanh Toán', 'Đã Xác Nhận', 'Xem'),
    createData('MV013', 'MP013', 'Hà Nội - Đồng Hới', '2024-12-13', 300000, 'Chưa Thanh Toán', 'Chờ Xác Nhận', 'Xem'),
    createData('MV014', 'MP014', 'Hồ Chí Minh - Mỹ Tho', '2024-12-14', 250000, 'Đã Thanh Toán', 'Đã Xác Nhận', 'Xem'),
    createData('MV015', 'MP015', 'Hà Nội - Thanh Hóa', '2024-12-15', 200000, 'Chưa Thanh Toán', 'Chờ Xác Nhận', 'Xem'),
];

const History = () => {
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(10);

    const handleChangePage = (event, newPage) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (event) => {
        setRowsPerPage(+event.target.value);
        setPage(0);
    };

    return (
        <div className="d-flex justify-content-center align-items-center" style={{ height: "75vh" }}>
            <Sidebar />
            <div className="ms-3" style={{ height: '65vh', width: "800px" }}>
                <div className="d-flex">
                    <div>
                        <h4>Lịch sử đặt vé</h4>
                        <p>Theo dõi và quản lý quá trình lịch sử mua vé của bạn</p>
                    </div>
                    <div className="ms-auto">
                        <Button
                            variant="warning"
                            className="rounded-pill"
                            style={{
                                backgroundColor: "#FF5722",
                                border: "none",
                                padding: "8px 50px",
                                fontSize: "17px",
                                color: "white",
                            }}
                        >
                            Đặt vé
                        </Button>
                    </div>
                </div>
                <Paper sx={{ width: '100%', overflow: 'hidden' }}>
                <TableContainer sx={{ maxHeight: 360 }}>
                    <Table stickyHeader aria-label="sticky table">
                        <TableHead>
                            <TableRow>
                                {columns.map((column) => (
                                    <TableCell
                                        key={column.id}
                                        align={column.align}
                                        style={{ minWidth: column.minWidth }}
                                    >
                                        {column.label}
                                    </TableCell>
                                ))}
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {rows
                                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                                .map((row) => (
                                    <TableRow hover role="checkbox" tabIndex={-1} key={row.mave}>
                                        {columns.map((column) => {
                                            const value = row[column.id];
                                            return (
                                                <TableCell key={column.id} align={column.align}>
                                                    {column.id === 'thaotac' ? (
                                                        //<button onClick={() => handleAction(row.mave)}>
                                                        <button>
                                                            {value}
                                                        </button>
                                                    ) : (
                                                        value
                                                    )}
                                                </TableCell>
                                            );
                                        })}
                                    </TableRow>
                                ))}
                        </TableBody>
                    </Table>
                </TableContainer>
                    <TablePagination
                        rowsPerPageOptions={[10, 25, 100]}
                        component="div"
                        count={rows.length}
                        rowsPerPage={rowsPerPage}
                        page={page}
                        onPageChange={handleChangePage}
                        onRowsPerPageChange={handleChangeRowsPerPage}
                    />
                </Paper>
            </div>
        </div>
    );
};

export default History;
