import { createAsyncThunk } from "@reduxjs/toolkit";
import { axiosInstance } from '@/utils/axiosInstance';

const GetChuyenXe = createAsyncThunk("ChuyenXe/get", async ({ noidi, noiden, ngaydi }) => {
    try {
        const response = await axiosInstance.get(`api/ChuyenXe/tinh/${noidi}/${noiden}/${ngaydi}`);
        return response.data;
    } catch (error) {
        console.error(error);
        throw error;
    }
});




export { GetChuyenXe };
