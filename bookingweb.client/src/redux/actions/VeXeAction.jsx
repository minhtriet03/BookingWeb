import { createAsyncThunk } from "@reduxjs/toolkit";
import { axiosInstance } from "@/utils/axiosInstance";

const GetVeXeSelected = createAsyncThunk("Vexe/get", async (id_chuyenxe) => {
    try {
        console.log("id_chuyenxe", id_chuyenxe);
            const response = await axiosInstance.get(`api/vexe/chuyenxe/${id_chuyenxe}`);
            return response.data; // Trả về dữ liệu thành công
        } catch (error) {
            return error;
        }
    }
);

export { GetVeXeSelected };
