import { useState, useEffect } from 'react';
import Sidebar from "./Sidebar/index";
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import { useSelector } from 'react-redux';
import { Button } from 'react-bootstrap';
import { getVeXeUser } from '@/apis/index';

const columns = [
    { id: 'mave', label: 'Mã Vé', minWidth: 170 },
    { id: 'maphieu', label: 'Mã Phiếu', minWidth: 170 },
    { id: 'xe', label: 'Xe', minWidth: 200 },
    { id: 'tuyenduong', label: 'Tuyến Đường', minWidth: 300 },
    { id: 'ngaydi', label: 'Ngày Đi', minWidth: 170 },
    { id: 'giave', label: 'Giá Vé', minWidth: 150 },
];

function createData(mave, maphieu, xe, tuyenduong, ngaydi, giave) {
    return { mave, maphieu, xe, tuyenduong, ngaydi, giave };
}



const History = () => {
    const userred = useSelector((state) => state.user);
    console.log(userred);
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(10);
    const [rows, setRows] = useState([]);

    // Fetch data when component mounts
    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getVeXeUser(userred.userInfo.userInfo.idUser);
                const ticketData = data.$values.map(ticket =>
                    createData(
                        ticket.idVe,
                        ticket.idPhieu,
                        ticket.xe,
                        ticket.tuyenduong,
                        ticket.ngayKhoiHanh,
                        ticket.giaVe
                    )
                );
                setRows(ticketData);
            } catch (error) {
                console.error('Error fetching tickets:', error.response?.data || error.message);
            }
        };
        fetchData();
    }, []);

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
                    <TableContainer sx={{ maxHeight: 263 }}>
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
