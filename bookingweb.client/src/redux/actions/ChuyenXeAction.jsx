import { createAsyncThunk } from "@reduxjs/toolkit";
import { axiosInstance } from '@/utils/axiosInstance';

const GetChuyenXe = createAsyncThunk("ChuyenXe/get", async ({ noidi, noiden }) => {
    try {
        const response = await axiosInstance.get(`api/ChuyenXe/tinh/${noidi}/${noiden}`);
        return response.data;
    } catch (error) {
        console.error(error);
        throw error;
    }
});




export { GetChuyenXe };
