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

