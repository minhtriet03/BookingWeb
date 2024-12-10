import { createAsyncThunk } from "@reduxjs/toolkit";
import { axiosInstance } from '@/utils/axiosInstance';

const SetUser = createAsyncThunk("User/get", async () => {
    try {
        const response = await axiosInstance.get('/api/User/user-login')    
        return response.data;
    } catch {
        return "Khong goi duoc ";
    }
});




export { SetUser };
