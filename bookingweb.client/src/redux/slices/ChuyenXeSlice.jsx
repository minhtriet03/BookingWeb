import { createSlice } from "@reduxjs/toolkit";
import { GetChuyenXe } from "../actions/ChuyenXeAction";

const ChuyenXeSlice = createSlice({
    name: "ChuyenXe",
    initialState: {
        cxInfo: null,
        idcx: null,
    },
    reducers: {
        setChuyenXe: (state, action) => {
            console.log("setChuyenXe", action.payload);
            state.idcx = action.payload
        },
    },
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

export const { setChuyenXe } = ChuyenXeSlice.actions;

export default ChuyenXeSlice.reducer;

