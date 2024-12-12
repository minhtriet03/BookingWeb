import { createSlice } from "@reduxjs/toolkit";
import { GetVeXeSelected } from "../actions/VeXeAction";

const VeXeSlice = createSlice({
    name: "vexe",
    initialState: {
        vexeOrder: null,
        idPhieuDat: null,
        vexeSelected: null, // Vé xe được chọn
    },
    reducers: {
        setVeXeOrder: (state, action) => {
            state.vexeOrder = action.payload;
        },
        setIdPhieuDat: (state, action) => {
            state.idPhieuDat = action.payload;
        }
    },
    extraReducers: (builder) => {
        builder
            .addCase(GetVeXeSelected.fulfilled, (state, action) => {
                console.log("GetVeXeSelected", action.payload);
                state.vexeSelected = action.payload||null; // Lưu dữ liệu trả về
                
            })
            .addCase(GetVeXeSelected.rejected, (state, action) => {
                state.error = action.payload|| "Đã xảy ra lỗi"; // Lưu lỗi
            });
    }
});

export const { setVeXeOrder, setIdPhieuDat } = VeXeSlice.actions; // Export các actions để sử dụng
export default VeXeSlice.reducer;
