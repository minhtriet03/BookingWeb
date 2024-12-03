import { createSlice } from "@reduxjs/toolkit";
import { GetChuyenXe } from "../actions/ChuyenXeAction";

const ChuyenXeSlice = createSlice({
    name: "ChuyenXe",
    initialState: {
        cxInfo: null,
    },
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(GetChuyenXe.fulfilled, (state, action) => {
                state.cxInfo = action.payload || null;
            })
            .addCase(GetChuyenXe.rejected, (state) => {
                state.cxInfo = null;
            });
    },
});

export default ChuyenXeSlice.reducer;

