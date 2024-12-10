import { createAsyncThunk } from '@reduxjs/toolkit';
import { axiosInstance } from '@/utils/axiosInstance';

export const loginUser = createAsyncThunk(
  "auth/login", 
  async (values, thunkAPI) => {
    try {
      const response = await axiosInstance.post('/api/Account/login', values);
      return response.data;  // Trả về dữ liệu người dùng khi login thành công
    } catch (error) {
      return thunkAPI.rejectWithValue(error.response?.data || "Login failed");
    }
  }
);

export const logout = createAsyncThunk(
<<<<<<< HEAD
  "auth/logout",
  async (_, thunkAPI) => {
      try {
          await axiosInstance.post('/api/Account/logout', {}, { withCredentials: true });
          return "Logout successful"; // Trả về thông báo cụ thể
      } catch (error) {
          console.error("Logout failed:", error);
          return thunkAPI.rejectWithValue("Logout failed");
      }
    }


);
=======
    "auth/logout",
    async (_, thunkAPI) => {
        try {
            // Gửi request logout tới server
            await axiosInstance.post('/api/Account/logout', {}, { withCredentials: true });
>>>>>>> 35d812ffe9eedbf4753bd9855622388b6880697a

            // Trả về kết quả nếu thành công
            return "Logout successful";
        } catch (error) {
            console.error("Logout failed:", error);

            // Xử lý lỗi chi tiết hơn
            return thunkAPI.rejectWithValue(
                error.response?.data?.message || "Logout failed"
            );
        }
    }
);
